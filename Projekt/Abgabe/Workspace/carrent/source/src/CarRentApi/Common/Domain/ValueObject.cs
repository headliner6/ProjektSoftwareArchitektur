using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.API.Common.Domain
{
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (ReferenceEquals(valueObject, null))
            {
                return false;
            }

            var properties = GetType().GetProperties();
            var isEqual = true;
            foreach (var property in properties)
            {
                var valueLeft = property.GetValue(this);
                var valueRight = property.GetValue(obj);
                isEqual &= valueLeft.Equals(valueRight);
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            var properties = GetType().GetProperties();
            var hashCode = 0;
            unchecked
            {
                foreach (var property in properties)
                {
                    var valueLeft = property.GetValue(this);
                    hashCode ^= valueLeft.GetHashCode();
                }
            }

            return hashCode;
        }

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return (a != b);
        }
    }
}
