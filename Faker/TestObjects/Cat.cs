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
        Adress adress;
        Food food;

        public Cat(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Cat(string name, int age, bool isTrue, string city, string street, int num)
        {
            this.name = name;
            this.age = age;
            this.isTrue = isTrue;
            this.adress = Adress.newAdress(city, street, num);
        }

    }
}
