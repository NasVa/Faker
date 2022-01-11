using System;

namespace Generators.PrimitiveTypesGenerators
{
    public class ByteGenerator : AbstractGenerator
    {
        public ByteGenerator()
        {
            DataType = typeof(byte);
        }

        public override object Generate()
        {
            return (byte)Random.Next(byte.MaxValue + 1);
        }
    }
}