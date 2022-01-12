using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class BoolGenerator : IValueGenerator
    {
        public BoolGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(bool);
        }

        public object Generate(GeneratorContext context)
        {
            if (context.Random.Next(2)==0)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
}
