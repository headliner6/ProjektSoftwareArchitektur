using CarRent.API.CarManagement.Domain;
using System.Collections.Generic;

namespace CarRent.API.CarManagement.Controller
{
    public class CarDto
    {
        public string Marke { get; }
        public string Seriennummer { get; }
        public string Typ { get; }
        public string Farbe { get;  }
        public bool Vermietet { get; }
        public CarDto(string marke, string seriennummer, string typ, string farbe, bool vermietet)
        {
            Marke = marke;
            Seriennummer = seriennummer;
            Typ = typ;
            Farbe = farbe;
            Vermietet = vermietet;
        }
    }
}
