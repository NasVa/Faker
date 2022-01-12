using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.TestObjects
{
    class Cat
    {
        String name;
        int age;
        bool isTrue;
        short someShort;
        Food food;

        public Cat(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Cat(string name, int age, bool isTrue, string city, string street, int num, Food food)
        {
            this.name = name;
            this.age = age;
            this.isTrue = isTrue;
            this.food = food;
        }

    }
}
