using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercises
{
    public struct Time
    {
        public int Hour { get; }
        public int Minute { get; }

        public Time(int hour, int minute)
        {
            if ((hour < 0 || hour > 23) || (minute < 0 || minute > 59))
            {
                throw new ArgumentOutOfRangeException("Hour cannot be less than 0 or greater than 23 and minute cannot be less than 0 or greater than 59");
            }
            Hour = hour;
            Minute = minute;
        }

        public override string ToString()
        {
            return $"{Hour:00}:{Minute:00}";
        }
    }
}
