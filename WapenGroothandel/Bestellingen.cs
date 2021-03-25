using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WapenGroothandel
{
    [Serializable]
    public class Bestellingen : ISerializable
    {
        private DateTime _datum;
        private int _artikelnummer;
        private int _modelnummer;
        private int _hoeveelheid;

        [XmlAttribute]
        public DateTime Datum { get => _datum; set => _datum = value; }
        public int Artikelnummer { get => _artikelnummer; set => _artikelnummer = value; }
        public int Modelnummer { get => _modelnummer; set => _modelnummer = value; }
        public int Hoeveelheid { get => _hoeveelheid; set => _hoeveelheid = value; }
        public Bestellingen() { }
        public Bestellingen(DateTime eenDatum, int eenArtikelnummer, int eenModelnummer, int eenHoeveelheid)
        {
            this.Datum = eenDatum;
            this.Artikelnummer = eenArtikelnummer;
            this.Modelnummer = eenModelnummer;
            this.Hoeveelheid = eenHoeveelheid;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Datum", Datum);
            info.AddValue("Artikelnummer", Artikelnummer);
            info.AddValue("Modelnummer", Modelnummer);
            info.AddValue("Modelnummer", Hoeveelheid);
        }        
        public Bestellingen(SerializationInfo info, StreamingContext context)
		{
            Datum = (DateTime)info.GetValue("Datum", typeof(DateTime));
            Artikelnummer = (int)info.GetValue("Artikelnummer", typeof(int));
            Modelnummer = (int)info.GetValue("Modelnummer", typeof(int));
            Hoeveelheid = (int)info.GetValue("Hoeveelheid", typeof(int));
		}
        public override string ToString()
        {
            return $"Artikelnummer: {Artikelnummer} Modelnummer: {Modelnummer} Aantal: {Hoeveelheid}";
        }
    }
}
