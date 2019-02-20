using System.Collections.Generic;

namespace CarRent.API.CarManagement.Domain
{
    public interface ICarService
    {
        IReadOnlyList<Car> GetAllCars();
        IReadOnlyList<Car> GetAllCars(string autoKlasse);
        void InsertCarDetails(string waehrung, decimal preis, string seriennummer, string farbe, string marke, string autoKlasse);
        void AutoVermietet(string seriennummer, bool vermietet);
    }
}
