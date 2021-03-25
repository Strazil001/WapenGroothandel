using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    class StockLocatie
    {
        private Guid _id;
        private Guid _stockId;
        private Guid _verpakkingId;

        public StockLocatie()
        {
            this.ID = Guid.NewGuid();
            this.StockId = Guid.NewGuid();
            this.VerpakkingId = Guid.NewGuid();
        }
        public StockLocatie(Guid eenID, Guid eenStockID, Guid eenVerpakkingID)
        {
            this.ID = eenID;
            this.StockId = eenStockID;
            this.VerpakkingId = eenVerpakkingID;
        }

        public Guid ID { get => _id; set => _id = value; }
        public Guid StockId { get => _stockId; set => _stockId = value; }
        public Guid VerpakkingId { get => _verpakkingId; set => _verpakkingId = value; }

        public override string ToString()
        {
            return $"ID: {this.ID}, StockID: {this.StockId}, VerpakkingID: {this.VerpakkingId}";
        }
    }
}
