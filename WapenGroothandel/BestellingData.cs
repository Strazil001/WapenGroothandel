using klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WapenGroothandel
{
    public class BestellingData : BaseData<BestellingData>
    {
        private List<ArtikelBestelling> _artikelBestellingen = new List<ArtikelBestelling>();
        private Dictionary<string, Bestelling> _bestellingen = new Dictionary<string, Bestelling>();

        public List<Bestelling> AlleBestellingen
        {
            get
            {
                return new List<Bestelling>(_bestellingen.Values);
            }
        }

        public List<Artikel> AlleArtikelenVanBestelling(Guid bestellingId)
        {
            List<Artikel> alleArtikelen = new List<Artikel>();
            //we kijken in de artikel bestellingen welke overeenkomen
            foreach (var artikelBestelling in _artikelBestellingen)
            {
                if (artikelBestelling.BestellingID.Equals(bestellingId))
                {
                    if (DataManager.Instance.ArtikelData.TryGetArtikel(bestellingId, out Artikel artikel))
                    {
                        alleArtikelen.Add(artikel);
                    }
                }
            }

            return alleArtikelen;
        }

        public List<Bestelling> AlleBestellingenVanArtikel(Guid artikelId)
        {
            List<Bestelling> alleBestellingen = new List<Bestelling>();
            //we kijken in de artikel bestellingen welke overeenkomen
            foreach (var artikelBestelling in _artikelBestellingen)
            {
                if (artikelBestelling.ArtikelID.Equals(artikelId))
                {
                    if (_bestellingen.TryGetValue(artikelBestelling.BestellingID.ToString(), out Bestelling bestelling))
                    {
                        alleBestellingen.Add(bestelling);
                    }
                }
            }

            return alleBestellingen;
        }

        public List<ArtikelBestelling> AlleArtikelBestellingVanBestelling(Guid bestellingId)
        {
            List<ArtikelBestelling> artikelBestellingen = new List<ArtikelBestelling>();

            if (_bestellingen.ContainsKey(bestellingId.ToString()) == false) return artikelBestellingen;

            for (int i = 0; i < _artikelBestellingen.Count; ++i)
            {
                if (_artikelBestellingen[i].BestellingID.Equals(bestellingId))
                {
                    artikelBestellingen.Add(_artikelBestellingen[i]);
                }
            }

            return artikelBestellingen;
        }

        public List<Bestelling> AlleBestellingenVanLeverancier(Guid leverancierId)
        {
            List<Bestelling> bestellingen = new List<Bestelling>();

            //we moeten kijken door alle bestellingen heen
            foreach (var bestelling in _bestellingen)
            {
                if (bestelling.Value.LeverancierID.Equals(leverancierId))
                {
                    bestellingen.Add(bestelling.Value);
                }
            }

            return bestellingen;
        }

        public void AddBestelling(Bestelling bestelling, List<ArtikelBestelling> artikelen)
        {
            if (bestelling == null || artikelen == null || artikelen.Count == 0) return;
            string id = bestelling.ID.ToString();
            if (_bestellingen.ContainsKey(id)) return; //we already have that id which shouldn't be done or happen

            foreach (var artikelbestelling in artikelen)
            {
                artikelbestelling.BestellingID = bestelling.ID;
            }
            _bestellingen.Add(id, bestelling);
            _artikelBestellingen.AddRange(artikelen);
        }

        public void RemoveBestelling(Guid guid)
        {
            if (_bestellingen.ContainsKey(guid.ToString()) == false)
            {
                return;
            }
            string id = guid.ToString();
            _bestellingen.Remove(id);
            //we verwijderen elke object met dit bestellingId
            for (int i = _artikelBestellingen.Count - 1; i >= 0; --i)
            {
                if (_artikelBestellingen[i].BestellingID.Equals(guid))
                {
                    _artikelBestellingen.RemoveAt(i);
                }
            }
        }

        public bool TryGetBestelling(string bestellingId, out Bestelling bestelling)
        {
            bestelling = null;
            if (string.IsNullOrEmpty(bestellingId)) return false;
            return _bestellingen.TryGetValue(bestellingId, out bestelling);
        }

        public bool ContainsBestelling(string bestellingId)
        {
            if (string.IsNullOrEmpty(bestellingId)) return false;
            return _bestellingen.ContainsKey(bestellingId);
        }

        //De Methods gebruikt om de klasse weg te schrijven en in te lezen.
        protected override void ReadClassSpecificXml(XmlReader reader)
        {
            _artikelBestellingen.Clear();
            _bestellingen.Clear();
            while (reader.ReadToFollowing("Bestelling"))
            {
                //we lezen de data onder de bestelling
                if (reader.ReadToDescendant("ID") == false || Guid.TryParse(reader.ReadElementContentAsString(), out Guid bestellingId) == false) continue;
                string bestellingIdText = bestellingId.ToString();
                if (_bestellingen.ContainsKey(bestellingIdText)) continue; //we hebben deze bestelling al dus moeten we ze niet toevoegen(eig onnodige check zou niet mogen gebeuren)

                if (reader.ReadToNextSibling("KlantId") == false) continue;
                Guid klantId = Guid.Parse(reader.ReadElementContentAsString());

                if (reader.ReadToNextSibling("LeverancierId") == false) continue;
                Guid leverancierId = Guid.Parse(reader.ReadElementContentAsString());

                if (reader.ReadToNextSibling("Datum") == false) continue;
                DateTime bestelDatum = DateTime.ParseExact(reader.ReadElementContentAsString(), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

                if (reader.ReadToNextSibling("Type") == false) continue;
                string type = reader.ReadElementContentAsString();

                //we maken de bestelling
                _bestellingen.Add(bestellingIdText, new Bestelling(bestellingId, type, bestelDatum, klantId, leverancierId));
                while (reader.ReadToFollowing("ArtikelBestelling"))
                {
                    if (reader.ReadToDescendant("ID") == false || Guid.TryParse(reader.ReadElementContentAsString(), out Guid bestellingArtikelId) == false) continue;

                    if (reader.ReadToNextSibling("ArtikelId") == false) continue;
                    if (Guid.TryParse(reader.ReadElementContentAsString(), out Guid artikelId) == false) continue;

                    if (reader.ReadToNextSibling("Hoeveelheid") == false) continue;
                    int hoeveelheid = reader.ReadElementContentAsInt();

                    _artikelBestellingen.Add(new ArtikelBestelling(bestellingArtikelId, artikelId, bestellingId, hoeveelheid));
                }
            }
        }

        protected override void WriteClassSpecificXml(XmlWriter writer)
        {
            //we schrijfen de artikels uit
            List<ArtikelBestelling> artikelenBestelling;

            writer.WriteStartElement("Bestellingen");
            foreach (var bestelling in _bestellingen)
            {
                writer.WriteStartElement("Bestelling");

                writer.WriteElementString("ID", bestelling.Value.ID.ToString());
                writer.WriteElementString("KlantId", bestelling.Value.KlantID.ToString());
                writer.WriteElementString("LeverancierId", bestelling.Value.LeverancierID.ToString());
                writer.WriteElementString("Datum", bestelling.Value.Datum.ToString("dd-MM-yyyy"));
                writer.WriteElementString("Type", bestelling.Value.Type);

                artikelenBestelling = AlleArtikelBestellingVanBestelling(bestelling.Value.ID);
                writer.WriteStartElement("Artikelen");
                foreach (var artikelBestelling in artikelenBestelling)
                {
                    writer.WriteStartElement("ArtikelBestelling");
                    writer.WriteElementString("ID", artikelBestelling.ID.ToString());
                    writer.WriteElementString("ArtikelId", artikelBestelling.ArtikelID.ToString());
                    writer.WriteElementString("Hoeveelheid", artikelBestelling.Hoeveelheid.ToString());

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}
