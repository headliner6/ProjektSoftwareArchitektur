using CarRent.API.CustomerManagement.Domain;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CarRent.API.CustomerManagement.Persistence
{
    public class MySqlCustomerRepository : ICustomerRepository
    {
        private readonly MySqlConnection _mySqlConnection;
        public MySqlCustomerRepository(string connectionString)
        {
            _mySqlConnection = new MySqlConnection(connectionString);
        }


        public IReadOnlyList<Customer> GetAll()
        {
            var customers = new List<Customer>();
            _mySqlConnection.Open();
            using (var cmd = _mySqlConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Customer INNER JOIN Adress ON Customer.CustomerId = Adress.AdressID";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer(
                            reader.GetString("Vorname"),
                            reader.GetString("Nachname"),
                            reader.GetString("Telefonnummer"),
                            reader.GetString("Strasse"),
                            reader.GetString("Strassennummer"),
                            reader.GetInt32("PLZ"),
                            reader.GetString("Ort")
                            ));
                    }
                }
                return customers;
            }
        }

        //public void InsertCarDetails(string marke, string seriennummer, string typ, string farbe)
        //{
        //    _mySqlConnection.Open();
        //    using (var cmd = _mySqlConnection.CreateCommand())
        //    {
        //        cmd.CommandText = "INSERT INTO  VALUES (@, @, @, @)";
        //        cmd.Parameters.AddWithValue("@", marke);
        //        cmd.Parameters.AddWithValue("@", seriennummer);
        //        cmd.Parameters.AddWithValue("@", typ);
        //        cmd.Parameters.AddWithValue("@", farbe);
        //        cmd.ExecuteNonQuery();
        //    }
        //    _mySqlConnection.Close();
        //}
    }
}
