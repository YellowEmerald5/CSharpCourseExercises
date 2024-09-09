using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercises
{
    public struct TimeX
    {
        public int Hour { get; }
        public int Minute { get; }

        public TimeX(int hour, int minute)
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

        public static bool operator ==(TimeX left, TimeX right)
        {
            return left.Equals(left.Hour == right.Hour && left.Minute == right.Minute);
        }

        public static bool operator !=(TimeX left, TimeX right)
        {
            return left.Equals(!(left.Hour == right.Hour && left.Minute == right.Minute));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hour, Minute);
        }
    }
}
