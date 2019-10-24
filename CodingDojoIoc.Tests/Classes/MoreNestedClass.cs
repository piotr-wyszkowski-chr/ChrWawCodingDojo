namespace CodingDojoIoc.Tests.Classes
{
    public class MoreNestedClass
    {
        public MoreNestedClass(MoreNestedClass2 obj)
        {

        }

    }

    public class MoreNestedClass2
    {
        public MoreNestedClass2(EvenMoreNestedClass obj)
        {
            
        }
    }

    public class EvenMoreNestedClass
    {
    }
}