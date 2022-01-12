using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Faker : IFaker
    {
        Random random;
        List<IValueGenerator> generators;
        List<ConstructorInfo> exeptionConstructors;

        public Faker()
        {
            random = new Random();
            generators = new List<IValueGenerator>()
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
                new StringGenerator(),
                new DateTimeGenerator(),
                new ListGenerator()
            };
            exeptionConstructors = new List<ConstructorInfo>();
        }

        public object Generate(System.Type type)
        {
            object newObj = null;
            ConstructorInfo[] constructors = type.GetConstructors();
            int numParam = 0;
            ConstructorInfo maxParamConstructor = null;
            foreach (ConstructorInfo constructor in constructors)
            {
                if (constructor.GetParameters().Length > numParam)
                {
                    if (exeptionConstructors.Count == 0)
                    {
                        numParam = constructor.GetParameters().Length;
                        maxParamConstructor = constructor;
                    }
                    else { 
                        if (!exeptionConstructors.Contains(constructor))
                        {
                            numParam = constructor.GetParameters().Length;
                            maxParamConstructor = constructor;
                        }
                    }
                }
            }

            if (maxParamConstructor == null)
            {
                Console.WriteLine("{0}: No one available constructor", type.ToString());
                return null;
            }

            ParameterInfo[] parameters = maxParamConstructor.GetParameters();
            object[] args = new object[maxParamConstructor.GetParameters().Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                args[i] = Create(parameters[i].ParameterType);
            }
            try
            {
                newObj = maxParamConstructor.Invoke(args);
                foreach (var f in type.GetFields().Where(f => f.IsPublic))
                {
                    /*Console.WriteLine(f.Name);
                    Console.WriteLine(f.GetValue(newObj).GetType());
                    Console.WriteLine(f.GetValue(newObj));
                    if (GetDefaultValue(f.FieldType) != null)
                    {
                        Console.WriteLine(GetDefaultValue(f.FieldType).GetType());
                        Console.WriteLine(GetDefaultValue(f.FieldType));
                    }*/
                    if (f.GetValue(newObj).Equals(GetDefaultValue(f.FieldType)))
                    {
                        f.SetValue(newObj, Create(f.FieldType));
                    }
                }
            }
            catch(Exception e)
            {
                exeptionConstructors.Add(maxParamConstructor);
                newObj = Generate(type);
            }
            return newObj;
        }


        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public object Create(Type type)
        {
            foreach (IValueGenerator generator in generators)
            {
                if (generator.CanGenerate(type))
                {
                    object o = generator.Generate(new GeneratorContext(new Random(), type, this));
                    if (o != null)
                    {
                        return o;
                    }
                    else
                    {
                        Console.WriteLine("Create object exception");
                    }
                }
            }
            return Generate(type);
        }

        private static object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
            
                // Для типов-значений вызов конструктора по умолчанию даст default(T).
                return Activator.CreateInstance(t);
            else
                // Для ссылочных типов значение по умолчанию всегда null.
                return null;
        }
    }
}
