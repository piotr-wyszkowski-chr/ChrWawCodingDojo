using System;
using System.Collections.Generic;
using CodingDojoIoc.Interfaces;

namespace CodingDojoIoc
{
    public class CodingDojoContainerBuilder
    {
        private readonly List<Type> _types = new List<Type>();
        private readonly Dictionary<Type,object> _dictionaryObject = new Dictionary<Type, object>();
        private readonly Dictionary<Type,Type> _classesInterfacesDictionary = new Dictionary<Type, Type>();
        public ICodingDojoContainer Build()
        {
            var container = new CodingDojoContainer(_types, _dictionaryObject, _classesInterfacesDictionary);
            return container;
        }

        public CodingDojoContainerBuilder RegisterType(Type type)
        {
            _types.Add(type);
            return this;
        }
        public CodingDojoContainerBuilder Register<T, TInterface>()
            where T : class, TInterface
            where TInterface:class
        {
            _classesInterfacesDictionary.Add(typeof(TInterface), typeof(T));
            return this;
        }
        public CodingDojoContainerBuilder Register<T>()
            where T : class
        {
            _types.Add(typeof(T));
            return this;
        }

        public CodingDojoContainerBuilder Register<T>(T obj)
        {
            _dictionaryObject.Add(typeof(T),obj);
            return this;
        }
    }
}