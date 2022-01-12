using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.TestObjects
{
    class ExceptionClass
    {
        public string a;
        public int b;
        public int c;

        public ExceptionClass(string a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public ExceptionClass(string a, int b, int c)
        {
            throw new Exception();
        }
    }
}
