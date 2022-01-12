using System;

namespace Faker
{
    public class IntGenerator : IValueGenerator

    {
        public IntGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(int);
        }
        public object Generate(GeneratorContext context)
        {
            byte[] buf = new byte[4];
            context.Random.NextBytes(buf);
            return BitConverter.ToInt32(buf, 0);
        }
    }
}