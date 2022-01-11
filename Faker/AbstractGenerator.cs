using System;

namespace Generators
{
    public abstract class AbstractGenerator
    {
        public Type DataType { get; protected set; }
        protected static readonly Random Random;

        static AbstractGenerator()
        {
            Random = new Random();
        }

        public abstract object Generate();
    }
}