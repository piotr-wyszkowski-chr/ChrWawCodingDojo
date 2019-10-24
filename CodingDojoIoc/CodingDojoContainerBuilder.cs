using System;
using System.Collections.Generic;
using System.Linq;
using CodingDojoIoc.Interfaces;

namespace CodingDojoIoc
{
    public class CodingDojoContainerBuilder
    {
        private readonly Dictionary<Type,object> _dictionaryObject = new Dictionary<Type, object>();
        private readonly Dictionary<Type,Type> _classesInterfacesDictionary = new Dictionary<Type, Type>();

        private void RemoveIfRegistered(Type type)
        {
            _dictionaryObject.Remove(type); 
            _classesInterfacesDictionary.Remove(type);
        }

        public ICodingDojoContainer Build()
        {
            var container = new CodingDojoContainer(_dictionaryObject, _classesInterfacesDictionary);
            return container;
        }

        public CodingDojoContainerBuilder RegisterType(Type type)
        {
            if (type.IsInterface)
            {
                throw new InvalidOperationException("Could not register interface type");
            }
            RemoveIfRegistered(type);
            _classesInterfacesDictionary.Add(type, type);
            return this;
        }
        public CodingDojoContainerBuilder Register<TBase, T>()
            where T : class, TBase
            where TBase:class
        {
            RemoveIfRegistered(typeof(TBase));
            _classesInterfacesDictionary.Add(typeof(TBase), typeof(T));
            return this;
        }
        public CodingDojoContainerBuilder Register<T>()
            where T : class
        {
            RegisterType(typeof(T));
            return this;
        }

        public CodingDojoContainerBuilder RegisterSingleton<T>(T obj)
        {
            RemoveIfRegistered(typeof(T));
            _dictionaryObject.Add(typeof(T),obj);
            return this;
        }
    }
}