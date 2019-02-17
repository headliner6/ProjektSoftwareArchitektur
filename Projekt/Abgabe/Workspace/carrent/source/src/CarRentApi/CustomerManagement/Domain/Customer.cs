using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.API.CustomerManagement.Domain
{
    public class Customer
    {
        public string Vorname { get; }
        public string Nachname { get; }
        public int Kundennummer { get; }
        public string Telefonnummer { get; }
        public Adresse Adresse { get; }

        public Customer(string vorname, string nachname, string telefonnummer, string strasse,string strassennummer, string plz, string ort)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Telefonnummer = telefonnummer;
            this.Adresse = new Adresse(strasse, strassennummer, plz, ort);
        }
    }
}
