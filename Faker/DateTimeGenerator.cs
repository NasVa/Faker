using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generators
{
    public class DateTimeGenerator : AbstractGenerator
    {
        public DateTimeGenerator()
        {
            DataType = typeof(DateTime);
        }

        public override object Generate()
        {
            int year = Random.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year);
            int month = Random.Next(DateTime.MinValue.Month, DateTime.MaxValue.Month);
            int day = Random.Next(DateTime.MinValue.Day, DateTime.MaxValue.Day);
            int hour = Random.Next(24);
            int minutes = Random.Next(60);
            int seconds = Random.Next(60);
            int milliseconds = Random.Next(1000);
            return new DateTime(year, month, day, hour, minutes, seconds, milliseconds);
        }
    }
}
