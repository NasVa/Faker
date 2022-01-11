using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators.PrimitiveTypesGenerators.FloatGenerators
{
    public class FloatGenerator : AbstractGenerator
    {
        public FloatGenerator()
        {
            DataType = typeof(float);
        }

        public override object Generate()
        {
            byte[] buff = new byte[32];
            Random.NextBytes(buff);
            return BitConverter.ToSingle(buff, 0);
        }
    }
}
