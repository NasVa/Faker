using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class UShortGenerator : IValueGenerator
    {
        public UShortGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(ushort);
        }

        public object Generate(GeneratorContext context)
        {
            return (ushort)context.Random.Next(ushort.MaxValue);
        }
    }
}
