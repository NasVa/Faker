using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class StringGenerator : IValueGenerator
    {
        private string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public StringGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(string);
        }

        public object Generate(GeneratorContext context)
        {
            string newStr = "";
            int newStrLength = context.Random.Next(256);
            for(int i = 0; i < newStrLength; i++)
            {
                newStr += str[context.Random.Next(str.Length)];
            }
            return newStr;
            
        }
    }
}
