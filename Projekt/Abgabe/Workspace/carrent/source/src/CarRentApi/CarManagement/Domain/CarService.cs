using System.Collections.Generic;

namespace CarRent.API.CarManagement.Domain
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }

        public void AutoVermietet(string seriennummer, bool vermietet)
        {
            this._carRepository.AutoVermietet(seriennummer, vermietet);
        }

        public IReadOnlyList<Car> GetAll()
        {
            return this._carRepository.GetAll();
        }

        public void InsertCarDetails(string marke, string seriennummer, string typ, string farbe)
        {
            this._carRepository.InsertCarDetails(marke, seriennummer, typ, farbe);
        }
    }
}
