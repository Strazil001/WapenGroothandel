using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    class Stock
    {
        private Guid _id;
        private string _verpakkingstype;
        private Guid _adresID;
        private Guid _stocklocatieID;

        public Stock()
        {
            this.ID = Guid.NewGuid();
            this.Verpakkingstype = "";
            this.AdresID = Guid.NewGuid();
            this.StocklocatieID = Guid.NewGuid();
        }
        public Stock(Guid eenID, string eenVerpakkingstype, Guid eenAdresID, Guid eenStocklocatieID)
        {
            this.ID = eenID;
            this.Verpakkingstype = eenVerpakkingstype;
            this.AdresID = eenAdresID;
            this.StocklocatieID = eenStocklocatieID;
        }


        public Guid ID { get => _id; set => _id = value; }
        public string Verpakkingstype { get => _verpakkingstype; set => _verpakkingstype = value; }
        public Guid AdresID { get => _adresID; set => _adresID = value; }
        public Guid StocklocatieID { get => _stocklocatieID; set => _stocklocatieID = value; }

        public override string ToString()
        {
            return $"ID: {this.ID}, AdresID: {this.AdresID}, StockLocatieID: {this.StocklocatieID}, Verpakkingstype: {this.Verpakkingstype}";
        }
    }
}
