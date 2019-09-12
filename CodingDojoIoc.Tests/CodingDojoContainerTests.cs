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
        private readonly CodingDojoContainerBuilder _builder;

        public CodingDojoContainerTests()
        {
            _builder = new CodingDojoContainerBuilder(); 
        }

        [TestMethod]
        public void RegisterType()
        {
            _builder.RegisterType(typeof(Class1));
            ICodingDojoContainer container = _builder.Build();
            object class1 = container.Resolve(typeof(Class1));
            class1.Should().BeAssignableTo(typeof(Class1));
        }

        [TestMethod]
        public void Resolve_NotRegistered_Null()
        {
            ICodingDojoContainer container = _builder.Build();
            object class1 = container.Resolve(typeof(Class1));
            class1.Should().BeNull();
        }

        [TestMethod]
        public void RegisterGenericType()
        {
            _builder.Register<Class1>();
            ICodingDojoContainer container = _builder.Build();
            object class1 = container.Resolve(typeof(Class1));
            class1.Should().BeAssignableTo<Class1>();
        }

        [TestMethod]
        public void RegisterObject()
        {
            Class1 class1 = new Class1();
            _builder.Register<Class1>(class1);
            ICodingDojoContainer container = _builder.Build();
            object class1Resolved = container.Resolve(typeof(Class1));
            class1Resolved.Should().BeEquivalentTo(class1);
        }

        [TestMethod]
        public void RegisterGeneric_WithInterface_NotNull()
        {
            _builder.Register<ClassWithInterface, IClassWithInterface>();
            var container = _builder.Build();
            var result = container.Resolve(typeof(IClassWithInterface));
            result.Should().BeAssignableTo<ClassWithInterface>();
        }
    }

    public class ClassWithInterface: IClassWithInterface
    {
    }

    public interface IClassWithInterface
    {
    }
}