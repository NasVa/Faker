using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class UIntGenerator : IValueGenerator
    {
        public UIntGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(uint);
        }

        public object Generate(GeneratorContext context)
        {
            byte[] buf = new byte[4];
            context.Random.NextBytes(buf);
            return BitConverter.ToUInt32(buf, 0);

        }
    }
}
