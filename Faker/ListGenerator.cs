using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class ListGenerator : IValueGenerator
    {
        public ListGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(List<>);
        }

        public object Generate(GeneratorContext context)
        {
            int num = context.Random.Next(20);
            IList list =  (IList)Activator.CreateInstance(context.TargetType);
            Type elementType = context.TargetType.GetGenericArguments().Single();
            for (int i = 0; i < num; i++)
            {
                list.Add(context.Faker.Create(elementType));
            }
            return list;
        }

    }
}

