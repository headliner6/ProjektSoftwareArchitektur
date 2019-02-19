using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.API.CarManagement.Domain
{
    public enum AutoKlasse
    {
        Luxus, Normal, Sport
    }
    public class CarClass
    {
        public AutoKlasse AutoKlasse { get; }
        public DailyPrice DailyPrice { get; }

        public CarClass(AutoKlasse autoKlasse, DailyPrice dailyPrice)
        {
            this.AutoKlasse = autoKlasse;
            this.DailyPrice = dailyPrice;
        }

    }
}
