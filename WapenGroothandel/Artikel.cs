using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    public class Artikel
    {
        private Guid _id;
        private string _naam;
        private string _omschrijving;
        private string _type;
        private double _gewicht;
        private decimal _prijs;
        private int _artikelnummer;
        private int _modelnummer;
        private int _serienummer;
        private DateTime _aangemaaktOp;
        private DateTime _garantieduur;
        private Guid _verpakking;
        private int _btw;

        public Artikel()
        {
            this.ID = Guid.NewGuid();
            this.Naam = "";
            this.Omschrijving = "";
            this.Type = "";
            this.Gewicht = 0;
            this.Prijs = 0;
            this.Artikelnummer = 0;
            this.Modelnummer = 0;
            this.Serienummer = 0;
            this.AangemaaktOp = DateTime.Now;
            this.Garantieduur = DateTime.Now.AddYears(2);
            this.Verpakking = Guid.NewGuid();
            this.Btw = 0;
        }
        public Artikel(Guid eenID, string eenNaam, string eenOmschrijving, string eenType, double eenGewicht, decimal eenPrijs, int eenArtikelNummer, int eenModelNummer, int eenSerieNummer, DateTime eenAangemaakteDatum, DateTime eenGarantieDuur, Guid eenVerpakking, int eenBTW)
        {
            this.ID = eenID;
            this.Naam = eenNaam;
            this.Omschrijving = eenOmschrijving;
            this.Type = eenType;
            this.Gewicht = eenGewicht;
            this.Prijs = eenPrijs;
            this.Artikelnummer = eenArtikelNummer;
            this.Modelnummer = eenModelNummer;
            this.Serienummer = eenSerieNummer;
            this.AangemaaktOp = eenAangemaakteDatum;
            this.Garantieduur = eenGarantieDuur;
            this.Verpakking = eenVerpakking;
            this.Btw = eenBTW;
        }

        public Guid ID { get => _id; set => _id = value; }
        public string Naam { get => _naam; set => _naam = value; }
        public string Omschrijving { get => _omschrijving; set => _omschrijving = value; }
        public string Type { get => _type; set => _type = value; }
        public double Gewicht { get => _gewicht; set => _gewicht = value; }
        public decimal Prijs { get => _prijs; set => _prijs = value; }
        public int Artikelnummer { get => _artikelnummer; set => _artikelnummer = value; }
        public int Modelnummer { get => _modelnummer; set => _modelnummer = value; }
        public int Serienummer { get => _serienummer; set => _serienummer = value; }
        public DateTime AangemaaktOp { get => _aangemaaktOp; set => _aangemaaktOp = value; }
        public DateTime Garantieduur { get => _garantieduur; set => _garantieduur = value; }
        public Guid Verpakking { get => _verpakking; set => _verpakking = value; }
        public int Btw { get => _btw; set => _btw = value; }

        public override string ToString()
        {
            return $"Artikelnaam: {this.Naam + " " + Environment.NewLine}Modelnummer: {this.Modelnummer + " " + Environment.NewLine}Omschrijving: {this.Omschrijving}";
        }

        public void LoadXML(string eenPad)
        {
            //doe iets met XML
        }
    }
}
