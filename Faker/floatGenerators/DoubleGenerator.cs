using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class DoubleGenerator : IValueGenerator
    {
        public DoubleGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(double);
        }
        public object Generate(GeneratorContext context)
        {
            byte[] buff = new byte[8];
            context.Random.NextBytes(buff);
            return BitConverter.ToDouble(buff, 0);
        }
    }
}
