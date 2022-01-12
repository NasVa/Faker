using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.TestObjects
{
    class Food
    {
        public String name;
        private bool isTrue;
        public int num;
        private int num2;
        public int publicField;
        public float someFloat { get; set; }

        public Food(String name, int num)
        {
            this.name = name;
            this.num = num;
        }

        public Food(String name, bool isTrue, int num)
        {
            this.name = name;
            this.isTrue = isTrue;
            this.num = num;
        }

        public void setNum2(int num2)
        {
            this.num2 = num2;
        }

    }
}
