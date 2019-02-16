using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.API.CustomerManagement.Domain
{
    public interface ICustomerRepository
    {
        IReadOnlyList<Customer> GetAll();
    }
}
