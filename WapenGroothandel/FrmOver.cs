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
	public partial class FrmOver : Form
	{
		public FrmOver()
		{
			InitializeComponent();
		}

		private void miBestellingen_Click(object sender, EventArgs e)
		{
			FrmBestellingen bestellingen = new FrmBestellingen();
			bestellingen.Show();
		}

		private void miVerzendingen_Click(object sender, EventArgs e)
		{
			FrmVerzendingen verzendingen = new FrmVerzendingen();
			verzendingen.Show();
		}

		private void miStock_Click(object sender, EventArgs e)
		{
			FrmStock stock = new FrmStock();
			stock.Show();
		}

		private void miPersoneel_Click(object sender, EventArgs e)
		{
			FrmPersoneel personeel = new FrmPersoneel();
			personeel.Show();
		}
	}
}
