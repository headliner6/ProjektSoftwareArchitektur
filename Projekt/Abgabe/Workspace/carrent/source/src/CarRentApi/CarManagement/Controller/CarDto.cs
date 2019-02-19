using System.Collections.Generic;

namespace CarRent.API.CarManagement.Controller
{
    public class CarDto
    {
        public string Marke { get; }
        public string Seriennummer { get; }
        public string Farbe { get;  }
        public string AutoKlasse { get; }
        public decimal TagesPreis { get; }
        public bool Vermietet { get; }
        public CarDto(string marke, string seriennummer, string farbe, string autoKlasse, decimal tagesPreis, bool vermietet)
        {
            Marke = marke;
            Seriennummer = seriennummer;
            Farbe = farbe;
            AutoKlasse = autoKlasse;
            TagesPreis = tagesPreis;
            Vermietet = vermietet;
        }
    }
}
