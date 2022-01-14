using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using Faker.TestObjects;
using Newtonsoft.Json;


namespace Faker
{
    class Program
    {
        
        struct Bar
        {
            public string name;
            public string color;
            public int age;

            public Bar(string name, string color, int age)
            {
                this.name = name;
                this.color = color;
                this.age = age;
            }

        }
        struct Foo
        {
            public string name;
            public int age;
            public bool s;
            public float b;
            public Bar bar;

            public Foo(string name, int age, bool s, float b, Bar bar)
            {
                this.name = name;
                this.age = age;
                this.s = s;
                this.b = b;
                this.bar = bar;
            }
        }

        

        static void Main(string[] args)
        {
            Faker faker = new Faker();

            byte b = faker.Create<byte>();
            int i = faker.Create<int>();
            long l = faker.Create<long>();
            sbyte sb = faker.Create<sbyte>();
            short sh = faker.Create<short>();
            uint ui = faker.Create<uint>();
            ulong ul = faker.Create<ulong>();
            ushort ush = faker.Create<ushort>();
            float f = faker.Create<float>();
            double d = faker.Create<double>();
            string str = faker.Create<string>();
            DateTime dataTime = faker.Create<DateTime>();
            bool bl = faker.Create<bool>();

            Foo foo = faker.Create<Foo>();
            Console.WriteLine(b);
            Console.WriteLine(i);
            Console.WriteLine(l);
            Console.WriteLine(sb);
            Console.WriteLine(sh);
            Console.WriteLine(ui);
            Console.WriteLine(ul);
            Console.WriteLine(ush);
            Console.WriteLine(f);
            Console.WriteLine(d);
            Console.WriteLine(str);
            Console.WriteLine(dataTime);
            Console.WriteLine(bl);

            //класс имеет только приватный конструктор
            Adress adress = faker.Create<Adress>();    
            //класс имеет несколько конструкторов с параметрами
            Food food = faker.Create<Food>();
            Console.WriteLine(JsonConvert.SerializeObject(food, Formatting.Indented));
            //иерархия классов
            Cat cat = faker.Create<Cat>();
            Console.WriteLine(JsonConvert.SerializeObject(cat, Formatting.Indented));

            List<int> intList = faker.Create<List<int>>();
            Console.WriteLine(JsonConvert.SerializeObject(intList, Formatting.Indented));

            ExceptionClass exceptionClass = faker.Create<ExceptionClass>();
            Console.WriteLine(JsonConvert.SerializeObject(exceptionClass, Formatting.Indented));

            //структуры
            Console.WriteLine("Bar:");
            Bar bar = faker.Create<Bar>();
            Console.WriteLine(JsonConvert.SerializeObject(bar, Formatting.Indented));

            Console.WriteLine("Foo:");
            Foo fo = faker.Create<Foo>();
            Console.WriteLine(JsonConvert.SerializeObject(fo, Formatting.Indented));

            ClassA a = faker.Create<ClassA>(); 

        }

        

                
        
    }
}

// Console.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));