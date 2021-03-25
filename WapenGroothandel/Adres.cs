using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen
{
    class Adres
    {
        private Guid _id;
        private string _straat;
        private string _huisnummer;
        private string _bus;
        private int _postcode;
        private string _gemeente;
        private string _land;

        public Adres()
        {
            this.ID = Guid.NewGuid();
            this.Straat = "";
            this.Huisnummer = "";
            this.Bus = "";
            this.Postcode = 0;
            this.Gemeente = "";
            this.Land = "";
        }
        public Adres(Guid eenID, string eenStraat, string eenHuisnummer, string eenBus, int eenPostcode, string eenGemeente, string eenLand)
        {
            this.ID = eenID;
            this.Straat = eenStraat;
            this.Huisnummer = eenHuisnummer;
            this.Bus = eenBus;
            this.Postcode = eenPostcode;
            this.Gemeente = eenGemeente;
            this.Land = eenLand;
        }

        public Guid ID { get => _id; set => _id = value; }
        public string Straat { get => _straat; set => _straat = value; }
        public string Huisnummer { get => _huisnummer; set => _huisnummer = value; }
        public string Bus { get => _bus; set => _bus = value; }
        public int Postcode { get => _postcode; set => _postcode = value; }
        public string Gemeente { get => _gemeente; set => _gemeente = value; }
        public string Land { get => _land; set => _land = value; }

        public override string ToString()
        {
            string deStraat = this.Straat + " " + this.Huisnummer;
            if (Bus != "")
            {
                deStraat += " bus " + this.Bus;
            }
            return deStraat + Environment.NewLine + this.Postcode.ToString() + " " + this.Gemeente + Environment.NewLine + this.Land;
        }
    }
}
