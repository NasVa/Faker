using System;

namespace Faker
{
    class Program
    {
        struct cat
        {
            public string name;
            public string asa;
            public int age;
        }
        struct mew{
            public string Name;
            public int age;
            public string something;
            public bool s;
            public float b;
            public cat c;
        }
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            mew NewMew = new mew();
            NewMew = faker.Create<mew>();
            Console.WriteLine(NewMew.age);
            Console.WriteLine(NewMew.b);
            Console.WriteLine()
        }
    }
}
