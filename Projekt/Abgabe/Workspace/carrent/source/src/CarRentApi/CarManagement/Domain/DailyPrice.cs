using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.API.CarManagement.Domain
{
    public class DailyPrice
    {
        public string Currency { get; }
        public decimal Price { get; }
        public DateTime DateTime { get; }

        public DailyPrice(string currency, decimal price)
        {
            this.DateTime = DateTime.Now;
            this.Currency = currency;
            this.Price = price;

        }
    }
}
