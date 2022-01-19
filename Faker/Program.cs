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

        class User
        {
            public string name;
            public int age { get; set; }
            float money = 10.05f;
            public List<Dog> dogs;
            public Profile profile;

            public User()
            {

            }
        }

        class Dog
        {
            public String name;
            public User owner;

        }

        class Profile
        {
            public String address;
            public Profile()
            {

            }
            public Profile(string addr)
            {
                //throw new Exception();
                //address = addr;
            }
        }

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

            List<Type> types = new List<Type>{
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
            };
            
            foreach(Type type in types){
                object newObj = faker.Create(type);
                Console.WriteLine("{0} : {1}", type, JsonConvert.SerializeObject(newObj, Formatting.Indented));
            }

            DateTime dataTime = faker.Create<DateTime>();
            Console.WriteLine("DateTime : {0}", dataTime);

            List<int> intList = faker.Create<List<int>>();
            Console.WriteLine("List<int> : {0}", JsonConvert.SerializeObject(intList, Formatting.Indented));


            //класс имеет только приватный конструктор
            Adress adress = faker.Create<Adress>();  
            
            //класс имеет несколько конструкторов с параметрами
            Food food = faker.Create<Food>();
            Console.WriteLine(JsonConvert.SerializeObject(food, Formatting.Indented));

            //иерархия классов
            Cat cat = faker.Create<Cat>();
            Console.WriteLine(JsonConvert.SerializeObject(cat, Formatting.Indented));

            /*
            List<int> intList = faker.Create<List<int>>();
            Console.WriteLine(JsonConvert.SerializeObject(intList, Formatting.Indented));
            */

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

            Console.WriteLine("User:");
            User u = faker.Create<User>();
            Console.WriteLine(JsonConvert.SerializeObject(u, Formatting.Indented));

        }

        

                
        
    }
}

// Console.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));