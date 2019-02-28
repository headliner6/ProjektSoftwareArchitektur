using System.Collections.Generic;
using System.Linq;
using CarRent.API.CustomerManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CarRent.API.CustomerManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        // GET: api/Cusomter
        [HttpGet]
        public IEnumerable<CustomerDto> GetAllCustomerDtos()
        {
            IReadOnlyList<Customer> customers = _customerService.GetAll();
            return customers.Select(c => new CustomerDto(c.Kundennummer, c.Vorname, c.Nachname, c.Telefonnummer, c.Adresse.Strasse, c.Adresse.Strassennummer, c.Adresse.PLZ, c.Adresse.Ort));
        }

        // GET: api/Cusomter/5
        [HttpGet("{kundennummer}", Name = "GetCustomerByCustomernumber")]
        public string Get(int kundennummer)
        {
            return "value";
        }

        // POST: api/Cusomter
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            //_customerService.InsertCustomerDetails("M.", "W.", "+41678787977", "Teststrasse", "25", "9000", "St. Gallen");
            _customerService.InsertCustomerDetails(customer.Vorname, customer.Nachname, customer.Telefonnummer, customer.Adresse.Strasse, customer.Adresse.Strassennummer, customer.Adresse.PLZ, customer.Adresse.Ort);
        }

        // PUT: api/Cusomter/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
