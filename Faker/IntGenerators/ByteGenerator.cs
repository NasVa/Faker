using System;

namespace Faker
{
    public class ByteGenerator : IValueGenerator
    {
        public ByteGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(byte);
        }

        public object Generate(GeneratorContext context)
        {
            return (byte)context.Random.Next(byte.MaxValue + 1);
        }
    }
}