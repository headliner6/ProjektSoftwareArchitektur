using System.Collections.Generic;

namespace CarRent.API.CarManagement.Domain
{
    public interface ICarRepository
    {
        IReadOnlyList<Car> GetAllCars();

        void InsertCarDetails(string marke, string seriennummer, string farbe);

        void AutoVermietet(string seriennummer, bool vermietet);
    }
}
