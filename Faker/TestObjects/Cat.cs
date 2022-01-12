using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.TestObjects
{
    [Serializable]
    class Cat
    {
        
        public String name;
        public int age;
        public bool isTrue;
        private short someShort;

        public Food food;

        public Cat(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Cat(string name, int age, bool isTrue, Food food)
        {
            this.name = name;
            this.age = age;
            this.isTrue = isTrue;
            this.food = food;
        }

    }
}
