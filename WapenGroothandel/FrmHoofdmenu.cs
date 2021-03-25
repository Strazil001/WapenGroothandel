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
    public partial class FrmHoofdmenu : Form
    {
        public FrmHoofdmenu()
        {
            InitializeComponent();
        }

        private void FrmHoofdmenu_Load(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            login.ShowDialog();
        }

        private void leveringenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVerzendingen verzendingen = new FrmVerzendingen();
            verzendingen.Show();
        }

        private void bestelingenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBestellingen bestellingen = new FrmBestellingen();
            bestellingen.Show();
        }

        private void personeelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersoneel vensterPersoneel = new FrmPersoneel();
            vensterPersoneel.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStock vensterStock = new FrmStock();
            vensterStock.Show();
        }

        private void personeelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmPersoneel vensterPersoneel = new FrmPersoneel();
            vensterPersoneel.Show();
        }
    }
}
