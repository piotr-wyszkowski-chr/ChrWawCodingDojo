using System;
using System.IO;
using CodingDojoIoc.Interfaces;
using CodingDojoIoc.Tests.Classes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingDojoIoc.Tests
{
    [TestClass]
    public class CodingDojoContainerTests
    {
        private CodingDojoContainerBuilder _builder;

        [TestInitialize]
        public void TestInitialize()
        {
            _builder = new CodingDojoContainerBuilder();
        }

        [TestMethod]
        public void RegisterSingleton_Interface()
        {
            var obj = new ClassWithInterface();
            _builder.Register<IClassWithInterface>(obj);

            var container = _builder.Build();
            container.Resolve<IClassWithInterface>().Should().Be(obj);
        }

        [TestMethod]
        public void RegisterSingleton_Object()
        {
            var obj = new ClassWithInterface();
            _builder.Register(obj);
            var container = _builder.Build();
            container.Resolve<ClassWithInterface>().Should().Be(obj);
        }

        [TestMethod]
        public void RegisterType_Interface()
        {
            _builder.Register<IClassWithInterface, ClassWithInterface>();
            var container = _builder.Build();
            container.Resolve<IClassWithInterface>().Should().BeOfType(typeof(IClassWithInterface));
            container.Resolve<IClassWithInterface>().Should().NotBe(container.Resolve<IClassWithInterface>());

        }

        [TestMethod]
        public void RegisterType_Object()
        {
            _builder.Register<ClassWithInterface>();
            var container = _builder.Build();

            container.Resolve<ClassWithInterface>().Should().BeOfType(typeof(ClassWithInterface));
            container.Resolve<ClassWithInterface>().Should().NotBe(container.Resolve<ClassWithInterface>());
        }

        [TestMethod]
        public void RegisterObjectAndSingleton_GetSingleton()
        {
            var obj = new ClassWithInterface();
            _builder.Register<IClassWithInterface>(obj);
            _builder.Register<IClassWithInterface, ClassWithInterface>();

            var container = _builder.Build();

            container.Resolve<IClassWithInterface>().Should().BeOfType(typeof(ClassWithInterface));
            container.Resolve<IClassWithInterface>().Should().NotBe(obj);
        }

        [TestMethod]
        public void RegisterSingletonAndObject_GetObject()
        {
            var obj = new ClassWithInterface();
            _builder.Register<IClassWithInterface, ClassWithInterface>();
            _builder.Register<IClassWithInterface>(obj);

            var container = _builder.Build();

            container.Resolve<ClassWithInterface>().Should().BeOfType(typeof(ClassWithInterface));
            container.Resolve<ClassWithInterface>().Should().Be(obj);
        }

        [TestMethod]
        public void Resolve_NotRegisteredType()
        {
            var container = _builder.Build();

            container.Invoking((c) => c.Resolve<ClassWithInterface>()).Should().Throw<Exception>();
        }

        [TestMethod]
        public void RegisterNestedTypes_Resolve()
        {
            _builder.Register<Class2>();
            _builder.Register<Class3>();
            _builder.Register<ClassWithDependencies>();

            var container = _builder.Build();
            container.Resolve<ClassWithDependencies>().Should().BeAssignableTo<ClassWithDependencies>();
        }

        [TestMethod]
        public void RegisterType()
        {
            _builder.RegisterType(typeof(ClassWithDependencies));
            ICodingDojoContainer container = _builder.Build();
            object class1 = container.Resolve(typeof(ClassWithDependencies));
            class1.Should().BeAssignableTo(typeof(ClassWithDependencies));
        }

        [TestMethod]
        public void Resolve_NotRegistered_Null()
        {
            ICodingDojoContainer container = _builder.Build();
            object class1 = container.Resolve(typeof(ClassWithDependencies));
            class1.Should().BeNull();
        }

        [TestMethod]
        public void RegisterGenericType()
        {
            _builder.Register<ClassWithDependencies>();
            ICodingDojoContainer container = _builder.Build();
            object class1 = container.Resolve(typeof(ClassWithDependencies));
            class1.Should().BeAssignableTo<ClassWithDependencies>();
        }

        [TestMethod]
        public void RegisterObject()
        {
            ClassWithDependencies classWithDependencies = new ClassWithDependencies();
            _builder.Register<ClassWithDependencies>(classWithDependencies);
            ICodingDojoContainer container = _builder.Build();
            object class1Resolved = container.Resolve(typeof(ClassWithDependencies));
            class1Resolved.Should().BeEquivalentTo(classWithDependencies);
        }

        [TestMethod]
        public void RegisterGeneric_WithInterface_NotNull()
        {
            _builder.Register<IClassWithInterface, ClassWithInterface>();
            var container = _builder.Build();
            var result = container.Resolve(typeof(IClassWithInterface));
            result.Should().BeAssignableTo<ClassWithInterface>();
        }
    }

    public class ClassWithInterface : IClassWithInterface
    {
    }

    public interface IClassWithInterface
    {
    }
}