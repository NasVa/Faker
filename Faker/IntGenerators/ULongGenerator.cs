using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators.PrimitiveTypesGenerators
{
    public class ULongGenerator : AbstractGenerator
    {
        public ULongGenerator()
        {
            DataType = typeof(ulong);
        }

        public override object Generate()
        {
            byte[] buf = new byte[8];
            Random.NextBytes(buf);
            return BitConverter.ToUInt64(buf, 0);
        }
    }
}
