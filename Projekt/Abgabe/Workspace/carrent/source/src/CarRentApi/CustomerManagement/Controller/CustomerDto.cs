using CarRent.API.CustomerManagement.Domain;
namespace CarRent.API.CustomerManagement.Controller
{
    public class CustomerDto
    {
        public string Vorname { get; }
        public string Nachname { get; }
        public int Kundennummer { get; }
        public string Telefonnummer { get; }

        public Adresse Adresse { get; }
        public string Strasse { get; }
        public string Strassennummer { get; }
        public int PLZ { get; }
        public string Ort { get; }

        public CustomerDto(string vorname, string nachname, string telefonnummer, Adresse adresse, string strasse, string strassennummer, int plz, string ort)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Telefonnummer = telefonnummer;
            this.Adresse = adresse;
            this.Strasse = strasse;
            this.Strassennummer = strassennummer;
            this.PLZ = plz;
            this.Ort = ort;
        }
    }
}
