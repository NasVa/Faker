using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class ClassB
    {
        public ClassC c { get; set; }
        public ClassB(ClassC c)
        {
            this.c = c;
        }
    }
}
