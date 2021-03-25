using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    public class Entiteit
    {
        private Guid _id;
        private string _naam;
        private string _voornaam;
        private string _telNummer;
        private string _EMail;
        private string _contactpersoon;
        private string opmerking;

        public Entiteit()
        {
            this.ID = Guid.NewGuid();
            this.Naam = "";
            this.Voornaam = "";
            this.TelNummer = "";
            this.EMail = "";
            this.Contactpersoon = "";
            this.Opmerking = "";
        }

        public Entiteit(Guid eenID, string eenNaam, string eenVoornaam, string eenTelNummer, string eenEmail, string eenContactpersoon, string eenOpmerking)
        {
            this.ID = eenID;
            this.Naam = eenNaam;
            this.Voornaam = eenVoornaam;
            this.TelNummer = eenTelNummer;
            this.EMail = eenEmail;
            this.Contactpersoon = eenContactpersoon;
            this.Opmerking = eenOpmerking;
        }

        public Guid ID { get => _id; set => _id = value; }
        public string Naam { get => _naam; set => _naam = value; }
        public string Voornaam { get => _voornaam; set => _voornaam = value; }
        public string TelNummer { get => _telNummer; set => _telNummer = value; }
        public string EMail { get => _EMail; set => _EMail = value; }
        public string Contactpersoon { get => _contactpersoon; set => _contactpersoon = value; }
        public string Opmerking { get => opmerking; set => opmerking = value; }

        public override string ToString() //Deze methode zal nooit worden opgeroepen voor entiteit!
        {
            return "";
        }
    }
}
