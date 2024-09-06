using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercises
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MustBeLargerThanAttribute : Attribute
    {
        public int Min { get; }

        public MustBeLargerThanAttribute(int min)
        {
            Min = min;
        }
    }

    public class Validator
    {
        public bool Validate(object obj)
        {
            var type = obj.GetType();
            var propertiesToValidate = type.GetProperties().Where(property => Attribute.IsDefined(property, typeof(MustBeLargerThanAttribute)));
            foreach (var property in propertiesToValidate)
            {
                object? propertyValue = property.GetValue(obj);
                if (propertyValue is not int)
                {
                    throw new InvalidOperationException($"The attribute {nameof(MustBeLargerThanAttribute)} can only be applied to properties of type int");
                }
                var value = (int)propertyValue;
                var attribute = (MustBeLargerThanAttribute)property.GetCustomAttributes(typeof(MustBeLargerThanAttribute), true).First();
                if (value <= attribute.Min)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
