using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class ULongGenerator : IValueGenerator
    {
        public ULongGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(ulong);
        }

        public object Generate(GeneratorContext context)
        {
            byte[] buf = new byte[8];
            context.Random.NextBytes(buf);
            return BitConverter.ToUInt64(buf, 0);
        }
    }
}
