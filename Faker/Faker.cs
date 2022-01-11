using Generators;
using Generators.PrimitiveTypesGenerators;
using Generators.PrimitiveTypesGenerators.FloatGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    class Faker
    {
        Random random;
        List<AbstractGenerator> generators;

        public Faker()
        {
            random = new Random();
            generators = new List<AbstractGenerator>()
            {
                new BoolGenerator(),
                new ByteGenerator(),
                new IntGenerator(),
                new LongGenerator(),
                new SByteGenerator(),
                new ShortGenerator(),
                new UIntGenerator(),
                new ULongGenerator(),
                new UShortGenerator(),
                new DoubleGenerator(),
                new FloatGenerator(),
                new StringGenerator()
                //new DateTimeGenerator(),
            };

        }

        public object Generate(System.Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            int numParam = 0;
            ConstructorInfo maxParamConstructor = null;
            foreach (ConstructorInfo constructor in constructors)
            {
                if (constructor.GetParameters().Length > numParam)
                {
                    numParam = constructor.GetParameters().Length;
                    maxParamConstructor = constructor;
                }
            }
            ParameterInfo[] parameters = maxParamConstructor.GetParameters();
            object[] args = new object[maxParamConstructor.GetParameters().Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                args[i] = Create2(parameters[i].ParameterType);
            }
            return maxParamConstructor.Invoke(args);
        }


        public T Create<T>()
        {
            return (T)Create2(typeof(T));
        }

        public object Create2(System.Type type)
        {
            foreach (AbstractGenerator generator in generators)
            {
                if (generator.DataType == type)
                {
                    object o = generator.Generate();
                    return o;
                }
            }
            return Generate(type);
        }
    }
}
