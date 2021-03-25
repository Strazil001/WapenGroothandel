using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    public class Leverancier : Entiteit
    {
        private string _BTWNummer;
        private string _rekeningNummer;

        public Leverancier()
        {

        }

        public Leverancier(Guid eenID, string eenNaam, string eenVoornaam, string eenTelNummer, string eenEmail, string eenContactpersoon, string eenOpmerking, string eenBTWNummer, string eenRekeningnummer) : base(eenID, eenNaam, eenVoornaam, eenTelNummer, eenEmail, eenContactpersoon, eenOpmerking)
        {
            this.BTWNummer = eenBTWNummer;
            this.RekeningNummer = eenRekeningnummer;
        }
        public string BTWNummer { get => _BTWNummer; set => _BTWNummer = value; }
        public string RekeningNummer { get => _rekeningNummer; set => _rekeningNummer = value; }

        public override string ToString() //Stringweergave met naam en contactpersoon.
        {
            return $"Naam: {this.Naam + " " + Environment.NewLine}Contactpersoon: {this.Contactpersoon + Environment.NewLine}";
        }
    }
}
