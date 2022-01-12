using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class LongGenerator : IValueGenerator
    {
        public LongGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(long);
        }
        public object Generate(GeneratorContext context)
        {
            byte[] buf = new byte[8];
            context.Random.NextBytes(buf);
            return BitConverter.ToInt64(buf, 0);
        }
    }
}
