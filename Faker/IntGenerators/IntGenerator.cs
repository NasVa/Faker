using System;

namespace Generators.PrimitiveTypesGenerators
{
    public class IntGenerator : AbstractGenerator

    {
        public IntGenerator()
        {
            DataType = typeof(int);
        }

        public override object Generate()
        {
            byte[] buf = new byte[4];
            Random.NextBytes(buf);
            return BitConverter.ToInt32(buf, 0);
        }
    }
}