namespace Generators.PrimitiveTypesGenerators
{
    public class ShortGenerator : AbstractGenerator
    {
        public ShortGenerator()
        {
            DataType = typeof(short);
        }

        public override object Generate()
        {
            return (short)Random.Next(short.MinValue, short.MaxValue + 1);
        }
    }
}