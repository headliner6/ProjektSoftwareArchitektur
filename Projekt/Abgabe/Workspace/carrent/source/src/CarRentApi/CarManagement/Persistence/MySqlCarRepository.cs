using System;
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

        public void AutoVermietet(string seriennummer, bool vermietet)
        {
            _mySqlConnection.Open();
            using (var cmd = _mySqlConnection.CreateCommand())
            {
                cmd.CommandText = "UPDATE Cars SET Vermietet = @vermietet WHERE Seriennummer = @seriennummer";
                cmd.Parameters.AddWithValue("@vermietet", vermietet);
                cmd.Parameters.AddWithValue("@seriennummer", seriennummer);
                cmd.ExecuteNonQuery();
            }
        }

        public IReadOnlyList<Car> GetAllCars()
        {
            var cars = new List<Car>();
            _mySqlConnection.Open();
            using (var cmd = _mySqlConnection.CreateCommand())
            {
                cmd.CommandText =
                    "SELECT * FROM (carrentdb.Cars INNER JOIN carrentdb.CarClass ON Cars.FK_CarClassId = CarClass.CarClassId) INNER JOIN carrentdb.DailyPrice ON CarClass.FK_DailyPriceId = DailyPrice.DailyPriceId";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dailyPrice = new DailyPrice(
                            reader.GetString("Waehrung"),
                            reader.GetDecimal("Preis")
                            );
                        
                        var carClass = new CarClass(
                            (AutoKlasse)Enum.Parse(typeof(AutoKlasse), reader.GetString("CarClass")),
                            dailyPrice
                            );

                        cars.Add(new Car(
                            reader.GetString("Marke"),
                            reader.GetString("Seriennummer"),
                            reader.GetString("Farbe"),
                            carClass
                            ));
                    }
                }
                return cars;
            }
        }

        public void InsertCarDetails(string marke, string seriennummer, string farbe)
        {
            throw new NotImplementedException();
        }

        //public void InsertCarDetails(string marke, string seriennummer, string farbe)
        //{
        //    _mySqlConnection.Open();
        //    using (var cmd = _mySqlConnection.CreateCommand())
        //    {
        //    }
        //    _mySqlConnection.Close();
        //}
    }
}
