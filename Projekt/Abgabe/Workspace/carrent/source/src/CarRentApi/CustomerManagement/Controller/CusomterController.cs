using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.API.CustomerManagement.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.API.CustomerManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CusomterController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CusomterController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        // GET: api/Cusomter
        [HttpGet]
        public IEnumerable<string> Get()
        {
            IReadOnlyList<Customer> customers = _customerService.GetAll();
            //return customers.Select(c => new CustomerDto());
            return null;
        }

        // GET: api/Cusomter/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cusomter
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
