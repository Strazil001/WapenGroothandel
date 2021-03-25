using klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WapenGroothandel
{
    public class LeverancierData : BaseData<LeverancierData>
    {
        private Dictionary<string, Leverancier> _leveranciers = new Dictionary<string, Leverancier>();
        private Dictionary<string, Dictionary<string, LeverancierArtikel>> _leverancierArtikelen = new Dictionary<string, Dictionary<string, LeverancierArtikel>>();

        public int LeverancierCount
        {
            get { return _leveranciers.Count; }
        }

        public List<Leverancier> AlleLeveranciers
        {
            get
            {
                return new List<Leverancier>(_leveranciers.Values.ToArray());
            }
        }
        public List<LeverancierArtikel> AlleLeverancierArtikelen
        {
            get
            {
                List<LeverancierArtikel> artikelen = new List<LeverancierArtikel>();
                foreach (var leverancier in _leverancierArtikelen)
                {
                    foreach (var artikel in leverancier.Value)
                    {
                        artikelen.Add(artikel.Value);
                    }
                }
                return artikelen;
            }
        }
        protected override void ReadClassSpecificXml(XmlReader reader)
        {
            _leveranciers.Clear();
            _leverancierArtikelen.Clear();

            string naam, voornaam, telefoonNummer, email, BTW, rekeningNummer, contactPersoon, opmerking, strLeverancierID, strLeverancierArtikelID;
            Guid leverancierID, leverancierArtikelID, artikelID;
            List<LeverancierArtikel> leverancierArtikelen;

            if (reader.ReadToDescendant("Leverancier"))
            {
                do
                {
                    if (reader.ReadToFollowing("ID") == false || !Guid.TryParse(reader.ReadElementContentAsString(), out leverancierID))
                    {
                        continue;
                    }
                    strLeverancierID = leverancierID.ToString();

                    if (reader.ReadToNextSibling("Naam") == false) continue;
                    naam = reader.ReadElementContentAsString();

                    if (reader.ReadToNextSibling("Voornaam") == false) continue;
                    voornaam = reader.ReadElementContentAsString();

                    if (reader.ReadToNextSibling("TelefoonNummer") == false) continue;
                    telefoonNummer = reader.ReadElementContentAsString();

                    if (reader.ReadToNextSibling("Email") == false) continue;
                    email = reader.ReadElementContentAsString();

                    if (reader.ReadToNextSibling("BTW") == false) continue;
                    BTW = reader.ReadElementContentAsString();

                    if (reader.ReadToNextSibling("RekeningNummer") == false) continue;
                    rekeningNummer = reader.ReadElementContentAsString();

                    if (reader.ReadToNextSibling("Contactpersoon") == false) continue;
                    contactPersoon = reader.ReadElementContentAsString();

                    if (reader.ReadToNextSibling("Opmerking") == false) continue;
                    opmerking = reader.ReadElementContentAsString();

                    //dit is al genoeg om de leverancier mee aan te maken
                    if (_leveranciers.ContainsKey(strLeverancierID) == false)
                    {
                        _leveranciers.Add(strLeverancierID, new Leverancier(leverancierID, naam, voornaam, telefoonNummer, email, contactPersoon, opmerking, BTW, rekeningNummer));
                        _leverancierArtikelen.Add(strLeverancierID, new Dictionary<string, LeverancierArtikel>());
                    }

                    if (reader.ReadToNextSibling("LeverancierArtikelen") == false) continue;
                    leverancierArtikelen = new List<LeverancierArtikel>();
                    if (reader.ReadToDescendant("LeverancierArtikel"))
                    {
                        do
                        {
                            if (reader.ReadToDescendant("ID") == false || !Guid.TryParse(reader.ReadElementContentAsString(), out leverancierArtikelID)) continue;
                            strLeverancierArtikelID = leverancierArtikelID.ToString();
                            //we kijken of dit id al voorkomt in de dictionary
                            if (reader.ReadToNextSibling("ArtikelID") == false || !Guid.TryParse(reader.ReadElementContentAsString(), out artikelID)) continue;

                            _leverancierArtikelen[strLeverancierID].Add(strLeverancierArtikelID, new LeverancierArtikel(leverancierArtikelID, artikelID, leverancierID));

                            while (reader.Read() && reader.NodeType != XmlNodeType.EndElement && reader.LocalName != "LeverancierArtikel") ;

                        } while (reader.ReadToNextSibling("LeverancierArtikel"));

                        while (reader.Read() && reader.NodeType != XmlNodeType.EndElement && reader.LocalName != "Leverancier") ;
                    }
                } while (reader.ReadToNextSibling("Leverancier"));
            }

        }
        protected override void WriteClassSpecificXml(XmlWriter writer)
        {
            Dictionary<string, LeverancierArtikel> artikelenVan;
            //we schrijven de leveranciers en hun artikelen weg. 
            //een leverancier kan verschillende artikelen hebben
            writer.WriteStartElement("Leveranciers");

            foreach (var leverancier in _leveranciers)
            {
                if (leverancier.Value == null) continue;
                if (_leverancierArtikelen.TryGetValue(leverancier.Key, out artikelenVan))
                {
                    writer.WriteStartElement("Leverancier");
                    writer.WriteElementString("ID", leverancier.Value.ID.ToString());
                    writer.WriteElementString("Naam", leverancier.Value.Naam);
                    writer.WriteElementString("Voornaam", leverancier.Value.Voornaam);
                    writer.WriteElementString("TelefoonNummer", leverancier.Value.TelNummer);
                    writer.WriteElementString("Email", leverancier.Value.EMail);
                    writer.WriteElementString("BTW", leverancier.Value.BTWNummer);
                    writer.WriteElementString("RekeningNummer", leverancier.Value.RekeningNummer);
                    writer.WriteElementString("Contactpersoon", leverancier.Value.Contactpersoon);
                    writer.WriteElementString("Opmerking", leverancier.Value.Opmerking);

                    writer.WriteStartElement("LeverancierArtikelen");
                    foreach (var lArtikel in artikelenVan)
                    {
                        writer.WriteStartElement("LeverancierArtikel");
                        if (lArtikel.Value == null) continue;
                        writer.WriteElementString("ID", lArtikel.Value.ID.ToString());
                        writer.WriteElementString("ArtikelID", lArtikel.Value.ArtikelID.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
            }

            writer.WriteEndElement();


        }
        public void AddLeverancier(Leverancier leverancier)
        {
            if (leverancier == null) return;
            string id = leverancier.ID.ToString();
            if (_leveranciers.ContainsKey(id)) return;
            _leveranciers.Add(id, leverancier);
            _leverancierArtikelen.Add(id, new Dictionary<string, LeverancierArtikel>());
        }
        public void AddLeverancierArtikel(Guid leverancierGuid, Guid artikelGuid)
        {
            string leverancierId = leverancierGuid.ToString();
            string artikelId = artikelGuid.ToString();
            if (string.IsNullOrEmpty(leverancierId) || string.IsNullOrEmpty(artikelId)) return;
            if (_leveranciers.ContainsKey(leverancierId) == false) return;
            if (_leverancierArtikelen.TryGetValue(leverancierId, out Dictionary<string, LeverancierArtikel> lArtikelen))
            {
                if (lArtikelen.ContainsKey(artikelId) == false)
                {
                    lArtikelen.Add(artikelId, new LeverancierArtikel(Guid.NewGuid(), artikelGuid, leverancierGuid));
                }
            };
        }
        public void RemoveLeverancier(Guid leverancierGuid)
        {
            string id = leverancierGuid.ToString();
            if (_leveranciers.ContainsKey(id))
            {
                _leveranciers.Remove(id);
            }

            if (_leverancierArtikelen.ContainsKey(id))
            {
                _leverancierArtikelen.Remove(id);
            }
        }
        public void RemoveLeverancierArtikel(Guid leverancier, Guid artikel)
        {
            string leverancierId = leverancier.ToString();
            string artikelId = artikel.ToString();
            if (_leveranciers.ContainsKey(leverancier.ToString()) == false) return;
            if (_leverancierArtikelen.TryGetValue(leverancierId, out Dictionary<string, LeverancierArtikel> lArtikelen))
            {
                if (lArtikelen.ContainsKey(artikelId))
                {
                    lArtikelen.Remove(artikelId);
                }
            }
        }
        public Leverancier LeverancierVanID(Guid leverancierGuid)
        {
            if (_leveranciers.TryGetValue(leverancierGuid.ToString(), out Leverancier leverancier))
            {
                return leverancier;
            }

            return null;
        }
        public List<Artikel> AlleArtikelenVanLeverancier(Guid leverancierGuid)
        {
            List<Artikel> artikelen = new List<Artikel>();

            string leverancierID = leverancierGuid.ToString();
            if (_leveranciers.ContainsKey(leverancierID))
            {
                if (_leverancierArtikelen.TryGetValue(leverancierID, out Dictionary<string, LeverancierArtikel> lArtikelen))
                {
                    foreach (var lArtikel in lArtikelen.Values)
                    {
                        if (DataManager.Instance.ArtikelData.TryGetArtikel(lArtikel.ArtikelID, out Artikel artikel))
                        {
                            artikelen.Add(artikel);
                        }
                    }
                }
            }

            return artikelen;
        }

    }
}
