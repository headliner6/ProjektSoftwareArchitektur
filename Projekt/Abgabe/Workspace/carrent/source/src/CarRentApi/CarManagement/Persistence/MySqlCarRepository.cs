using System;
using System.Collections.Generic;
using System.Data;
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
                    "SELECT * FROM (carrentdb.Cars INNER JOIN carrentdb.CarClass ON Cars.FK_CarClassId = CarClass.CarClassId)" +
                    "INNER JOIN carrentdb.DailyPrice ON CarClass.FK_DailyPriceId = DailyPrice.DailyPriceId";
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
                            reader.GetBoolean("Vermietet"),
                            carClass
                            ));
                    }
                }
                return cars;
            }
        }

        public IReadOnlyList<Car> GetAllCars(string autoKlasse)
        {
            var cars = new List<Car>();
            _mySqlConnection.Open();
            using (var cmd = _mySqlConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM(carrentdb.Cars INNER JOIN carrentdb.CarClass ON Cars.FK_CarClassId = CarClass.CarClassId)" +
                "INNER JOIN carrentdb.DailyPrice ON CarClass.FK_DailyPriceId = DailyPrice.DailyPriceId WHERE CarClass.CarClass=@autoKlasse";
                cmd.Parameters.AddWithValue("@autoKlasse", autoKlasse);
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
                            reader.GetBoolean("Vermietet"),
                            carClass
                            ));
                    }
                }
                return cars;
            }
        }

        public void InsertCarDetails(string waehrung, decimal preis, string seriennummer, string farbe, string marke, string autoKlasse)
        {
            _mySqlConnection.Open();
            using (var cmd = _mySqlConnection.CreateCommand())
            {
                cmd.CommandText = "InstertIntoCar";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iWaehrung", waehrung);
                cmd.Parameters.AddWithValue("@iPreis", preis);
                cmd.Parameters.AddWithValue("@iCarClass", autoKlasse);
                cmd.Parameters.AddWithValue("@iMarke", marke);
                cmd.Parameters.AddWithValue("@iSeriennummer", seriennummer);
                cmd.Parameters.AddWithValue("@iFarbe", farbe);
                cmd.ExecuteNonQuery();
            }
            _mySqlConnection.Close();
        }
    }
}
