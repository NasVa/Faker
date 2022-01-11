using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.TestObjects
{
    class Adress
    {
        private string city;
        private string street;
        private int number;

        private Adress(string city, string street, int number)
        {
            this.city = city;
            this.street = street;
            this.number = number;
        }

        private static bool isValidateStreet(string street)
        {
            List<string> streets = new List<string> { "1", "2", "3" };
            return streets.Contains(street);
        }
        public static Adress newAdress(string city, string street, int number)
        {
            if (isValidateStreet(street))
            {
                return new Adress(city, street, number);
            }
            else
            {
                Console.WriteLine("Invalid street");
                return null;
            }
        }
    
    }
}
