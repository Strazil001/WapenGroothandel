using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    class Locatie
    {
        private Guid _id;
        private double _breedte;
        private double _hoogte;
        private double _diepte;
        private int _gang;
        private int _plaats;

        public Locatie()
        {
            this.ID = Guid.NewGuid();
            this.Breedte = 0;
            this.Hoogte = 0;
            this.Diepte = 0;
            this.Gang = 0;
            this.Plaats = 0;
        }
        public Locatie(Guid eenID, double eenBreedte, double eenHoogte, double eenDiepte, int eenGang, int eenPlaats)
        {
            this.ID = eenID;
            this.Breedte = eenBreedte;
            this.Hoogte = eenHoogte;
            this.Diepte = eenDiepte;
            this.Gang = eenGang;
            this.Plaats = eenPlaats;
        }

        public Guid ID { get => _id; set => _id = value; }
        public double Breedte { get => _breedte; set => _breedte = value; }
        public double Hoogte { get => _hoogte; set => _hoogte = value; }
        public double Diepte { get => _diepte; set => _diepte = value; }
        public int Gang { get => _gang; set => _gang = value; }
        public int Plaats { get => _plaats; set => _plaats = value; }

        public override string ToString()
        {
            return $"ID: {this.ID}, Gang: {this.Gang}, Plaats: {this.Plaats}";
        }

    }
}
