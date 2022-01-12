using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class DateTimeGenerator : IValueGenerator
    {
        public DateTimeGenerator()
        {
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(DateTime);
        }

        public object Generate(GeneratorContext context)
        {
            int year = context.Random.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year);
            int month = context.Random.Next(DateTime.MinValue.Month, DateTime.MaxValue.Month);
            int day = context.Random.Next(DateTime.MinValue.Day, DateTime.MaxValue.Day);
            int hour = context.Random.Next(24);
            int minutes = context.Random.Next(60);
            int seconds = context.Random.Next(60);
            int milliseconds = context.Random.Next(1000);
            return new DateTime(year, month, day, hour, minutes, seconds, milliseconds);
        }
    }
}
