using System.Collections.Generic;

namespace CarRent.API.CarManagement.Domain
{
    public interface ICarService
    {
        IReadOnlyList<Car> GetAll();
        void InsertCarDetails(string marke, string seriennummer, string typ, string farbe);
    }
}
