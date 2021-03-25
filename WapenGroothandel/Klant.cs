using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace klassen
{
    [Serializable]
	public class Klant : Entiteit, ISerializable
    {
        private string _leveradres;
        private string _factuuradres;
        private string _BTWNummer;
        private string _type;

        public string Leveradres { get => _leveradres; set => _leveradres = value; }
        public string Factuuradres { get => _factuuradres; set => _factuuradres = value; }
        public string BTWNummer { get => _BTWNummer; set => _BTWNummer = value; }
        public string Type { get => _type; set => _type = value; }

        public Klant()
        {
            this.Leveradres = "";
            this.Factuuradres = "";
            this.BTWNummer = "";
            this.Contactpersoon = "";
        }
        public Klant(Guid eenID, string eenNaam, string eenVoornaam, string eenTelNummer, string eenEmail, string eenContactpersoon, string eenOpmerking, string eenBTWNummer, string eenFactuuradres, string eenLeveradres) : base(eenID, eenNaam, eenVoornaam, eenTelNummer, eenEmail, eenContactpersoon, eenOpmerking)
        {
            this.Leveradres = eenLeveradres;
            this.Factuuradres = eenFactuuradres;
            this.BTWNummer = eenBTWNummer;
            this.Contactpersoon = eenContactpersoon;
        }

        public override string ToString() //Stringweergave met naam en contactpersoon.
        {
            //return $"Naam: {this.Naam + Environment.NewLine}Contactpersoon: {this.Contactpersoon + Environment.NewLine}";
            return $"Klant: {this.Naam} {this.Voornaam} {this.TelNummer} {this.EMail} {this.Contactpersoon} {this.Opmerking} {this.BTWNummer} {this.Factuuradres}";
        }
		public void Save(string fileName)
		{
			using (var stream = new FileStream(fileName, FileMode.Create))
			{
				var xml = new XmlSerializer(typeof(Klant));
				xml.Serialize(stream, this);
			}
		}
        public static Klant LoadFromFile(string fileName)
		{
 			using (var stream = new FileStream(fileName, FileMode.Open))
			{
				var xml = new XmlSerializer(typeof(Klant));
				return (Klant)xml.Deserialize(stream);
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
            info.AddValue("ID", ID);
            info.AddValue("Naam", Naam);
            info.AddValue("Voornaam", Voornaam);
            info.AddValue("TelNummer", TelNummer);
            info.AddValue("Email", EMail);
            info.AddValue("Contactpersoon", Contactpersoon);
            info.AddValue("Opmerking", Opmerking);
            info.AddValue("Leveradres", Leveradres);
            info.AddValue("Factuuradres", Factuuradres);
            info.AddValue("BTWNummer", BTWNummer);
		}
        public Klant(SerializationInfo info, StreamingContext context)
		{
            ID = (Guid)info.GetValue("ID", typeof(Guid));
            Naam = (string)info.GetValue("Naam", typeof(string));
            Voornaam = (string)info.GetValue("Voornaam", typeof(string));
            TelNummer = (string)info.GetValue("TelNummer", typeof(string));
            EMail = (string)info.GetValue("Email", typeof(string));
            Contactpersoon = (string)info.GetValue("Contactpersoon", typeof(string));
            Opmerking = (string)info.GetValue("Opmerking", typeof(string));
            Leveradres = (string)info.GetValue("Leveradres", typeof(string));
            Factuuradres = (string)info.GetValue("Factuuradres", typeof(string));
            BTWNummer = (string)info.GetValue("BTWNummer ", typeof(string));
		}
	}
}
