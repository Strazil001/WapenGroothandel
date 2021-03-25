using klassen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WapenGroothandel
{
    public partial class FrmVerzendingen : Form
    {
        public FrmVerzendingen()
        {
            InitializeComponent();
        }

        List<Klant> mijnKlanten = new List<Klant>();
        List<Bestellingen> mijnBestellingen = new List<Bestellingen>();

        private void bestellingenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBestellingen bestellingen = new FrmBestellingen();
            bestellingen.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStock stock = new FrmStock();
            stock.Show();
        }

        private void personeelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersoneel personeel = new FrmPersoneel();
            personeel.Show();
        }

        private void financieleInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ...
        }

        private void overToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOver over = new FrmOver();
            over.Show();
        }

        private void btnKlantOpslaan_Click(object sender, EventArgs e)
        {
            try
            {
                SerializeXmlKlanten("Klanten.xml");
                MessageBox.Show("Klant(en) toegevoegd", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException fex)
            {
                MessageBox.Show(fex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLijstInlezen_Click(object sender, EventArgs e)
        {

        }

        private void btnOfferteVerzenden_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnuleer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerzenden_Click(object sender, EventArgs e)
        {

        }

        private void cbMetFactuur_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmVerzendingen_Load(object sender, EventArgs e)
        {
            try
            {
                DeserializeXmlKlanten("Klanten.xml");
                lbKlanten.DataSource = mijnKlanten;
                lbKlanten.SelectedIndex = -1;
                Leegmaken();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Leegmaken()
        {
            txtNaam.Clear();
            txtVoornaam.Clear();
            txtTelefoonNr.Clear();
            txtEmail.Clear();
            txtContactPersoon.Clear();
            txtOpmerkingen.Clear();
            txtBtwNummer.Clear();
            txtLeverAdresStraat.Clear();
            txtLeverAdresHuisNr.Clear();
            txtLeverAdresBusNr.Clear();
            txtLeverAdresPostcode.Clear();
            txtLeverAdresGemeente.Clear();
            txtLeverAdresLand.Clear();
            txtFacuratieAdresStraat.Clear();
            txtFacuratieAdresHuisNr.Clear();
            txtFacuratieAdresBusNr.Clear();
            txtFacuratieAdresPostcode.Clear();
            txtFacuratieAdresGemeente.Clear();
            txtFacuratieAdresLand.Clear();
        }

        private void btnKlantToevoegen_Click(object sender, EventArgs e)
        {
            try
            {
                Adres eenLeverAdres = new Adres(Guid.NewGuid(), txtLeverAdresStraat.Text, txtLeverAdresHuisNr.Text, txtLeverAdresBusNr.Text,
                    int.Parse(txtLeverAdresPostcode.Text), txtLeverAdresGemeente.Text, txtLeverAdresLand.Text);
                Adres eenFacturatieAdres = new Adres(Guid.NewGuid(), txtFacuratieAdresStraat.Text, txtFacuratieAdresHuisNr.Text, txtFacuratieAdresBusNr.Text,
                    int.Parse(txtFacuratieAdresPostcode.Text), txtFacuratieAdresGemeente.Text, txtFacuratieAdresLand.Text);
                Klant eenKlant = new Klant(Guid.NewGuid(), txtNaam.Text, txtVoornaam.Text, txtTelefoonNr.Text, txtEmail.Text, txtContactPersoon.Text,
                    txtOpmerkingen.Text, txtBtwNummer.Text, eenFacturatieAdres.ToString(), eenLeverAdres.ToString());
                mijnKlanten.Add(eenKlant);
                Leegmaken();
                RefreshListbox();
            }
            catch (FormatException fex)
            {
                MessageBox.Show(fex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLijstInlezen_Click_1(object sender, EventArgs e)
        {
            try
            {
                DeserializeXmlBestellingen("Verzendingen.xml");
                lbDisplayLijst.DataSource = null;
                lbDisplayLijst.DataSource = mijnBestellingen;
                if (lbDisplayLijst.SelectedIndex != -1)
                {
                    Bestellingen bestelling = lbDisplayLijst.Items[lbDisplayLijst.SelectedIndex] as Bestellingen;
                    txtArtikelnummer.Text = bestelling.Artikelnummer.ToString();
                    txtModelnummer.Text = bestelling.Modelnummer.ToString();
                    txtAantal.Text = bestelling.Hoeveelheid.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbKlanten.SelectedIndex != -1)
                {
                    Klant klant = lbKlanten.Items[lbKlanten.SelectedIndex] as Klant;
                    txtNaam.Text = klant.Naam;
                    txtVoornaam.Text = klant.Voornaam;
                    txtTelefoonNr.Text = klant.TelNummer;
                    txtEmail.Text = klant.EMail;
                    txtContactPersoon.Text = klant.Contactpersoon;
                    txtOpmerkingen.Text = klant.Opmerking;
                    txtBtwNummer.Text = klant.BTWNummer;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SerializeXmlKlanten(string filename)
        {
            using (Stream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Klant>));
                serializer.Serialize(fs, mijnKlanten);
            }
        }
        public List<Klant> DeserializeXmlKlanten(string filename)
        {
            XmlSerializer serializer1 = new XmlSerializer(typeof(List<Klant>));
            using (FileStream fs1 = File.OpenRead(filename))
            {
                return mijnKlanten = (List<Klant>)serializer1.Deserialize(fs1);
            }
        }
        public void SerializeXmlBestellingen(string filename)
        {
            using (Stream fs2 = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Bestellingen>));
                serializer2.Serialize(fs2, mijnBestellingen);
            }
        }
        public List<Bestellingen> DeserializeXmlBestellingen(string filename)
        {
            XmlSerializer serializer3 = new XmlSerializer(typeof(List<Bestellingen>));
            using (FileStream fs3 = File.OpenRead(filename))
            {
                return mijnBestellingen = (List<Bestellingen>)serializer3.Deserialize(fs3);
            }
        }
        private void btnKlantVerwijderen_Click(object sender, EventArgs e)
        {
            try
            {
                mijnKlanten.Remove((Klant)lbKlanten.SelectedItem);
                RefreshListbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void RefreshListbox()
        {
            lbKlanten.DataSource = null;
            lbKlanten.DataSource = mijnKlanten;
        }

        private void btnKlantWijzigen_Click(object sender, EventArgs e)
        {
            try
            {
                mijnKlanten.Remove((Klant)lbKlanten.SelectedItem);
                Adres eenLeverAdres = new Adres(Guid.NewGuid(), txtLeverAdresStraat.Text, txtLeverAdresHuisNr.Text, txtLeverAdresBusNr.Text,
                    int.Parse(txtLeverAdresPostcode.Text), txtLeverAdresGemeente.Text, txtLeverAdresLand.Text);
                Adres eenFacturatieAdres = new Adres(Guid.NewGuid(), txtFacuratieAdresStraat.Text, txtFacuratieAdresHuisNr.Text, txtFacuratieAdresBusNr.Text,
                    int.Parse(txtFacuratieAdresPostcode.Text), txtFacuratieAdresGemeente.Text, txtFacuratieAdresLand.Text);
                Klant eenKlant = new Klant(Guid.NewGuid(), txtNaam.Text, txtVoornaam.Text, txtTelefoonNr.Text, txtEmail.Text, txtContactPersoon.Text,
                    txtOpmerkingen.Text, txtBtwNummer.Text, eenFacturatieAdres.ToString(), eenLeverAdres.ToString());
                mijnKlanten.Insert(lbKlanten.SelectedIndex, eenKlant);
                RefreshListbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bestellingen bestelling = new Bestellingen(DateTime.Now, int.Parse(txtArtikelnummer.Text), int.Parse(txtModelnummer.Text), int.Parse(txtAantal.Text));
            mijnBestellingen.Add(bestelling);
            lbDisplayLijst.DataSource = null;
            lbDisplayLijst.DataSource = mijnBestellingen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SerializeXmlBestellingen("Verzendingen.xml");
            }
            catch (FormatException fex)
            {
                MessageBox.Show(fex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbDisplayLijst_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbDisplayLijst.SelectedIndex != -1)
                {
                    Bestellingen b = lbDisplayLijst.Items[lbDisplayLijst.SelectedIndex] as Bestellingen;
                    txtArtikelnummer.Text = b.Artikelnummer.ToString();
                    txtModelnummer.Text = b.Modelnummer.ToString();
                    txtAantal.Text = b.Hoeveelheid.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
