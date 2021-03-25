using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    class VerpakkingArtikel
    {
        private Guid _id;
        private Guid _verpakkingId;
        private Guid _artikelId;

        public VerpakkingArtikel()
        {
            this.ID = Guid.NewGuid();
            this.VerpakkingID = Guid.NewGuid();
            this.ArtikelID = Guid.NewGuid();
        }
        public VerpakkingArtikel(Guid eenID, Guid eenVerpakkingID, Guid eenArtikelID)
        {
            this.ID = eenID;
            this.VerpakkingID = eenVerpakkingID;
            this.ArtikelID = eenArtikelID;
        }

        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public Guid VerpakkingID
        {
            get { return _verpakkingId; }
            set { _verpakkingId = value; }
        }
        public Guid ArtikelID
        {
            get { return _artikelId; }
            set { _artikelId = value; }
        }

        public override string ToString()
        {
            return $"ID: {this.ID + Environment.NewLine}VerpakkingID: {this.VerpakkingID + Environment.NewLine}ArtikelID: {this.ArtikelID}";
        }
    }
}
