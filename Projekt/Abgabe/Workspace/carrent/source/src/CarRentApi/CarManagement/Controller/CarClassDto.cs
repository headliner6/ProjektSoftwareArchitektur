using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.API.CarManagement.Domain;

namespace CarRent.API.CarManagement.Controller
{
    public class CarClassDto
    {
        public Car Car { get;}
        public DailyPrice DailyPrice { get; }
        public string AutoKlasse { get; }

        public CarClassDto(Car car, DailyPrice dailyPrice, string autoKlasse)
        {
            this.Car = car;
            this.DailyPrice = dailyPrice;
            this.AutoKlasse = autoKlasse;
        }
    }
}
