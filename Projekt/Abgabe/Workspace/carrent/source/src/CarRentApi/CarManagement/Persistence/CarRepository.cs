using System;
using System.Collections.Generic;
using CarRent.API.CarManagement.Domain;

namespace CarRent.API.CarManagement.Persistence
{
    public class CarRepository : ICarRepository
    {
        public IReadOnlyList<Car> GetAll()
        {
            var _cars = new List<Car>();
            _cars.Add(new Car("VW", "123", "Sport", "Blau"));
            _cars.Add(new Car("BMW", "456", "Luxus", "Gruen"));
            return _cars;
        }
    }
}
