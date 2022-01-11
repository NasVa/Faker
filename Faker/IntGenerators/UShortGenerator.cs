using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators.PrimitiveTypesGenerators
{
    public class UShortGenerator : AbstractGenerator
    {
        public UShortGenerator()
        {
            DataType = typeof(ushort);
        }

        public override object Generate()
        {
            return (ushort)Random.Next(ushort.MaxValue);
        }
    }
}
