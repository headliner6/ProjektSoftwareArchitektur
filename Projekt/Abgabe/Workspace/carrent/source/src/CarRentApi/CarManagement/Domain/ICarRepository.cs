using System.Collections.Generic;

namespace CarRent.API.CarManagement.Domain
{
    public interface ICarRepository
    {
        IReadOnlyList<Car> GetAll();

        void InsertCarDetails(string marke, string seriennummer, string typ, string farbe);

        void AutoVermietet(string seriennummer, bool vermietet);
    }
}
