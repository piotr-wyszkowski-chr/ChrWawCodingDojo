using System;
using System.Collections.Generic;
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
            _builder.RegisterSingleton<IClassWithInterface>(obj);

            var container = _builder.Build();
            container.Resolve<IClassWithInterface>().Should().Be(obj);
        }

        [TestMethod]
        public void RegisterSingleton_Object()
        {
            var obj = new ClassWithInterface();
            _builder.RegisterSingleton(obj);
            var container = _builder.Build();
            container.Resolve<ClassWithInterface>().Should().Be(obj);
        }

        [TestMethod]
        public void Register_Interface_Class()
        {
            _builder.Register<IClassWithInterface, ClassWithInterface>();
            var container = _builder.Build();
            container.Resolve<IClassWithInterface>().Should().BeAssignableTo(typeof(IClassWithInterface));
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
            _builder.RegisterSingleton<IClassWithInterface>(obj);
            _builder.Register<IClassWithInterface, ClassWithInterface>();

            var container = _builder.Build();

            container.Resolve<IClassWithInterface>().Should().BeOfType(typeof(ClassWithInterface));
            container.Resolve<IClassWithInterface>().Should().NotBe(obj);
        }

        [TestMethod]
        public void Register_Interface_Class_Then_Singleton_ResolveSigleton()
        {
            var obj = new ClassWithInterface();
            _builder.Register<IClassWithInterface, ClassWithInterface>();
            _builder.RegisterSingleton<IClassWithInterface>(obj);

            var container = _builder.Build();

            container.Resolve<IClassWithInterface>().Should().Be(obj);
        }

        [TestMethod]
        public void Resolve_NotRegisteredType()
        {
            var container = _builder.Build();

            container.Invoking((c) => c.Resolve<ClassWithInterface>()).Should().Throw<KeyNotFoundException>();
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
        public void RegisterNestedNotAllDependenciesRegistered_Exception()
        {
            _builder.Register<MoreNestedClass>();
            _builder.Register<MoreNestedClass2>();

            var container = _builder.Build();
            container.Invoking(c => c.Resolve<MoreNestedClass>()).Should().Throw<Exception>();
        }

        [TestMethod]
        public void RegisterNestedAllDependenciesRegistered_ResolveObject()
        {
            _builder.Register<MoreNestedClass>();
            _builder.Register<MoreNestedClass2>();
            _builder.Register<EvenMoreNestedClass>();

            var container = _builder.Build();
            container.Resolve<MoreNestedClass>().Should().BeAssignableTo<MoreNestedClass>();
        }

        [TestMethod]
        public void RegisterNestedTypes_NotRegisteredConstructorClasses_ThrowException()
        {
            _builder.Register<ClassWithDependencies>();

            var container = _builder.Build();
            container.Invoking((c) => c.Resolve<ClassWithDependencies>()).Should().Throw<Exception>();
        }

        [TestMethod]
        public void RegisterType()
        {
            _builder.RegisterType(typeof(Class2));
            ICodingDojoContainer container = _builder.Build();
            object class1 = container.Resolve(typeof(Class2));
            class1.Should().BeAssignableTo(typeof(Class2));
        }

        [TestMethod]
        public void RegisterGenericType()
        {
            _builder.Register<Class2>();
            ICodingDojoContainer container = _builder.Build();
            object class1 = container.Resolve(typeof(Class2));
            class1.Should().BeAssignableTo<Class2>();
        }

        [TestMethod]
        public void RegisterObject()
        {
            Class2 classWithDependencies = new Class2();
            _builder.RegisterSingleton(classWithDependencies);
            ICodingDojoContainer container = _builder.Build();
            object class1Resolved = container.Resolve(typeof(Class2));
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

        [TestMethod]
        public void RegisterType_Interface_InvalidOperationException()
        {
            _builder.Invoking(b => b.RegisterType(typeof(IClassWithInterface))).Should()
                .Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void Register_InterfaceClass_Then_InterfaceClass2_ResolveClass2()
        {
            _builder.Register<IClassWithInterface, ClassWithInterface>();
            _builder.Register<IClassWithInterface, ClassWithInterface2>();

            var container = _builder.Build();

            container.Resolve<IClassWithInterface>().Should().BeAssignableTo<ClassWithInterface2>();
        }

        [TestMethod]
        public void Register_Singleton_Then_Interface_Class_ResolveSigleton()
        {
            var obj = new ClassWithInterface();
            _builder.RegisterSingleton<IClassWithInterface>(obj);
            _builder.Register<IClassWithInterface, ClassWithInterface>();

            var container = _builder.Build();

            container.Resolve<IClassWithInterface>().Should().NotBe(obj);
            container.Resolve<IClassWithInterface>().Should().BeAssignableTo<ClassWithInterface>();
        }
    }

    public class ClassWithInterface2 : IClassWithInterface
    {
    }

    public class ClassWithInterface : IClassWithInterface
    {
    }

    public interface IClassWithInterface
    {
    }
}