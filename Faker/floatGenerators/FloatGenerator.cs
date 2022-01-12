using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class FloatGenerator : IValueGenerator
    {
        public FloatGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(float);
        }

        public object Generate(GeneratorContext context)
        {
            byte[] buff = new byte[32];
            context.Random.NextBytes(buff);
            return BitConverter.ToSingle(buff, 0);
        }
    }
}
