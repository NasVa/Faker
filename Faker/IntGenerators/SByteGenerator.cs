using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators.PrimitiveTypesGenerators
{
    public class SByteGenerator : AbstractGenerator
    {
        public SByteGenerator()
        {
            DataType = typeof(sbyte);
        }

        public override object Generate()
        {
            return (sbyte)Random.Next(sbyte.MinValue, sbyte.MaxValue + 1);
        }
    }
}
