using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators.PrimitiveTypesGenerators
{
    public class UIntGenerator : AbstractGenerator
    {
        public UIntGenerator()
        {
            DataType = typeof(uint);
        }

        public override object Generate()
        {
            byte[] buf = new byte[4];
            Random.NextBytes(buf);
            return BitConverter.ToUInt32(buf, 0);

        }
    }
}
