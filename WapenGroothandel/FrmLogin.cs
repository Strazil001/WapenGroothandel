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

namespace WapenGroothandel
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        List<Userww> LijstPersoneel = new List<Userww>();

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // usernames en wachtwoorden uit personeel xml inladen
            string pad = Environment.CurrentDirectory + @"\Personeel.xml";
            string eenWaarde = "";
            Userww nieuwPersoneel = new Userww();

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

                            case "gebruikersNaam":
                                nieuwPersoneel.GebruikersNaam = reader.Value;
                                break;
                            case "wachtwoord":
                                nieuwPersoneel.Wachtwoord = reader.Value;
                                LijstPersoneel.Add(nieuwPersoneel);
                                nieuwPersoneel = new Userww();
                                break;

                            default:
                                break;
                        }
                    }
                }
            }

        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnAnnuleer_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void btnOke_Click(object sender, EventArgs e)
        {
            if ((txtGebruikersnaam.Text == "guest") && (txtWachtwoord.Text == "guest"))
            {
                this.Close();
            }
            else
            {
                foreach (Userww user in LijstPersoneel)
                {
                    if ((txtGebruikersnaam.Text == user.GebruikersNaam) && (txtWachtwoord.Text == user.Wachtwoord))
                    {
                        this.Close();
                        return;
                    }
                }
                MessageBox.Show("Gebruikersnaam en wachtwoord komen niet overeen.", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGebruikersnaam.Clear();
                txtWachtwoord.Clear();
                return;
            }
        }
    }
}
