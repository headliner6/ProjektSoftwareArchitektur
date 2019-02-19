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
        [HttpGet("{autoKlasse}", Name = "GetCarClass")]
        public IEnumerable<Car> GetCarClasses()
        {
            return null;
        }

        // POST: api/Car
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _carService.InsertCarDetails("Porsche", "6574687WERWR", "Sport", "Silber");
        }

        [HttpPut("{seriennummer}")]
        public void AutoVermietet(string seriennummer)
        {
            _carService.AutoVermietet(seriennummer, true);
        }


        // PUT: api/Car/5
        [HttpPut("{marke}")] // TODO: Parameter "Marke", "Seriennummer", "Typ", "Farbe" soll von der Angular App übergeben werden
        public void Put(int marke, [FromBody] string value)
        {
        }
        
        [HttpPut("{id}")]
        public ActionResult UpdateCarDetails(int id, [FromBody]CarDto carModel)
        {
            // get car via carservice (filter int id)
            // wenn nicht gefunden -> return NotFound();
            // map dto -> car
            //_carService.AutoVermietet(id);
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
