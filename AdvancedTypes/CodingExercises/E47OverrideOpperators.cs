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
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(
                    "Hour is out of range of 0-23");
            }
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(
                    "Minute is out of range of 0-59");
            }
            Hour = hour;
            Minute = minute;
        }

        public override string ToString() =>
            $"{Hour.ToString("00")}:{Minute.ToString("00")}";

        public static bool operator !=(Time left, Time right) => (left.Hour != right.Hour && left.Minute != right.Minute);
        public static bool operator ==(Time left, Time right) => (left.Hour == right.Hour && left.Minute == right.Minute);

        public static Time operator +(Time left, Time right)
        {
            var hour = left.Hour + right.Hour;
            var minute = left.Minute + right.Minute;
            if (minute >= 60)
            {
                minute -= 60;
                hour++;
            }
            if (hour >= 24)
            {
                hour -= 24;
            }
            return new Time(hour, minute);
        }
    }
}
