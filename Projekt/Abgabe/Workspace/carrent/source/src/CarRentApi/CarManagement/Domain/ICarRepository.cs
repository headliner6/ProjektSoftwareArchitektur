using System.Collections.Generic;

namespace CarRent.API.CarManagement.Domain
{
    public interface ICarRepository
    {
        IReadOnlyList<Car> GetAll();
    }
}
