using System.Collections.Generic;

namespace CarRent.API.CustomerManagement.Domain
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public IReadOnlyList<Customer> GetAll()
        {
            return this._customerRepository.GetAll();
        }
    }
}
