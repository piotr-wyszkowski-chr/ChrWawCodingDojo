using System;
using System.Collections.Generic;
using System.Text;

namespace CodingDojoIoc.Tests.Classes
{
    public class ClassWithDependencies
    {
        private readonly Class2 _class2;
        private readonly Class3 _class3;

        public ClassWithDependencies(Class2 class2, Class3 class3)
        {
            _class2 = class2;
            _class3 = class3;
        }
    }
}
