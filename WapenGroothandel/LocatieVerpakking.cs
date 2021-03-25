using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    class LocatieVerpakking
    {
        private Guid _id;
        private Guid _locatieId;
        private Guid _verpakkingId;

        public LocatieVerpakking()
        {
            this.ID = Guid.NewGuid();
            this.LocatieId = Guid.NewGuid();
            this.VerpakkingId = Guid.NewGuid();
        }
        public LocatieVerpakking(Guid eenID, Guid eenLocatieID, Guid eenVerpakkingID)
        {
            this.ID = eenID;
            this.LocatieId = eenLocatieID;
            this.VerpakkingId = eenVerpakkingID;
        }

        public Guid ID { get => _id; set => _id = value; }
        public Guid LocatieId { get => _locatieId; set => _locatieId = value; }
        public Guid VerpakkingId { get => _verpakkingId; set => _verpakkingId = value; }

        public override string ToString()
        {
            return $"ID: {this.ID}, locatie: {this.LocatieId}, verpakking: {this.VerpakkingId}";
        }
    }
}
