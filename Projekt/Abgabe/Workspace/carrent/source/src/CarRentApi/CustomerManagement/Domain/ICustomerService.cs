using System.Collections.Generic;

namespace CarRent.API.CustomerManagement.Domain
{
    public interface ICustomerService
    {
        IReadOnlyList<Customer> GetAll();
    }
}
