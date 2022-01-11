using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators.PrimitiveTypesGenerators.FloatGenerators
{
    public class DoubleGenerator : AbstractGenerator
    {
        public DoubleGenerator()
        {
            DataType = typeof(double);
        }

        public override object Generate()
        {
            byte[] buff = new byte[8];
            Random.NextBytes(buff);
            return BitConverter.ToDouble(buff, 0);
        }
    }
}
