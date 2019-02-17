using System;
using System.Collections.Generic;
using CarRent.API.CarManagement.Domain;

namespace CarRent.API.CarManagement.Persistence
{
    public class CarRepository : ICarRepository
    {
        private readonly List<Car> _cars;

        public CarRepository()
        {
            this._cars = new List<Car>();
        }

        public void AutoVermietet(string seriennummer, bool vermietet)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Car> GetAll()
        {
            _cars.Add(new Car("VW", "123", "Sport", "Blau"));
            _cars.Add(new Car("BMW", "456", "Luxus", "Gruen"));
            return _cars;
        }

        public void InsertCarDetails(string marke, string seriennummer, string typ, string farbe)
        {
            _cars.Add(new Car(marke, seriennummer, typ, farbe));
        }
    }
}
