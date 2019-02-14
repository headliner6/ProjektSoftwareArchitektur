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
    }
}
