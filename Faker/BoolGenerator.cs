using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators.PrimitiveTypesGenerators
{
    public class BoolGenerator : AbstractGenerator
    {
        public BoolGenerator()
        {
            DataType = typeof(bool);
        }

        public override object Generate()
        {
            if (Random.Next(2)==0)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
}
