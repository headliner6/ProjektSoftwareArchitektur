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

        public CarClassDto(Car car)
        {
            this.Car = car;
        }
    }
}
