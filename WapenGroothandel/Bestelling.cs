using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    public class Bestelling
    {
        private Guid _id;
        private string _type;
        private DateTime _datum;
        private Guid _klantID;
        private Guid _leverancierID;

        public Bestelling()
        {
            this.ID = Guid.NewGuid();
            this.Type = "";
            this.Datum = DateTime.MinValue;
            this.KlantID = Guid.Empty;
            this.LeverancierID = Guid.Empty;
        }

        public Bestelling(Guid eenID, string eenType, DateTime eenDatum, Guid eenKlantID, Guid eenLeverancierID)
        {
            this.ID = eenID;
            this.Type = eenType;
            this.Datum = eenDatum;
            this.KlantID = eenKlantID;
            this.LeverancierID = eenLeverancierID;
        }
        public Guid ID { get => _id; set => _id = value; }
        public string Type { get => _type; set => _type = value; }
        public DateTime Datum { get => _datum; set => _datum = value; }
        public Guid KlantID { get => _klantID; set => _klantID = value; }
        public Guid LeverancierID { get => _leverancierID; set => _leverancierID = value; }

        public override string ToString() //Stringversie op basis van het type en de datum.
        {
            return $"Type: {Type + Environment.NewLine} Datum: {Datum.ToString("dd/MM/yyyy")}";
        }
    }
}
