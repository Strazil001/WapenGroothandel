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
    public partial class FrmOverzichtBestellingen : Form
    {
        private Leverancier _gekozenLeverancier = null;
        private List<Leverancier> _leveranciers;
        private List<Bestelling> _bestellingen;
        private List<ArtikelBestelling> _artikelBestellingen;
        public FrmOverzichtBestellingen()
        {
            InitializeComponent();
        }

        private void FrmOverzichtBestellingen_Load(object sender, EventArgs e)
        {
            //we laden de leveranciers
            _leveranciers = DataManager.Instance.LeverancierData.AlleLeveranciers;

            List<string> leverancierDisplays = new List<string>();
            for (int i = 0; i < _leveranciers.Count; ++i)
            {
                leverancierDisplays.Add($"{_leveranciers[i].Naam} { _leveranciers[i].Voornaam}");
            }
            lbLeveranciers.DataSource = leverancierDisplays;

            if (_leveranciers.Count > 0)
            {
                lbLeveranciers.SelectedIndex = 0;
            }

        }

        private void lbLeveranciers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_leveranciers.Count <= 0 || lbLeveranciers.SelectedIndex < 0) return;

            Leverancier leverancier = _leveranciers[lbLeveranciers.SelectedIndex];
            if (leverancier == null || leverancier == _gekozenLeverancier) return;

            //we vullen de data in voor de bestellingen en daarna zetten we de selected index van het artikel

            _bestellingen = DataManager.Instance.BestellingData.AlleBestellingenVanLeverancier(leverancier.ID);
            _bestellingen.OrderByDescending(x => x.Datum);
            List<string> bestellingDisplays = new List<string>();

            for (int i = 0; i < _bestellingen.Count; ++i)
            {
                bestellingDisplays.Add($"Bestelling_{i}_{_bestellingen[i].Datum}");
            }

            txtArtikelOverzicht.Text = string.Empty;
            txtOpmerking.Text = string.Empty;

            lbBestellingen.DataSource = null;
            lbBestellingen.DataSource = bestellingDisplays;

            if (_bestellingen.Count > 0)
            {
                lbBestellingen.SelectedIndex = 0;
            }
            else
            {
                lbArtikelen.DataSource = null;
            }

        }

        private void lbBestellingen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBestellingen.SelectedIndex < 0) return;
            //we lezen de bestelling data in 
            Bestelling bestelling = _bestellingen[lbBestellingen.SelectedIndex];

            if (bestelling == null) return;
            //we krijgen alle artikelen van de bestelling
            _artikelBestellingen = DataManager.Instance.BestellingData.AlleArtikelBestellingVanBestelling(bestelling.ID);
            List<string> artikelDisplays = new List<string>();

            Artikel artikel;
            foreach (var bArtikel in _artikelBestellingen)
            {
                artikel = DataManager.Instance.ArtikelData.GetArtikel(bArtikel.ArtikelID);
                if (artikel == null) continue;
                artikelDisplays.Add($"{artikel.Naam} {bArtikel.Hoeveelheid}");
            }

            txtArtikelOverzicht.Text = string.Empty;
            txtOpmerking.Text = string.Empty;

            lbArtikelen.DataSource = null;
            lbArtikelen.DataSource = artikelDisplays;

            if (_artikelBestellingen.Count > 0)
            {
                lbArtikelen.SelectedIndex = 0;
            }
            else
            {
                lbArtikelen.DataSource = null;
            }

        }

        private void lbArtikelen_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtArtikelOverzicht.Text = string.Empty;
            txtOpmerking.Text = string.Empty;

            //we lezen het artikel en tonen de naam en omschrijving
            txtArtikelOverzicht.Text = string.Empty;
            if (lbArtikelen.SelectedIndex < 0) return;
            ArtikelBestelling bArtikel = _artikelBestellingen[lbArtikelen.SelectedIndex];
            if (bArtikel == null) return;
            Artikel artikel = DataManager.Instance.ArtikelData.GetArtikel(bArtikel.ArtikelID);
            if (artikel == null) return; //we should throw some errors to catch here
            string overzichtText =
                $"Productnaam: {artikel.Naam}" + Environment.NewLine +
                $"Modelnummer: {artikel.Modelnummer}" + Environment.NewLine +
                $"Artikelnummer: {artikel.Artikelnummer}" + Environment.NewLine +
                $"Aangemaakt op: {artikel.AangemaaktOp}" + Environment.NewLine +
                $"Prijs: {artikel.Prijs.ToString("0.00")}";

            txtArtikelOverzicht.Text = overzichtText;
            txtOpmerking.Text = artikel.Type + Environment.NewLine + artikel.Omschrijving;
        }
    }
}
