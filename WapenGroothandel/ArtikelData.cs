using klassen;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WapenGroothandel
{
    public class ArtikelData : BaseData<ArtikelData>
    {
        [XmlIgnore]
        private Dictionary<string, Artikel> _artikelen = new Dictionary<string, Artikel>();
        [XmlIgnore]
        private List<Artikel> _alleArtikelen = new List<Artikel>();

        [XmlIgnore]
        public List<Artikel> AlleArtikelen
        {
            get { return new List<Artikel>(_alleArtikelen); }
        }

        [XmlIgnore]
        public int Hoeveelheid { private set; get; }

        public void AddArtikel(Artikel artikel)
        {
            if (artikel == null) return;
            string id = artikel.ID.ToString();
            if (_artikelen.ContainsKey(id)) return;
            _artikelen.Add(id, artikel);
            _alleArtikelen.Add(artikel);
        }

        public void RemoveArtikel(Guid artikelId)
        {
            string id = artikelId.ToString();
            if (string.IsNullOrEmpty(id)) return;
            if (_artikelen.ContainsKey(id) == false) return;

            Artikel artikel = _artikelen[id];
            _alleArtikelen.Remove(artikel);
            _artikelen.Remove(id);
        }

        protected override void WriteClassSpecificXml(XmlWriter writer)
        {
            //we schrijfen de artikels uit
            writer.WriteStartElement("Artikelen");
            foreach (var artikel in _alleArtikelen)
            {
                writer.WriteStartElement("Artikel");

                writer.WriteElementString("ID", artikel.ID.ToString());
                writer.WriteElementString("Naam", artikel.Naam);
                writer.WriteElementString("Omschrijving", artikel.Omschrijving);
                writer.WriteElementString("Type", artikel.Type);
                writer.WriteElementString("Gewicht", artikel.Gewicht.ToString());
                writer.WriteElementString("Prijs", artikel.Prijs.ToString());
                writer.WriteElementString("Artikelnummer", artikel.Artikelnummer.ToString());
                writer.WriteElementString("Modelnummer", artikel.Modelnummer.ToString());
                writer.WriteElementString("Serienummer", artikel.Serienummer.ToString());
                writer.WriteElementString("AangemaaktOp", artikel.AangemaaktOp.ToString());
                writer.WriteElementString("Garantieduur", artikel.Garantieduur.ToString());
                writer.WriteElementString("Verpakking", artikel.Verpakking.ToString());
                writer.WriteElementString("BTW", artikel.Btw.ToString());

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        protected override void ReadClassSpecificXml(XmlReader reader)
        {
            //we creeren de artikelen hier
            //we lezen de data van de reader
            _alleArtikelen.Clear();
            _artikelen.Clear();
            while (reader.ReadToFollowing("Artikel"))
            {
                if (reader.ReadToDescendant("ID") == false) continue;
                Guid id = Guid.Parse(reader.ReadElementContentAsString());

                if (reader.ReadToNextSibling("Naam") == false) continue;
                string naam = reader.ReadElementContentAsString();

                if (reader.ReadToNextSibling("Omschrijving") == false) continue;
                string omschrijving = reader.ReadElementContentAsString();

                if (reader.ReadToNextSibling("Type") == false) continue;
                string type = reader.ReadElementContentAsString();

                if (reader.ReadToNextSibling("Gewicht") == false) continue;
                double gewicht = double.Parse(reader.ReadElementContentAsString());

                if (reader.ReadToNextSibling("Prijs") == false) continue;
                decimal prijs = decimal.Parse(reader.ReadElementContentAsString(), CultureInfo.InvariantCulture);

                if (reader.ReadToNextSibling("Artikelnummer") == false) continue;
                int artikelnummer = int.Parse(reader.ReadElementContentAsString());

                if (reader.ReadToNextSibling("Modelnummer") == false) continue;
                int modelnummer = int.Parse(reader.ReadElementContentAsString());

                if (reader.ReadToNextSibling("Serienummer") == false) continue;
                int serienummer = int.Parse(reader.ReadElementContentAsString());

                if (reader.ReadToNextSibling("AangemaaktOp") == false) continue;
                DateTime aangemaaktOp = DateTime.Parse(reader.ReadElementContentAsString());

                if (reader.ReadToNextSibling("Garantieduur") == false) continue;
                DateTime garantieDuur = DateTime.Parse(reader.ReadElementContentAsString());

                if (reader.ReadToNextSibling("Verpakking") == false) continue;
                Guid verpakking = Guid.Parse(reader.ReadElementContentAsString());

                if (reader.ReadToNextSibling("BTW") == false) continue;
                int btw = int.Parse(reader.ReadElementContentAsString());

                Artikel artikel = new Artikel(id, naam, omschrijving, type, gewicht, prijs, artikelnummer, modelnummer, serienummer, aangemaaktOp, garantieDuur, verpakking, btw);
                _alleArtikelen.Add(artikel);
            }


            for (int i = 0; i < _alleArtikelen.Count; ++i)
            {
                if (_alleArtikelen[i] == null) continue; //zou niet mogen
                string id = _alleArtikelen[i].ID.ToString();
                if (_artikelen.ContainsKey(id) == false)
                {
                    _artikelen.Add(id, _alleArtikelen[i]);
                }
            }

        }

        public bool TryGetArtikel(Guid artikelId, out Artikel artikel)
        {
            artikel = null;
            string id = artikelId.ToString();
            if (string.IsNullOrEmpty(id)) return false;
            return _artikelen.TryGetValue(id, out artikel);
        }
        public Artikel GetArtikel(Guid artikelId)
        {
            string id = artikelId.ToString();
            if (_artikelen.ContainsKey(id) == false) return null;
            return _artikelen[id];
        }

    }
}
