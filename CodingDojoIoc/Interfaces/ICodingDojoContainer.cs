using System;

namespace CodingDojoIoc.Interfaces
{
    public interface ICodingDojoContainer
    {
        T Resolve<T>();
        object Resolve(Type type);
    }
}