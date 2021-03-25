using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    class Personeel : Entiteit
    {
        private string _rijksregisterNummer;
        private DateTime _geboorteDatum;
        private string _functie;
        private string _gebruikersNaam;
        private string _wachtwoord;
        private char _geslacht;
        private decimal _loon;

        public Personeel() : base()
        {
            this.RijksregisterNummer = "";
            this.GeboorteDatum = DateTime.MinValue;
            this.Functie = "";
            this.GebruikersNaam = "";
            this.Wachtwoord = "";
            this.Geslacht = ' ';
            this.Loon = 0;
        }
        public Personeel(Guid eenID, string eenNaam, string eenVoornaam, string eenTelNummer, string eenEmail, string eenContactpersoon, string eenOpmerking, string eenRijksregisternummer, DateTime eenGeboortedatum, string eenFunctie, string eenGebruikersnaam, string eenWachtwoord, char eenGeslacht, decimal eenLoon) : base(eenID, eenNaam, eenVoornaam, eenTelNummer, eenEmail, eenContactpersoon, eenOpmerking)
        {
            this.RijksregisterNummer = eenRijksregisternummer;
            this.GeboorteDatum = eenGeboortedatum;
            this.Functie = eenFunctie;
            this.GebruikersNaam = eenGebruikersnaam;
            this.Wachtwoord = eenWachtwoord;
            this.Geslacht = eenGeslacht;
            this.Loon = eenLoon;
        }


        public string RijksregisterNummer { get => _rijksregisterNummer; set => _rijksregisterNummer = value; }
        public DateTime GeboorteDatum { get => _geboorteDatum; set => _geboorteDatum = value; }
        public string Functie { get => _functie; set => _functie = value; }
        public string GebruikersNaam { get => _gebruikersNaam; set => _gebruikersNaam = value; }
        public string Wachtwoord { get => _wachtwoord; set => _wachtwoord = value; }
        public char Geslacht { get => _geslacht; set => _geslacht = value; }
        public decimal Loon { get => _loon; set => _loon = value; }

        public override string ToString() //Stringweergave met volledige naam, geboortedatum en functie.
        {
            return $"{this.Naam}" + " " + $"{this.Voornaam}" + " " + $"{this.Functie}";
        }
    }
}
