using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using klassen;
using System.Xml;

namespace WapenGroothandel
{
	public partial class FrmStock : Form
	{
		List<Artikel> ListArticles = new List<Artikel>();
		Artikel newArticle;
		Guid guid;
		Guid eenVerpakking;
		public FrmStock()
		{
			InitializeComponent();
		}

		private void FrmStock_Load(object sender, EventArgs e)
		{
			string pad = Environment.CurrentDirectory + @"\Stock.xml";
			string aValue = "";
			Artikel newArticle = new Artikel();

			using (XmlReader reader = XmlReader.Create(pad))
			{
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element)
					{
						aValue = reader.Name;
					}
					else if (reader.NodeType == XmlNodeType.Text)
					{
						switch (aValue)
						{
							case "guid":
								newArticle.ID = Guid.Parse(reader.Value);
								break;
							case "naam":
								newArticle.Naam = reader.Value;
								break;
							case "omschrijving":
								newArticle.Omschrijving = reader.Value;
								break;
							case "type":
								newArticle.Type = reader.Value;
								break;
							case "gewicht":
								newArticle.Gewicht = Convert.ToDouble(reader.Value);
								break;
							case "prijs":
								newArticle.Prijs = Convert.ToDecimal(reader.Value);
								break;
							case "artikelnummer":
								newArticle.Artikelnummer = Convert.ToInt32(reader.Value);
								break;
							case "modelnummer":
								newArticle.Modelnummer = Convert.ToInt32(reader.Value);
								break;
							case "serienummer":
								newArticle.Serienummer = Convert.ToInt32(reader.Value);
								break;
							case "aangemaaktOp":
								newArticle.AangemaaktOp = Convert.ToDateTime(reader.Value);
								break;
							case "garantieduur":
								newArticle.Garantieduur = Convert.ToDateTime(reader.Value);
								break;
							case "verpakking":
								newArticle.Verpakking = Guid.Parse(reader.Value);
								break;
							case "btw":
								newArticle.Btw = Convert.ToInt32(reader.Value);
								ListArticles.Add(newArticle);
								newArticle = new Artikel();
								break;
							default:
								MessageBox.Show("Er is iets fout gelopen in de switch." + aValue);
								break;
						}
					}
				}
			}
			RefreshDisplay();
		}

		private void btnAddData_Click(object sender, EventArgs e)
		{
			try
			{
				guid = Guid.NewGuid();
				eenVerpakking = Guid.NewGuid();
				newArticle = new Artikel(guid, txtName.Text, txtDescription.Text, txtType.Text, Convert.ToDouble(txtWeight.Text), Convert.ToDecimal(txtPrice.Text), Convert.ToInt32(txtArticlenumber.Text), Convert.ToInt32(txtModelnumber.Text), Convert.ToInt32(txtSerialnumber.Text), DateTime.Now, DateTime.Now.AddYears(2), eenVerpakking, Convert.ToInt32(txtBTW.Text));
				ListArticles.Add(newArticle);
				RefreshDisplay();
				EmptyTextBoxes();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult result;
			result = MessageBox.Show("Wilt u afsluiten?", "Waarschuwing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (result == DialogResult.Yes)
			{
				this.Close();
			}

		}

		public void RefreshDisplay()
		{
			lstData.DataSource = null;
			lstData.DataSource = ListArticles;
		}

		public void EmptyTextBoxes()
		{
			txtName.Text = "";
			txtType.Text = "";
			txtModelnumber.Text = "";
			txtArticlenumber.Text = "";
			txtSerialnumber.Text = "";
			txtPrice.Text = "";
			txtBTW.Text = "";
			txtDescription.Text = "";
			txtWeight.Text = "";
		}

		private void btnDeleteArticle_Click(object sender, EventArgs e)
		{
			try
			{
				ListArticles.Remove((Artikel)lstData.SelectedItem);
				RefreshDisplay();
				MessageBox.Show("Het artikel is verwijderd.", "Verwijderd");
				EmptyTextBoxes();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
				xmlWriterSettings.NewLineOnAttributes = true;
				xmlWriterSettings.Indent = true;

				using (XmlWriter writer = XmlWriter.Create(Environment.CurrentDirectory + @"\Stock.xml", xmlWriterSettings))
				{
					writer.WriteStartElement("Stock");
					writer.WriteAttributeString("datumtijd", DateTime.Now.ToString());

					foreach (Artikel thisArticle in ListArticles)
					{
						writer.WriteStartElement("Artikel");
						writer.WriteElementString("guid", Convert.ToString(thisArticle.ID));
						writer.WriteElementString("naam", thisArticle.Naam);
						writer.WriteElementString("omschrijving", thisArticle.Omschrijving);
						writer.WriteElementString("type", thisArticle.Type);
						writer.WriteElementString("gewicht", Convert.ToString(thisArticle.Gewicht));
						writer.WriteElementString("prijs", Convert.ToString(thisArticle.Prijs));
						writer.WriteElementString("artikelnummer", Convert.ToString(thisArticle.Artikelnummer));
						writer.WriteElementString("modelnummer", Convert.ToString(thisArticle.Modelnummer));
						writer.WriteElementString("serienummer", Convert.ToString(thisArticle.Serienummer));
						writer.WriteElementString("aangemaaktOp", Convert.ToString(thisArticle.AangemaaktOp));
						writer.WriteElementString("garantieduur", Convert.ToString(thisArticle.Garantieduur));
						writer.WriteElementString("verpakking", Convert.ToString(thisArticle.Verpakking));
						writer.WriteElementString("btw", Convert.ToString(thisArticle.Btw));
					}

					writer.WriteEndElement();
					MessageBox.Show("De artikelen zijn opgeslagen.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void lstData_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (lstData.SelectedItem != null)
				{
					Artikel thisArticle = (Artikel)lstData.SelectedItem;
					txtName.Text = thisArticle.Naam;
					txtType.Text = thisArticle.Type;
					txtModelnumber.Text = Convert.ToString(thisArticle.Modelnummer);
					txtArticlenumber.Text = Convert.ToString(thisArticle.Artikelnummer);
					txtSerialnumber.Text = Convert.ToString(thisArticle.Serienummer);
					txtPrice.Text = Convert.ToString(thisArticle.Prijs);
					txtBTW.Text = Convert.ToString(thisArticle.Btw);
					txtDescription.Text = thisArticle.Omschrijving;
					txtWeight.Text = Convert.ToString(thisArticle.Gewicht);
					txtID.Text = Convert.ToString(thisArticle.ID);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void bestellingenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmBestellingen bestellingen = new FrmBestellingen();
			bestellingen.Show();
		}

		private void verzendingenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmVerzendingen verzendingen = new FrmVerzendingen();
			verzendingen.Show();
		}

		private void personeelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmPersoneel personeel = new FrmPersoneel();
			personeel.Show();
		}
	}
}
