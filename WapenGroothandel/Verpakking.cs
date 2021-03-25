using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    class Verpakking
    {
        private Guid _id;
        private string _type;
        private double _prijs;
        private double _breedte;
        private double _hoogte;
        private double _diepte;
        public Verpakking()
        {
            this.ID = Guid.NewGuid();
            this.Type = "";
            this.Prijs = 0;
            this.Breedte = 0;
            this.Hoogte = 0;
            this.Diepte = 0;
        }
        public Verpakking(Guid eenId, string eenType, double eenPrijs, double eenBreedte, double eenHoogte, double eenDiepte)
        {
            this.ID = eenId;
            this.Type = eenType;
            this.Prijs = eenPrijs;
            this.Breedte = eenBreedte;
            this.Hoogte = eenHoogte;
            this.Diepte = eenDiepte;
        }

        public Guid ID { get => _id; set => _id = value; }
        public string Type { get => _type; set => _type = value; }
        public double Prijs { get => _prijs; set => _prijs = value; }
        public double Breedte { get => _breedte; set => _breedte = value; }
        public double Hoogte { get => _hoogte; set => _hoogte = value; }
        public double Diepte { get => _diepte; set => _diepte = value; }


        public override string ToString()
        {
            return $"Type: {this.Type}, Prijs: {this.Prijs}, Volume: {this.Hoogte * this.Breedte * this.Diepte}m³";
        }
    }
}
