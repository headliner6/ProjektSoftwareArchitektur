using CarRent.API.CustomerManagement.Domain;
namespace CarRent.API.CustomerManagement.Controller
{
    public class CustomerDto
    {
        public string Vorname { get; }
        public string Nachname { get; }
        public int Kundennummer { get; }
        public string Telefonnummer { get; }
        public string Strasse { get; }
        public string Strassennummer { get; }
        public string PLZ { get; }
        public string Ort { get; }

        public CustomerDto(int kundennummer, string vorname, string nachname, string telefonnummer, string strasse, string strassennummer, string plz, string ort)
        {
            this.Kundennummer = kundennummer;
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Telefonnummer = telefonnummer;
            this.Strasse = strasse;
            this.Strassennummer = strassennummer;
            this.PLZ = plz;
            this.Ort = ort;
        }
    }
}
