using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodingDojoIoc.Interfaces;

namespace CodingDojoIoc
{
    class CodingDojoContainer :ICodingDojoContainer
    {
        private readonly List<Type> _types;
        private readonly Dictionary<Type, object> _dictionaryObject;
        private readonly Dictionary<Type, Type> _classesInterfacesDictionary;

        public CodingDojoContainer(List<Type> types, Dictionary<Type, object> dictionaryObject, Dictionary<Type, Type> classesInterfacesDictionary)
        {
            _types = types;
            _dictionaryObject = dictionaryObject;
            _classesInterfacesDictionary = classesInterfacesDictionary;
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            if (_dictionaryObject.TryGetValue(type, out object foundDictObj))
            {
                return foundDictObj;
            }
            else
            {
                var foundType = _types.SingleOrDefault(x => x == type);
                if (foundType == null)
                {
                    if (!_classesInterfacesDictionary.TryGetValue(type, out foundType))
                    {
                        return null;
                    }
                }

                var obj = Activator.CreateInstance(foundType);
                return obj;
            }
        }
    }
}
