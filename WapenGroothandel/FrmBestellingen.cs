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

namespace WapenGroothandel
{
    public partial class FrmBestellingen : Form
    {
        private List<Artikel> _alleArtikelen = new List<Artikel>();
        private List<ArtikelBestelling> _gekozenArtikelen = new List<ArtikelBestelling>();
        private List<Leverancier> _leveranciers;
        private Leverancier _gekozenLeverancier = null;

        public FrmBestellingen()
        {
            InitializeComponent();
            this.FormClosed += FormClosedCallback;
        }
        private void btnAnnuleer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmBestellingen_Load(object sender, EventArgs e)
        {
            UpdateLeveranciers();
        }
        private void lbLeveranciers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //we zorgen ervoor dat we zeker in de list kunnen zitten
            if (lbLeveranciers.SelectedIndex < 0 || lbLeveranciers.SelectedIndex >= _leveranciers.Count) return;
            //we zetten de artikelen die we kunnen selecteren
            Leverancier leverancier = _leveranciers[lbLeveranciers.SelectedIndex];
            if (leverancier == null)
            {
                //we can throw an exception here like error loading leverancier
                return;
            }
            else if (_gekozenLeverancier == leverancier)
            {
                //we moeten geen data aanpassen;
                return;
            }

            _gekozenLeverancier = leverancier;
            _alleArtikelen = DataManager.Instance.LeverancierData.AlleArtikelenVanLeverancier(leverancier.ID);
            _alleArtikelen.Sort((a, b) => a.Naam.CompareTo(b.Naam));

            //we maken de strings voor de artikelen
            List<string> artikelLijst = new List<string>();
            for (int i = 0; i < _alleArtikelen.Count; ++i)
            {
                artikelLijst.Add($"{_alleArtikelen[i].Naam}".PadRight(20) + $"Prijs: {_alleArtikelen[i].Prijs.ToString("0.00")}");
            }
            lbArtikelen.DataSource = null;
            lbArtikelen.DataSource = artikelLijst;

            _gekozenArtikelen.Clear();
            UpdateGekozenArtikelen();
        }
        private void btnArtikelToevoegen_Click(object sender, EventArgs e)
        {
            if (lbArtikelen.SelectedIndex < 0 || lbArtikelen.SelectedIndex >= _alleArtikelen.Count)
            {
                //we can throw an error here if we want.
                return;
            }

            Artikel artikel = _alleArtikelen[lbArtikelen.SelectedIndex];
            if (artikel == null)
            {
                //throw exception or handle error here
                return;
            }

            //we add this to the shopping cart with the number
            _gekozenArtikelen.Add(new ArtikelBestelling(Guid.NewGuid(), artikel.ID, Guid.Empty, (int)nudAantal.Value));
            UpdateGekozenArtikelen();
        }
        private void btnArtikelVerwijderen_Click(object sender, EventArgs e)
        {
            if (lbGekozenArtikelen.SelectedIndex < 0 || lbGekozenArtikelen.SelectedIndex >= _gekozenArtikelen.Count)
            {
                //we can throw an error here if we want.
                return;
            }
            ArtikelBestelling artikelBestelling = _gekozenArtikelen[lbGekozenArtikelen.SelectedIndex];
            Artikel artikel = DataManager.Instance.ArtikelData.GetArtikel(artikelBestelling.ArtikelID);
            if (artikel == null)
            {
                //throw exception or handle error here
                return;
            }

            //we remove this from the shopping cart
            _gekozenArtikelen.Remove(artikelBestelling);
            UpdateGekozenArtikelen();
        }
        private void UpdateGekozenArtikelen()
        {
            //we filteren eerst de gekozen artikelen zodat we enkel unieke values hebben
            Dictionary<string, ArtikelBestelling> enkelUniekeArtikelen = new Dictionary<string, ArtikelBestelling>();

            string gekozenArtikelID;
            foreach (var gekozenArtikel in _gekozenArtikelen)
            {
                gekozenArtikelID = gekozenArtikel.ArtikelID.ToString();
                if (enkelUniekeArtikelen.ContainsKey(gekozenArtikelID))
                {
                    enkelUniekeArtikelen[gekozenArtikelID].Hoeveelheid += gekozenArtikel.Hoeveelheid;
                }
                else
                {
                    enkelUniekeArtikelen.Add(gekozenArtikelID, gekozenArtikel);
                }
            }

            _gekozenArtikelen = new List<ArtikelBestelling>(enkelUniekeArtikelen.Values);

            //we change the list of strings we show
            List<string> artikelLijst = new List<string>();
            decimal totaalPrijs = 0;
            Artikel artikel;
            for (int i = 0; i < _gekozenArtikelen.Count; ++i)
            {
                artikel = DataManager.Instance.ArtikelData.GetArtikel(_gekozenArtikelen[i].ArtikelID);
                artikelLijst.Add($"{artikel.Naam}".PadRight(15) + $"Prijs: {artikel.Prijs.ToString("0.00").PadRight(15) + $"Aantal: {_gekozenArtikelen[i].Hoeveelheid}" }");
                totaalPrijs += artikel.Prijs * _gekozenArtikelen[i].Hoeveelheid;
            }

            lbGekozenArtikelen.DataSource = null;
            lbGekozenArtikelen.DataSource = artikelLijst;

            txtTotaalPrijs.Text = totaalPrijs.ToString("0.00");
        }

