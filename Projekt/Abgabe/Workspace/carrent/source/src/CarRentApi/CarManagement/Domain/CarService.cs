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

        public IReadOnlyList<Car> GetAll()
        {
            return _carRepository.GetAll();
        }
    }
}
