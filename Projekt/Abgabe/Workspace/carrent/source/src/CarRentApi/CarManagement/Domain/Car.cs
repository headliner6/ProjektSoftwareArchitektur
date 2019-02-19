namespace CarRent.API.CarManagement.Domain
{
    public class Car
    {
        public string Marke { get; }
        public string Seriennummer { get; }
        public string Farbe { get; }
        public bool Vermietet { get; }
        public CarClass AutoKlasse { get; }

        public Car(string marke, string seriennummer, string farbe, CarClass autoKlasse)
        {
            this.Marke = marke;
            this.Seriennummer = seriennummer;
            this.Farbe = farbe;
            this.AutoKlasse = autoKlasse;
            this.Vermietet = false;
        }


    }
}
