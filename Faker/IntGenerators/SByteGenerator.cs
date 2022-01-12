using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class SByteGenerator : IValueGenerator
    {
        public SByteGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(sbyte);
        }
        public object Generate(GeneratorContext context)
        {
            return (sbyte)context.Random.Next(sbyte.MinValue, sbyte.MaxValue + 1);
        }
    }
}
