using System.Collections.Generic;
using System.Linq;
using CarRent.API.CarManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using CarRent.API.CustomerManagement.Controller;
using System;

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
        [HttpGet(Name = "GetAllCars")]
        public IEnumerable<CarDto> GetAllCarDtos()
        {
            IReadOnlyList<Car> cars = _carService.GetAllCars();
            return cars.Select(c => new CarDto(c.Marke, c.Seriennummer, c.Farbe, c.AutoKlasse.AutoKlasse.ToString(),c.AutoKlasse.DailyPrice.Price,c.Vermietet));
            
            //List<CarDto> carDtos = new List<CarDto>();
            //foreach (var c in cars)
            //{
            //    var carDto = new CarDto(c.Marke, c.Seriennummer, c.Typ, c.Vermietet);
            //    carDtos.Add(carDto);
            //}
            //return carDtos;

        }

        // GET: api/Car
        [HttpGet("{autoKlasse}", Name = "GetAllCarClass")]
        public IEnumerable<CarClassDto> GetAllCarClassDtos(string autoKlasse)
        {
            IReadOnlyList<Car> cars = _carService.GetAllCars(autoKlasse);
            return cars.Select(c => new CarClassDto(c));
        }

        // POST: api/Car
        [HttpPost]
        public void Post(/*[FromBody] string value*/)
        {
            _carService.InsertCarDetails("EUR", (decimal)1.11, "EU5566", "Silber", "Porsche", "Luxus");
        }

        [HttpPut("{seriennummer}")]
        public void AutoVermietet(string seriennummer)
        {
            _carService.AutoVermietet(seriennummer, true);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
