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

        public void InsertCarDetails(string marke, string seriennummer, string typ)
        {
        }
    }
}
