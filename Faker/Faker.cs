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
        List<Type> typesWithDefaultValues;
        List<ConstructorInfo> exeptionConstructors;
        List<Type> typesInProcess;
        public Faker()
        {
            random = new Random();
            generators = new List<IValueGenerator>()
            {
                loadPlugin("C:/Users/Анастасия/source/repos/Faker/BoolGeneratorPlugin/bin/Debug/net5.0/BoolGeneratorPlugin.dll", typeof(bool)),
                //new BoolGenerator(),
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
                loadPlugin("C:/Users/Анастасия/source/repos/Faker/DateTimeGeneratorPlugin/bin/Debug/net5.0/DateTimeGeneratorPlugin.dll", typeof(DateTime)),
                //new DateTimeGenerator(),
                new ListGenerator()
            };

            typesWithDefaultValues = new List<Type>
            {
                typeof(bool),
                typeof(byte),
                typeof(int),
                typeof(long),
                typeof(sbyte),
                typeof(short),
                typeof(uint),
                typeof(ulong),
                typeof(ushort),
                typeof(double),
                typeof(float),
                typeof(string),
                typeof(List<>)
            };
            exeptionConstructors = new List<ConstructorInfo>();
            typesInProcess = new List<Type>();
        }

        public IValueGenerator loadPlugin(string path, Type generatorType)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            var types = assembly.GetTypes();
            foreach (Type type in types)
            {
                Type[] interfaces = type.GetInterfaces();
                foreach (Type typeInterface in interfaces)
                {
                    if (typeInterface.FullName == typeof(IValueGenerator).FullName)
                    {
                        //var instance = (IValueGenerator)Activator.CreateInstance(type);
                        var instance = assembly.CreateInstance(type.FullName) as IValueGenerator;
                        if (instance.CanGenerate(generatorType))
                        {
                            return instance;
                        }
                    }
                }
            }
            return null;
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
                    if (f.GetValue(newObj).Equals(GetDefaultValue(f.FieldType)))
                    {
                        object newParam = Create(f.FieldType);
                        if (newParam != null)
                        {
                            f.SetValue(newObj, newParam);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                foreach(var p in type.GetProperties().Where(p => p.GetSetMethod() != null))
                {
                    //MethodInfo setMethod = p.GetSetMethod();
                    //if (setMethod != null)   // у свойства есть публичный сеттер 
                    //{
                    if (typesWithDefaultValues.Contains(p.PropertyType)){
                        if (p.GetValue(newObj).Equals(GetDefaultValue(p.PropertyType)))
                        {
                            p.SetValue(newObj, Create(p.PropertyType));
                        }
                    }
                    //}
                }
            }
            catch(Exception e)
            {
                exeptionConstructors.Add(maxParamConstructor);
                Console.WriteLine("{0}: Constructor Exception", maxParamConstructor.Name);
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
                        return null;
                    }
                }
            }
            try
            {
                if (!typesInProcess.Contains(type))
                {
                    typesInProcess.Add(type);
                }
                else
                {
                    typesInProcess.Clear();
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("cyclic dependency");
                return null;
            }
            object obj = Generate(type);
            typesInProcess.Remove(type);
            return obj;
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
