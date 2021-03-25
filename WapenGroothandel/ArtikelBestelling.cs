using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    public class ArtikelBestelling
    {
        private Guid _id;
        private Guid _artikelID;
        private Guid _bestellingID;
        private int _hoeveelheid;

        public Guid ID { get => _id; set => _id = value; }
        public Guid ArtikelID { get => _artikelID; set => _artikelID = value; }
        public Guid BestellingID { get => _bestellingID; set => _bestellingID = value; }

        public int Hoeveelheid { get => _hoeveelheid; set => _hoeveelheid = value; }

        public ArtikelBestelling()
        {
            this.ID = Guid.NewGuid();
            this.ArtikelID = Guid.Empty;
            this.BestellingID = Guid.Empty;
            this._hoeveelheid = 0;
        }

        public ArtikelBestelling(Guid eenID, Guid eenArtikelID, Guid eenBestellingID, int hoeveelheid)
        {
            this.ID = eenID;
            this.ArtikelID = eenArtikelID;
            this.BestellingID = eenBestellingID;
            this.Hoeveelheid = hoeveelheid;
        }

        public override string ToString()
        {
            return $"ID: {this.ID}, Artikel: {this._artikelID}, Bestelling: {this.BestellingID}, Hoeveelheid: {this.Hoeveelheid}";
        }
    }
}
