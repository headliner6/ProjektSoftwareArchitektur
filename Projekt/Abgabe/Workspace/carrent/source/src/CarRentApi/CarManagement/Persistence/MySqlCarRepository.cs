using System.Collections.Generic;
using CarRent.API.CarManagement.Domain;
using MySql.Data.MySqlClient;

namespace CarRent.API.CarManagement.Persistence
{
    public class MySqlCarRepository : ICarRepository
    {
        private readonly MySqlConnection _mySqlConnection;
        public MySqlCarRepository(string connectionString)
        {
            _mySqlConnection = new MySqlConnection(connectionString);
        }


        public IReadOnlyList<Car> GetAll()
        {
            var cars = new List<Car>();
            _mySqlConnection.Open();
            using (var cmd = _mySqlConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM CarRentDB.Cars";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cars.Add(new Car(
                            reader.GetString("Marke"),
                            reader.GetString("Seriennummer"),
                            reader.GetString("Typ"),
                            reader.GetString("Farbe")
                            ));
                    }
                }
                return cars;
            }
        }

        public void InsertCarDetails(string marke, string seriennummer, string typ, string farbe)
        {
            _mySqlConnection.Open();
            using (var cmd = _mySqlConnection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Cars(marke, seriennummer, typ, farbe) VALUES (@marke, @seriennummer, @typ, @farbe)";
                cmd.Parameters.AddWithValue("@marke", marke);
                cmd.Parameters.AddWithValue("@seriennummer", seriennummer);
                cmd.Parameters.AddWithValue("@typ", typ);
                cmd.Parameters.AddWithValue("@farbe", farbe);
                cmd.ExecuteNonQuery();
            }
            _mySqlConnection.Close();
        }
    }
}
