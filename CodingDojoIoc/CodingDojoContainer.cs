using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodingDojoIoc.Interfaces;

namespace CodingDojoIoc
{
    class CodingDojoContainer :ICodingDojoContainer
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
                    return null;
                }

                var obj = Activator.CreateInstance(foundType);
                return obj;
            }
        }
    }
}
