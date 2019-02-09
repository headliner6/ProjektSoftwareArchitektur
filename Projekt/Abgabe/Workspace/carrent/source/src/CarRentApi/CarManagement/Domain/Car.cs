namespace CarRent.API.CarManagement.Domain
{
    public class Car
    {
        public string Marke { get; }
        public string Seriennummer { get; }
        public string Typ { get; }
        public string Farbe { get; }
        public bool Vermietet { get; }
        public Car(string marke, string seriennummer, string typ, string farbe)
        {
            this.Marke = marke;
            this.Seriennummer = seriennummer;
            this.Typ = typ;
            this.Farbe = farbe;
            this.Vermietet = false;
        }


    }
}
