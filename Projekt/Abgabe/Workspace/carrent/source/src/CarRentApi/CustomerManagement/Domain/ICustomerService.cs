using System.Collections.Generic;

namespace CarRent.API.CustomerManagement.Domain
{
    public interface ICustomerService
    {
        IReadOnlyList<Customer> GetAll();
        void InsertCustomerDetails(string vorname, string nachname, string telefonnummer, string strasse, string strassennummer, string plz, string ort);
    }
}
