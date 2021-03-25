using klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace WapenGroothandel
{
    public class BestellingAanvraag : BaseData<BestellingAanvraag>
    {
        private Bestelling _bestelling = null;
        private List<ArtikelBestelling> _besteldeArtikelen = null;
        private Klant _klant;

        public void SetData(Klant klant, Bestelling bestelling, List<ArtikelBestelling> besteldeArtikelen)
        {
            _klant = klant;
            _bestelling = bestelling;
            _besteldeArtikelen = besteldeArtikelen;
        }


        protected override void ReadClassSpecificXml(XmlReader reader)
        {
            //dit moet niet in staat zijn om in te lezen. dit is bedoelt om de dat uit teschrijven dus zou dit mss moeten delen in 2 interfaces
            //de data weggeschreven hier is niet genoeg om dit object terug op te bouwen
        }

        protected override void WriteClassSpecificXml(XmlWriter writer)
        {
            //we kijken of we onze data hebben
            if (_bestelling == null || _besteldeArtikelen == null || _klant == null || _besteldeArtikelen.Count == 0) return;


            writer.WriteStartElement("Bestellingen");

            writer.WriteAttributeString("Datumtijd", _bestelling.Datum.ToString());
            writer.WriteAttributeString("Klantnaam", $"{_klant.Naam} {_klant.Voornaam}");
            //we maken een bestelling aan per artikelBestellingen
            Artikel artikel;
            foreach (var besteldArtikel in _besteldeArtikelen)
            {
                //we checken of dit artikel wel bestaat en of er wel een hoeveelheid is
                if (besteldArtikel.Hoeveelheid <= 0) continue;
                if (DataManager.Instance.ArtikelData.TryGetArtikel(besteldArtikel.ArtikelID, out artikel) == false) continue;

                writer.WriteStartElement("Bestelling");

                //writer.WriteElementString("ArtikelID", artikel.ID.ToString());
                writer.WriteElementString("ArtikelNummer", artikel.Artikelnummer.ToString());
                writer.WriteElementString("Modelnummer", artikel.Modelnummer.ToString());
                writer.WriteElementString("Hoeveelheid", besteldArtikel.Hoeveelheid.ToString());

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}
