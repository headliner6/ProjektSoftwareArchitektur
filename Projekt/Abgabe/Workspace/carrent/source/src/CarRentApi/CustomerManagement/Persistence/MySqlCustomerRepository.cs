using CarRent.API.CustomerManagement.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

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
                cmd.CommandText = "SELECT * FROM Customer INNER JOIN Adress ON Customer.CustomerId = Adress.AdressId";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer(
                            reader.GetInt32("CustomerId"),
                            reader.GetString("Vorname"),
                            reader.GetString("Nachname"),
                            reader.GetString("Telefonnummer"),
                            reader.GetString("Strasse"),
                            reader.GetString("Strassennummer"),
                            reader.GetString("PLZ"),
                            reader.GetString("Ort")
                            ));
                    }
                }
                return customers;
            }
        }
        
        public void InsertCustomerDetails(string vorname, string nachname, string telefonnummer, string strasse, string strassennummer, string plz, string ort)
        {
            try
            {
                _mySqlConnection.Open();
                using (var cmd = _mySqlConnection.CreateCommand())
                {
                    cmd.CommandText = "InsertIntoCustomer";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iVorname", vorname);
                    cmd.Parameters.AddWithValue("@iNachname", nachname);
                    cmd.Parameters.AddWithValue("@iTelefonnummer", telefonnummer);
                    cmd.Parameters.AddWithValue("@iStrasse", strasse);
                    cmd.Parameters.AddWithValue("@iStrassennummer", strassennummer);
                    cmd.Parameters.AddWithValue("@iPLZ", plz);
                    cmd.Parameters.AddWithValue("@iOrt", ort);
                    cmd.ExecuteNonQuery();
                }
                _mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                
            }
            
        }
    }
}
