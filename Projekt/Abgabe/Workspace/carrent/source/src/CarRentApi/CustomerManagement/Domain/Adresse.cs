using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.API.CustomerManagement.Domain
{
    public class Adresse
    {
        public string Strasse { get; }
        public string Strassennummer { get; }
        public string PLZ { get; }
        public string Ort { get; }

        public Adresse(string strasse, string strassennummer, string plz, string ort)
        {
            this.Strasse = strasse;
            this.Strassennummer = strassennummer;
            this.PLZ = plz;
            this.Ort = ort;
        }
    }
}
