using System;
namespace Faker
{
    public class ShortGenerator : IValueGenerator
    {
        public ShortGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(short);
        }
        public object Generate(GeneratorContext context)
        {
            return (short)context.Random.Next(short.MinValue, short.MaxValue + 1);
        }
    }
}