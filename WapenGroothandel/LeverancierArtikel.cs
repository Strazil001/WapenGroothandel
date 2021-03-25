using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    public class LeverancierArtikel
    {
        private Guid _id;
        private Guid _artikelID;
        private Guid _leverancierID;

        public Guid ID { get => _id; set => _id = value; }
        public Guid ArtikelID { get => _artikelID; set => _artikelID = value; }
        public Guid LeverancierID { get => _leverancierID; set => _leverancierID = value; }

        public LeverancierArtikel()
        {
            this.ID = Guid.NewGuid();
            this.ArtikelID = Guid.Empty;
            this.LeverancierID = Guid.Empty;
        }

        public LeverancierArtikel(Guid eenID, Guid eenArtikelID, Guid eenLeverancierID)
        {
            this.ID = eenID;
            this.ArtikelID = eenArtikelID;
            this.LeverancierID = eenLeverancierID;
        }

        public override string ToString()
        {
            return $"ID: {this.ID}, Artikel: {this._artikelID}, Leverancier: {this.LeverancierID}";
        }
    }
}
