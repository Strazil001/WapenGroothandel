using klassen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace WapenGroothandel
{
    public sealed class DataManager : Singleton<DataManager>
    {
        public ArtikelData ArtikelData { private set; get; } = new ArtikelData();

        public BestellingData BestellingData { private set; get; } = new BestellingData();

        public LeverancierData LeverancierData { private set; get; } = new LeverancierData();

        //dit is niet direct nodig
        //public KlantData KlantenData { private set; get; } = new KlantData();

        public KlantData BedrijfKlantenData { private set; get; } = new KlantData();

        //we laden alle artikels en linken deze aan de leveranciers

        public DataManager() : base()
        {
            ClearObject();
            //we laden de juiste data in (voor nu is dit de dummy data)

            //LeverancierData.AddLeverancier(new Leverancier(Guid.NewGuid(), "TestLeverancier", "Voornaam", "TelefoonNummer", "Email", "ContactPersoon", "Opmerking", "BtwNummer", "rekeningNummer"));
            //SchrijfXML(LeverancierData, "Leveranciers");
            //SchrijfXML(BestellingData, "Bestellingen");
            //SchrijfXML(BedrijfKlantenData, "BedrijfKlantenData");
            //SchrijfXML(KlantenData, "Klanten");

            //DummyInitialize();
            Initialize();
        }

        private void GenerateDummyData()
        {
            Random r = new Random();
            string naam;
            string voornaam;
            string telefoonNummer;
            string email;
            string contactpersoon;
            string opmerking;
            string btwNummer;
            string rekeningNummer;
            string type;

            double gewicht;
            double breedte, diepte, hoogte;
            double prijs;
            for (int i = 0; i < 10; ++i)
            {
                naam = $"Naam_{i}";
                voornaam = $"Voornaam_{i}";
                telefoonNummer = $"TelefoonNummer_{i}";
                email = $"Email_{i}";
                contactpersoon = $"Contactpersoon_{i}";
                opmerking = $"Opmerking_{i}";
                btwNummer = $"BtwNummer_{i}";
                rekeningNummer = $"RekeningNummer_{i}";
                Leverancier leverancier = new Leverancier(Guid.NewGuid(), naam, voornaam, telefoonNummer, email, contactpersoon, opmerking, btwNummer, rekeningNummer);
                LeverancierData.AddLeverancier(leverancier);
            }

            List<Verpakking> verpakkingen = new List<Verpakking>();
            for (int i = 0; i < 4; ++i)
            {
                type = $"Type_{i}";
                breedte = r.NextDouble() * 2;
                hoogte = r.NextDouble() * 2;
                diepte = r.NextDouble() * 2;
                prijs = (r.NextDouble() * 20 + 0.01f);
                Verpakking verpakking = new Verpakking(Guid.NewGuid(), type, prijs, breedte, hoogte, diepte);
                verpakkingen.Add(verpakking);
            }

            for (int i = 0; i < 100; ++i)
            {
                naam = $"Naam_{i}";
                type = $"Type_{i}";
                opmerking = $"Opmerking_{i}";
                gewicht = (r.NextDouble() + 0.1) * 10;
                prijs = (r.NextDouble() * 20 + 0.01f);
                Artikel artikel = new Artikel(Guid.NewGuid(), naam, opmerking, type, gewicht, (Decimal)prijs, i, 1, i, DateTime.Now, DateTime.Now, verpakkingen[r.Next(0, verpakkingen.Count)].ID, 1);
                ArtikelData.AddArtikel(artikel);
            }

            List<Artikel> alleArtikelen = ArtikelData.AlleArtikelen;
            List<Leverancier> alleLeveranciers = LeverancierData.AlleLeveranciers;
            for (int i = 0; i < 200; ++i)
            {
                //we maken random LeverancierArtikelen aan
                Guid leverancierGuid = alleLeveranciers[r.Next(0, alleLeveranciers.Count)].ID;
                Guid artikelGuid = alleArtikelen[(r.Next(0, alleArtikelen.Count))].ID;
                LeverancierData.AddLeverancierArtikel(leverancierGuid, artikelGuid);
            }


            //we maken de klant(wij) aan en de leverancier hebben we ook al
            Klant klant = new Klant(); //dit zijn allemaal ons bedrijf hun gegevens
            klant.Contactpersoon = "bedrijf-Contactpersoon";
            klant.BTWNummer = "bedrijf-BTW-Nummer";
            klant.EMail = "Bedrijf-Email";
            klant.Naam = "Bedrijf-Naam";
            klant.Voornaam = "Bedrijf-Voornaam";
            klant.Leveradres = "Bedrijf-LeverAdres";
            klant.Factuuradres = "Bedrijf-FactuurAdres";
            klant.TelNummer = "Bedrijf-Telefoon";

            foreach (var leverancier in alleLeveranciers)
            {
                List<Artikel> artikelen = LeverancierData.AlleArtikelenVanLeverancier(leverancier.ID);
                List<ArtikelBestelling> besteldeArtikelen = new List<ArtikelBestelling>();
                Bestelling bestelling = new Bestelling(Guid.NewGuid(), $"type_{leverancier.Naam}", DateTime.Now, klant.ID, leverancier.ID);
                for (int i = 0; i < 5; ++i)
                {
                    besteldeArtikelen.Add(new ArtikelBestelling(Guid.NewGuid(), artikelen[r.Next(0, artikelen.Count)].ID, bestelling.ID, r.Next(1, 10)));
                }

                BestellingData.AddBestelling(bestelling, besteldeArtikelen);
            }

        }
        private void GenerateDummyXml()
        {
            //SchrijfXML(BestellingData, "Bestellingen");
            //SchrijfXML(ArtikelData, "Artikelen");
            //SchrijfXML(KlantenData, "AankopenBij");
            //SchrijfXML(LeverancierData, "Leveranciers");
        }
        private void ReadDummyDataXml()
        {
            if (LeesXML("Artikelen", out BestellingData bestellingData))
            {
                BestellingData = bestellingData;
            }

            //LeesXML("AlleArtikelen", out ArtikelData artikelData);
            //if (LeesXML("AankopenBij", out KlantData klantData))
            //{
            //    KlantenData = klantData;
            //}

            if (LeesXML("Leveranciers", out LeverancierData leverancierData))
            {
                LeverancierData = leverancierData;
            }

        }
        private void DummyInitialize()
        {
            GenerateDummyData();
            GenerateDummyXml();
            //ReadDummyDataXml();
        }
        private void Initialize()
        {
            if (LeesXML("Artikelen", out ArtikelData artikelData))
            {
                ArtikelData = artikelData;
            }

            if (LeesXML("BedrijfKlantenData", out KlantData bedrijfKlantData))
            {
                BedrijfKlantenData = bedrijfKlantData;
            }

            if (LeesXML("Bestellingen", out BestellingData bestellingData))
            {
                BestellingData = bestellingData;
            }

            Leverancier leverancier = null;
            if (File.Exists("Leveranciers.xml") == false)
            {
                leverancier = new Leverancier(Guid.NewGuid(), "Wapenfabrikant", $"Belgian Army Supplies", "TelefoonNummer", "Email", "Contactpersoon", "Wapenfabrikant in Belgie.", "BTW-Nummer", "RekeningNummer");
                LeverancierData.AddLeverancier(leverancier); //we voegen altijd een random character toe
                LeverancierData.SchrijfDataNaar("Leveranciers");
            }


            if (LeesXML("Leveranciers", out LeverancierData leverancierData))
            {
                LeverancierData = leverancierData;
                leverancier = LeverancierData.AlleLeveranciers[0]; //we gaan ervanuit dat dit onze enige zal zijn
            }

            //voor de leveranciers gaat dit maar eentje zijn. dit zal mogelijks nog kunnen aangepast worden in het form, zodat je artikelen kunt linken aan een leverancier
            //tijdelijk gaan we gewoon de artikelen die we ingelezen hebben linken met 1 leverancier en deze hier dan inschrijven

            if (leverancier != null)
            {
                var alleArtikelen = ArtikelData.AlleArtikelen;
                foreach (var artikel in alleArtikelen)
                {
                    LeverancierData.AddLeverancierArtikel(leverancier.ID, artikel.ID);
                }
            }
        }



        public void SchrijfXML<T>(T data, string xmlPath) where T : BaseData<T>, new()
        {
            if (string.IsNullOrWhiteSpace(xmlPath))
            {
                return;
            }

            if (xmlPath.Contains('.'))
            {
                int firstPointIndex = xmlPath.IndexOf('.');
                xmlPath = xmlPath.Substring(0, firstPointIndex);
            }

            //als onze file geen lengte heeft als naam kunnen we gewoon sluiten
            if (xmlPath.Length == 0) return;
            xmlPath += ".xml";


            FileStream fstream = null;
            try
            {
                if (File.Exists(xmlPath))
                {
                    fstream = File.Open(xmlPath, FileMode.Truncate);
                }
                else
                {
                    fstream = File.Create(xmlPath);
                }


                if (data != null)
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.Encoding = Encoding.UTF8;

                    using (XmlWriter writer = XmlWriter.Create(fstream, settings))
                    {
                        data.WriteXml(writer);
                    }
                }
            }
            catch (Exception ex)
            {
                //we doen hier nu niet direct iets mee 
                MessageBox.Show(ex.Message, "Probleem");
            }
            finally
            {
                fstream?.Close();
            }
        }
        public bool LeesXML<T>(string xmlPath, out T data) where T : BaseData<T>, new()
        {
            //we zetten de data standaard op null
            data = null;
            if (string.IsNullOrWhiteSpace(xmlPath))
            {
                return false;
            }

            if (xmlPath.Contains('.'))
            {
                int firstPointIndex = xmlPath.IndexOf('.');
                xmlPath = xmlPath.Substring(0, firstPointIndex);
            }

            if (xmlPath.Length == 0) return false;
            xmlPath += ".xml";

            if (File.Exists(xmlPath) == false)
            {
                return false;
            }

            using (FileStream fstream = File.OpenRead(xmlPath))
            {
                using (XmlReader reader = XmlReader.Create(fstream))
                {
                    data = new T();
                    data.ReadXml(reader);
                }
            }

            return true;
        }

        protected override void ClearObject()
        {
            BestellingData?.Clear();
            LeverancierData?.Clear();
            ArtikelData?.Clear();
            base.ClearObject();
        }
    }
}
