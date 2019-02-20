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

        public IReadOnlyList<Car> GetAllCars()
        {
            return null;
        }

        public IReadOnlyList<Car> GetAllCars(string autoKlasse)
        {
            throw new NotImplementedException();
        }

        public void InsertCarDetails(string waehrung, decimal preis, string seriennummer, string farbe, string marke, string autoKlasse)
        {
            throw new NotImplementedException();
        }
    }
}
