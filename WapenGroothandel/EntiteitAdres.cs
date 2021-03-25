using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    public class EntiteitAdres
    {
        private Guid _id;
        private Guid _adresId;
        private Guid _entiteitId;

        public EntiteitAdres()
        {
            this.ID = Guid.NewGuid();
            this.AdresId = Guid.NewGuid();
            this.EntiteitId = Guid.NewGuid();
        }
        public EntiteitAdres(Guid eenID, Guid eenAdresID, Guid eenEntiteitID)
        {
            this.ID = eenID;
            this.AdresId = eenAdresID;
            this.EntiteitId = eenEntiteitID;
        }

        public Guid ID { get => _id; set => _id = value; }
        public Guid AdresId { get => _adresId; set => _adresId = value; }
        public Guid EntiteitId { get => _entiteitId; set => _entiteitId = value; }

        public override string ToString()
        {
            return $"ID: {this.ID}, AdresID: {this.AdresId}, EntiteitID: {this.EntiteitId}";
        }
    }
}