        private void UpdateLeveranciers()
        {
            //we moeten eerst de artikelen laden die we kunnen selecteren
            _leveranciers = DataManager.Instance.LeverancierData.AlleLeveranciers;

            //we creeren een naam string voor de leveranciers
            List<string> displayNames = new List<string>();
            foreach (var leverancier in _leveranciers)
            {
                //we maken een naam aan
                displayNames.Add($"{leverancier.Naam} {leverancier.Voornaam}");
            }

            displayNames.Sort();
            lbLeveranciers.DataSource = displayNames;

            if (lbLeveranciers.Items.Count > 0)
            {
                lbLeveranciers.SelectedIndex = 0;
            }
        }

        private void FormClosedCallback(object obj, FormClosedEventArgs args)
        {
            DataManager.Clear();
        }
        private void lbArtikelen_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGekozenArtikel.Text = string.Empty;
            if (lbArtikelen.SelectedIndex < 0 || lbArtikelen.SelectedIndex >= _alleArtikelen.Count)
            {
                return;
            }

            Artikel artikel = _alleArtikelen[lbArtikelen.SelectedIndex];
            if (artikel == null)
            {
                //throw exception or handle error here
                return;
            }

            string artikelInfo =
                $"Productnaam: {artikel.Naam}" + Environment.NewLine +
                $"Modelnummer: {artikel.Modelnummer}" + Environment.NewLine +
                $"Prijs: {artikel.Prijs}" + Environment.NewLine +
                $"Gewicht: {artikel.Gewicht} Kg" + Environment.NewLine +
                $"Type: {artikel.Type}" + Environment.NewLine + Environment.NewLine +
                $"Omschrijving: " + Environment.NewLine + artikel.Omschrijving;
            txtGekozenArtikel.Text = artikelInfo;
            nudAantal.Value = nudAantal.Minimum;
        }
        private void btnOfferteOpmaken_Click(object sender, EventArgs e)
        {
            //we moeten de gegevens van de leverancier dus ook hebben
            if (_gekozenLeverancier == null) return;

            //we maken een klant aan met de gegevens
            //we checken deze gevens na of deze juist zijn
            try
            {
                ValideerIngevuldeData(out Klant klant);
                Bestelling bestelling = new Bestelling(Guid.NewGuid(), "Aankoop", DateTime.Now, klant.ID, _gekozenLeverancier.ID);
                //we voegen de data toe en schrijven deze uit
                DataManager.Instance.BestellingData.AddBestelling(bestelling, _gekozenArtikelen);
                DataManager.Instance.BestellingData.SchrijfDataNaar("Bestellingen");

                //we schrijven de uiteindelijke bestelling uit naar een offerte;
                BestellingAanvraag aanvraag = new BestellingAanvraag();
                aanvraag.SetData(klant, bestelling, _gekozenArtikelen);
                aanvraag.SchrijfDataNaar($"Aanvraag_{klant.Naam}_{klant.Voornaam}_{klant.ID}", true);
                MessageBox.Show("Offerte succesvol aangemaakt", "Voltooid", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Opgelet!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool ValideerIngevuldeData(out Klant klant)
        {
            klant = null;

            if (_gekozenArtikelen.Count == 0) throw new Exception("Je hebt geen producten geselecteerd.");

            klant = new Klant();
            if (string.IsNullOrWhiteSpace(txtContactpersoon.Text)) throw new Exception("Je bent contactgegevens vergeten.");
            klant.Contactpersoon = txtContactpersoon.Text;

            if (string.IsNullOrWhiteSpace(txtBtwNummer.Text)) throw new Exception("Je bent contactgegevens vergeten.");
            klant.BTWNummer = txtBtwNummer.Text;

            if (string.IsNullOrWhiteSpace(txtEmail.Text)) throw new Exception("Je bent contactgegevens vergeten.");
            klant.EMail = txtEmail.Text;

            if (string.IsNullOrWhiteSpace(txtNaam.Text)) throw new Exception("Je bent contactgegevens vergeten.");
            klant.Naam = txtNaam.Text;

            if (string.IsNullOrWhiteSpace(txtVoornaam.Text)) throw new Exception("Je bent contactgegevens vergeten.");
            klant.Voornaam = txtVoornaam.Text;

            if (string.IsNullOrWhiteSpace(txtLeverAdress.Text)) throw new Exception("Je bent contactgegevens vergeten.");
            klant.Leveradres = txtLeverAdress.Text;

            if (string.IsNullOrWhiteSpace(txtFactuurAdres.Text)) throw new Exception("Je bent contactgegevens vergeten.");
            klant.Factuuradres = txtFactuurAdres.Text;

            if (string.IsNullOrWhiteSpace(txtTelefoon.Text)) throw new Exception("Je bent contactgegevens vergeten.");
            klant.TelNummer = txtTelefoon.Text;


            return true;
        }

        private void menuOverzichtBestellingen_Click(object sender, EventArgs e)
        {
            //we tonen een scherm waar al de bestellingen opstaan voor een leverancier
            FrmOverzichtBestellingen overzichtBestelling = new FrmOverzichtBestellingen();
            overzichtBestelling.Show();
        }

        private void menuVoegLeverancierToe_Click(object sender, EventArgs e)
        {

        }
    }
}
