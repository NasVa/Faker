using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators.PrimitiveTypesGenerators
{
    public class StringGenerator : AbstractGenerator
    {
        private string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public StringGenerator()
        {
            DataType = typeof(string);
        }

        public override object Generate()
        {
            string newStr = "";
            int newStrLength = Random.Next(256);
            for(int i = 0; i < newStrLength; i++)
            {
                newStr += str[Random.Next(str.Length)];
            }
            return newStr;
            
        }
    }
}
