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
            RemoveIfRegistered(type);
            _classesInterfacesDictionary.Add(type, type);
            return this;
        }
        public CodingDojoContainerBuilder Register<TInterface, T>()
            where T : class, TInterface
            where TInterface:class
        {
            RemoveIfRegistered(typeof(TInterface));
            _classesInterfacesDictionary.Add(typeof(TInterface), typeof(T));
            return this;
        }
        public CodingDojoContainerBuilder Register<T>()
            where T : class
        {
            Register<T, T>();
            return this;
        }

        public CodingDojoContainerBuilder Register<T>(T obj)
        {
            RemoveIfRegistered(typeof(T));
            _dictionaryObject.Add(typeof(T),obj);
            return this;
        }
    }
}