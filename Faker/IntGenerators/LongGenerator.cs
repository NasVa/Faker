using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators.PrimitiveTypesGenerators 
{
    public class LongGenerator : AbstractGenerator
    {
        public LongGenerator()
        {
            DataType = typeof(long);
        }

        public override object Generate()
        {
            byte[] buf = new byte[8];
            Random.NextBytes(buf);
            return BitConverter.ToInt64(buf, 0);
        }
    }
}
