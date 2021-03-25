using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    class Offerte
    {
        private Guid _id;
        private string _status;
        private Guid _bestellingID;

        public Offerte()
        {
            this.ID = Guid.NewGuid();
            this.Status = "";
            this.BestellingID = Guid.Empty;
        }

        public Offerte(Guid eenID, string eenStatus, Guid eenBestellingID)
        {
            this.ID = eenID;
            this.Status = eenStatus;
            this.BestellingID = eenBestellingID;
        }
        public Guid ID { get => _id; set => _id = value; }
        public string Status { get => _status; set => _status = value; }
        public Guid BestellingID { get => _bestellingID; set => _bestellingID = value; }

        public void LoadXML(string eenPad)
        {
            //Do Something
        }

        public void VraagOfferteAan()
        {
            //Dit doet iets.
        }
        public override string ToString()//Stringweergave op basis van ID en status.
        {
            return $"ID: {this.ID + Environment.NewLine}Status: {this.Status}";
        }
    }
}
