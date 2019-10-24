using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CodingDojoIoc.Interfaces;

namespace CodingDojoIoc
{
    class CodingDojoContainer : ICodingDojoContainer
    {
        private readonly Dictionary<Type, object> _dictionarySingletons;
        private readonly Dictionary<Type, Type> _dictionaryTypes;

        public CodingDojoContainer(Dictionary<Type, object> dictionarySingletons, Dictionary<Type, Type> dictionaryTypes)
        {
            _dictionarySingletons = dictionarySingletons;
            _dictionaryTypes = dictionaryTypes;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            if (_dictionarySingletons.TryGetValue(type, out object foundDictObj))
            {
                return foundDictObj;
            }
            else
            {
                if (!_dictionaryTypes.TryGetValue(type, out var foundType))
                {
                    throw new KeyNotFoundException(message: $"Type {type.Name} not specified in container");
                }

                var constructorInfo = foundType.GetConstructors()
                    .OrderByDescending(x => x.GetParameters().Length).
                    FirstOrDefault(x => !x.GetParameters().Any() || x.GetParameters().
                            All(z => _dictionaryTypes.ContainsKey(z.ParameterType)));

                if (constructorInfo == null)
                {
                    throw new Exception("Could not resolve object");
                }
                var parameters = constructorInfo.GetParameters().Select(info => Resolve(info.ParameterType)).ToArray();
                if (parameters.Length == 0)
                {
                    return Activator.CreateInstance(foundType);
                }

                return constructorInfo.Invoke(parameters);
            }
        }
    }
}
