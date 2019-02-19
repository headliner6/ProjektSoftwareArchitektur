using System.Collections.Generic;

namespace CarRent.API.CarManagement.Domain
{
    public interface ICarService
    {
        IReadOnlyList<Car> GetAllCars();
        void InsertCarDetails(string marke, string seriennummer, string typ, string farbe);
        void AutoVermietet(string seriennummer, bool vermietet);
    }
}
