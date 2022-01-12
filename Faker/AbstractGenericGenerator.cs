using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public abstract class AbstractGenericGenerator
    {
        protected int Size;
        public Type DataType { get; protected set; }

        public abstract object Generate(System.Type type);
    }
}
