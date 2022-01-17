using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class ClassC
    {
        public ClassA a { get; set; }
        public ClassC(ClassA a)
        {
            this.a = a;
        }
    }
}
