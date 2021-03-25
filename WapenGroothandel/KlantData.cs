using klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WapenGroothandel
{
    public class KlantData : BaseData<KlantData>
    {
        private Dictionary<string, Klant> _klanten = new Dictionary<string, Klant>();

        public List<Klant> AlleKlanten
        {
            get { return new List<Klant>(_klanten.Values); }
        }

        public bool TryGetKlant(Guid klantId, out Klant klant)
        {
            string id = klantId.ToString();
            if (_klanten.ContainsKey(id) == false)
            {
                klant = null;
                return false;
            }

            klant = _klanten[id];
            return klant != null;
        }

        public Klant GetKlant(Guid klantId)
        {
            string id = klantId.ToString();
            if (_klanten.ContainsKey(id))
            {
                return _klanten[id];
            }

            return null;
        }

        protected override void ReadClassSpecificXml(XmlReader reader)
        {
            _klanten.Clear();


            while (reader.ReadToFollowing("Klant"))
            {
                if (reader.ReadToDescendant("ID") == false || Guid.TryParse(reader.ReadElementContentAsString(), out Guid klantId) == false)
                {
                    continue;
                }

                string klantIdHash = klantId.ToString();
                if (_klanten.ContainsKey(klantIdHash)) continue;

                if (reader.ReadToNextSibling("Naam") == false) continue;
                string naam = reader.ReadContentAsString();

                if (reader.ReadToNextSibling("Voornaam") == false) continue;
                string voornaam = reader.ReadContentAsString();

                if (reader.ReadToNextSibling("Telefoonnummer") == false) continue;
                string telefoon = reader.ReadContentAsString();

                if (reader.ReadToNextSibling("BTW") == false) continue;
                string btwNummer = reader.ReadContentAsString();

                if (reader.ReadToNextSibling("Type") == false) continue;
                string type = reader.ReadContentAsString();

                if (reader.ReadToNextSibling("Opmerking") == false) continue;
                string opmerking = reader.ReadContentAsString();

                if (reader.ReadToNextSibling("Leveradres") == false) continue;
                string leverAdres = reader.ReadContentAsString();

                if (reader.ReadToNextSibling("Factuuradres") == false) continue;
                string factuurAdres = reader.ReadContentAsString();

                if (reader.ReadToNextSibling("Email") == false) continue;
                string email = reader.ReadContentAsString();

                if (reader.ReadToNextSibling("Contactpersoon") == false) continue;
                string contact = reader.ReadContentAsString();

                _klanten.Add(klantIdHash, new Klant(klantId, naam, voornaam, telefoon, email, contact, opmerking, btwNummer, factuurAdres, leverAdres));

            }

        }

        protected override void WriteClassSpecificXml(XmlWriter writer)
        {
            writer.WriteStartElement("Klanten");
            foreach (var klant in _klanten.Values)
            {
                writer.WriteStartElement("Klant");
                {
                    writer.WriteElementString("ID", klant.ID.ToString());
                    writer.WriteElementString("Naam", klant.Naam);
                    writer.WriteElementString("Voornaam", klant.Voornaam);
                    writer.WriteElementString("Telefoonnummer", klant.TelNummer);
                    writer.WriteElementString("BTW", klant.BTWNummer);
                    writer.WriteElementString("Type", klant.Type);
                    writer.WriteElementString("Opmerking", klant.Opmerking);
                    writer.WriteElementString("Leveradres", klant.Leveradres);
                    writer.WriteElementString("Factuuradres", klant.Factuuradres);
                    writer.WriteElementString("Email", klant.EMail);
                    writer.WriteElementString("Contactpersoon", klant.Contactpersoon);
                }
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}
