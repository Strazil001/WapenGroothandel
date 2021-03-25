using klassen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WapenGroothandel
{
    public partial class FrmPersoneel : Form
    {
        //variables
        Personeel personeelslid;
        Guid guid;
        List<Personeel> LijstPersoneel = new List<Personeel>();

        public FrmPersoneel()
        {
            InitializeComponent();
        }

        //Event: Bij form laden
        private void FrmPersoneel_Load(object sender, EventArgs e)
        {
            string pad = Environment.CurrentDirectory + @"\Personeel.xml";
            string eenWaarde = "";
            Personeel nieuwPersoneel = new Personeel();

            using (XmlReader reader = XmlReader.Create(pad))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element) //start element
                    {
                        eenWaarde = reader.Name;

                    }
                    else if (reader.NodeType == XmlNodeType.Text) //text element 
                    {
                        switch (eenWaarde)
                        {
                            case "guid":
                                nieuwPersoneel.ID = Guid.Parse(reader.Value);
                                break;
                            case "naam":
                                nieuwPersoneel.Naam = reader.Value;
                                break;
                            case "voornaam":
                                nieuwPersoneel.Voornaam = reader.Value;
                                break;
                            case "geboorteDatum":
                                nieuwPersoneel.GeboorteDatum = DateTime.ParseExact(reader.Value, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            case "geslacht":
                                nieuwPersoneel.Geslacht = Convert.ToChar(reader.Value);
                                break;
                            case "rijksregisterNummer":
                                nieuwPersoneel.RijksregisterNummer = reader.Value;
                                break;
                            case "functie":
                                nieuwPersoneel.Functie = reader.Value;
                                break;
                            case "gebruikersNaam":
                                nieuwPersoneel.GebruikersNaam = reader.Value;
                                break;
                            case "wachtwoord":
                                nieuwPersoneel.Wachtwoord = reader.Value;
                                break;
                            case "loon":
                                nieuwPersoneel.Loon = Convert.ToDecimal(reader.Value);
                                break;
                            case "telNummer":
                                nieuwPersoneel.TelNummer = reader.Value;
                                break;
                            case "eMail":
                                nieuwPersoneel.EMail = reader.Value;
                                break;
                            case "contactpersoon":
                                nieuwPersoneel.Contactpersoon = reader.Value;
                                break;
                            case "opmerking":
                                nieuwPersoneel.Opmerking = reader.Value;
                                LijstPersoneel.Add(nieuwPersoneel);
                                nieuwPersoneel = new Personeel();
                                break;
                            default:
                                MessageBox.Show("Er gaat iets fout in de switch met : " + eenWaarde);
                                break;
                        }
                    }
                }
            }
            RefreshDisplay();
        }

        //Event: Personeelslid verwijderen
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LijstPersoneel.Remove((Personeel)lstDisplay.SelectedItem);
                RefreshDisplay();
                MessageBox.Show("Personeelslid is verwijderd.", "Verwijdering.");
                tekstBoksenLeegmaken();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Event: Wijzigen
        private void btnWijzigen_Click(object sender, EventArgs e)
        {

            //Input validation: e-mail
            if (!(txtEMail.Text.Contains('.')) || !(txtEMail.Text.Contains('@')))
            {
                MessageBox.Show("Het e-mail adres is ongeldig. Gelieve een correct e-mail adres in te geven", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Input validation: geslacht
            if (txtGelacht.Text.Length > 1)
            {
                MessageBox.Show("Gelieve geslacht in te geven als 'm' (man), 'v' (vrouw) of 'a' (ander)", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Input validation: loon
            if (!(decimal.TryParse(txtLoon.Text, out decimal loonOut)))
            {
                MessageBox.Show("Gelieve het loon correct in te geven", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                LijstPersoneel.Remove((Personeel)lstDisplay.SelectedItem);
                guid = Guid.NewGuid();
                LijstPersoneel.Insert(lstDisplay.SelectedIndex, new Personeel(guid, txtFamilieNaam.Text, txtVoornaam.Text, txtTelNummer.Text, txtEMail.Text, txtContactPersoon.Text, txtOpmerking.Text, txtRijksregisternummer.Text, dateTimePicker1.Value, txtFunctie.Text, txtGebrNaam.Text, txtWachtwoord.Text, Convert.ToChar(txtGelacht.Text), Convert.ToDecimal(txtLoon.Text)));
                RefreshDisplay();
                MessageBox.Show("Gegevens van het personeelslid zijn gewijzigd.", "Wijziging");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //Event: Toevoegen
        private void button3_Click(object sender, EventArgs e)
        {
            //Input validation: e-mail
            if (!(txtEMail.Text.Contains('.')) || !(txtEMail.Text.Contains('@')))
            {
                MessageBox.Show("Het e-mail adres is ongeldig. Gelieve een correct e-mail adres in te geven", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Input validation: geslacht
            if (txtGelacht.Text.Length > 1)
            {
                MessageBox.Show("Gelieve geslacht in te geven als 'm' (man), 'v' (vrouw) of 'a' (ander)", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Input validation: loon
            if (!(decimal.TryParse(txtLoon.Text, out decimal loonOut)))
            {
                MessageBox.Show("Gelieve het loon correct in te geven", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                guid = Guid.NewGuid();
                personeelslid = new Personeel(guid, txtFamilieNaam.Text, txtVoornaam.Text, txtTelNummer.Text, txtEMail.Text, txtContactPersoon.Text, txtOpmerking.Text, txtRijksregisternummer.Text, dateTimePicker1.Value, txtFunctie.Text, txtGebrNaam.Text, txtWachtwoord.Text, Convert.ToChar(txtGelacht.Text), Convert.ToDecimal(txtLoon.Text));
                LijstPersoneel.Add(personeelslid);
                RefreshDisplay();
                tekstBoksenLeegmaken();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //Event: Opslaan
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            try
            {
                //XML meer leesbaar maken voor ons
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.NewLineOnAttributes = true;
                xmlWriterSettings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(Environment.CurrentDirectory + @"\Personeel.xml", xmlWriterSettings))
                {
                    //Begin van ons XML bestand: het bestand bestaat uit één strartelement, 13 nodes en een eindelement.
                    writer.WriteStartElement("Personeelsleden");
                    writer.WriteAttributeString("datumtijd", DateTime.Now.ToString());

                    foreach (Personeel ditPersoneelsLid in LijstPersoneel)
                    {
                        //Een node of element
                        writer.WriteStartElement("Personeel");
                        writer.WriteElementString("guid", Convert.ToString(ditPersoneelsLid.ID));
                        writer.WriteElementString("naam", ditPersoneelsLid.Naam);
                        writer.WriteElementString("voornaam", ditPersoneelsLid.Voornaam);
                        writer.WriteElementString("geboorteDatum", ditPersoneelsLid.GeboorteDatum.ToString("dd/MM/yyyy"));
                        writer.WriteElementString("geslacht", ditPersoneelsLid.Geslacht.ToString());
                        writer.WriteElementString("rijksregisterNummer", ditPersoneelsLid.RijksregisterNummer);
                        writer.WriteElementString("functie", ditPersoneelsLid.Functie);
                        writer.WriteElementString("gebruikersNaam", ditPersoneelsLid.GebruikersNaam);
                        writer.WriteElementString("wachtwoord", ditPersoneelsLid.Wachtwoord);
                        writer.WriteElementString("loon", ditPersoneelsLid.Loon.ToString());
                        writer.WriteElementString("telNummer", ditPersoneelsLid.TelNummer);
                        writer.WriteElementString("eMail", ditPersoneelsLid.EMail);
                        writer.WriteElementString("contactpersoon", ditPersoneelsLid.Contactpersoon);
                        writer.WriteElementString("opmerking", ditPersoneelsLid.Opmerking);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    MessageBox.Show("De personeelsdata zijn opgeslagen.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Event: Personeelslid aanklikken
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstDisplay.SelectedItem != null)
                {
                    Personeel dezePersoon = (Personeel)lstDisplay.SelectedItem;
                    txtFamilieNaam.Text = dezePersoon.Naam;
                    txtVoornaam.Text = dezePersoon.Voornaam;
                    dateTimePicker1.Value = dezePersoon.GeboorteDatum;
                    txtGelacht.Text = Convert.ToString(dezePersoon.Geslacht);

                    txtRijksregisternummer.Text = dezePersoon.RijksregisterNummer;
                    txtFunctie.Text = dezePersoon.Functie;
                    txtGebrNaam.Text = dezePersoon.GebruikersNaam;
                    txtWachtwoord.Text = dezePersoon.Wachtwoord;
                    txtLoon.Text = Convert.ToString(dezePersoon.Loon);
                    txtTelNummer.Text = dezePersoon.TelNummer;
                    txtEMail.Text = dezePersoon.EMail;
                    txtContactPersoon.Text = dezePersoon.Contactpersoon;
                    txtOpmerking.Text = dezePersoon.Opmerking;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Methode
        public void RefreshDisplay()
        {
            lstDisplay.DataSource = null;
            lstDisplay.DataSource = LijstPersoneel;
        }

        //Methode
        public void tekstBoksenLeegmaken()
        {
            txtFamilieNaam.Text = "";
            txtVoornaam.Text = "";
            txtGelacht.Text = "";
            txtRijksregisternummer.Text = "";
            txtFunctie.Text = "";
            txtGebrNaam.Text = "";
            txtWachtwoord.Text = "";
            txtLoon.Text = "";
            txtTelNummer.Text = "";
            txtEMail.Text = "";
            txtContactPersoon.Text = "";
            txtOpmerking.Text = "";
        }

        //Event: Toevoegen
        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            tekstBoksenLeegmaken();
        }

        //Event: Sluiten
        private void btnSluiten_Click(object sender, EventArgs e)
        {
            //Message, vergeet niet op te slaan voor af te sluiten. Aflsuiten: Ja/Nee
            DialogResult result;
            result = MessageBox.Show("Vergeet niet op te slaan alvorens af te sluiten. Bent u zeker dat u wilt sluiten?", "Waarschuwing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //Top menu
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

        private void overToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOver over = new FrmOver();
            over.Show();
        }
    }
}
