using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.API.Common.Domain
{
    public interface IHandle<T>
        where T : IDomainEvent
    {
        void Handle(T domainEvent);
    }
}
