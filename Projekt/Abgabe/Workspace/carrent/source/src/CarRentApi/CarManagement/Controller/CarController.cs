using System.Collections.Generic;
using System.Linq;
using CarRent.API.CarManagement.Domain;
using CarRent.API.CarManagement.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CarRent.API.CarManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            this._carService = carService;
        }


        // GET: api/Car
        [HttpGet]
        public IEnumerable<CarDto> Get()
        {
            IReadOnlyList<Car> cars = _carService.GetAll();
            return cars.Select(c => new CarDto(c.Marke, c.Seriennummer, c.Typ, c.Vermietet));

            //List<CarDto> carDtos = new List<CarDto>();
            //foreach (var c in cars)
            //{
            //    var carDto = new CarDto(c.Marke, c.Seriennummer, c.Typ, c.Vermietet);
            //    carDtos.Add(carDto);
            //}
            //return carDtos;

        }

        // GET: api/Car/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Car
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/Car/5
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
