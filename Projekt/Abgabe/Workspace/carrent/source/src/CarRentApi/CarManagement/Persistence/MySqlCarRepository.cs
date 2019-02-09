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
            _mySqlConnection.Open();
            using (_mySqlConnection.BeginTransaction())
            {
                return null;
            }
        }
    }
}
