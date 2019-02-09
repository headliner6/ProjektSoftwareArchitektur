using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.API.Common.Domain
{
    public abstract class Entity
    {
        public readonly Guid _id;

        protected Entity()
            : this(Guid.NewGuid())
        {
        }

        protected internal Entity(Guid inital)
        {
            _id = inital;
        }

        public Guid Id => _id;

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (Id == Guid.Empty || other.Id == Guid.Empty)
            {
                return false;
            }

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
    }
}
