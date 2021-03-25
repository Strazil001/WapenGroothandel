using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    public class Factuur
    {
        private Guid _id;
        private int _factuurNummer;
        private Guid _offerteID;
        private string _type;
        public Factuur()
        {
            this.ID = Guid.NewGuid();
            this.FactuurNummer = -1;
            this.OfferteID = Guid.Empty;
            this.Type = "";
        }

        public Factuur(Guid eenID, int eenFactuurNummer, Guid eenOfferteID, string eenType)
        {
            this.ID = eenID;
            this.FactuurNummer = eenFactuurNummer;
            this.OfferteID = eenOfferteID;
            this.Type = eenType;
        }
        public Guid ID { get => _id; set => _id = value; }
        public int FactuurNummer { get => _factuurNummer; set => _factuurNummer = value; }
        public Guid OfferteID { get => _offerteID; set => _offerteID = value; }
        public string Type { get => _type; set => _type = value; }

        public override string ToString()
        {
            return $"Factuurnummer: {FactuurNummer + Environment.NewLine}Type: {Type}";
        }
    }
}
