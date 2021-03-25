
namespace WapenGroothandel
{
	partial class FrmOver
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOver));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.miBestellingen = new System.Windows.Forms.ToolStripMenuItem();
			this.miVerzendingen = new System.Windows.Forms.ToolStripMenuItem();
			this.miStock = new System.Windows.Forms.ToolStripMenuItem();
			this.miPersoneel = new System.Windows.Forms.ToolStripMenuItem();
			this.miFinancieleInfo = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Tan;
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.miBestellingen,
			this.miVerzendingen,
			this.miStock,
			this.miPersoneel,
			this.miFinancieleInfo});
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.menuToolStripMenuItem.Text = "Menu";
			// 
			// miBestellingen
			// 
			this.miBestellingen.Name = "miBestellingen";
			this.miBestellingen.Size = new System.Drawing.Size(180, 22);
			this.miBestellingen.Text = "Bestellingen";
			this.miBestellingen.Click += new System.EventHandler(this.miBestellingen_Click);
			// 
			// miVerzendingen
			// 
			this.miVerzendingen.Name = "miVerzendingen";
			this.miVerzendingen.Size = new System.Drawing.Size(180, 22);
			this.miVerzendingen.Text = "Verzendingen";
			this.miVerzendingen.Click += new System.EventHandler(this.miVerzendingen_Click);
			// 
			// miStock
			// 
			this.miStock.Name = "miStock";
			this.miStock.Size = new System.Drawing.Size(180, 22);
			this.miStock.Text = "Stock";
			this.miStock.Click += new System.EventHandler(this.miStock_Click);
			// 
			// miPersoneel
			// 
			this.miPersoneel.Name = "miPersoneel";
			this.miPersoneel.Size = new System.Drawing.Size(180, 22);
			this.miPersoneel.Text = "Personeel";
			this.miPersoneel.Click += new System.EventHandler(this.miPersoneel_Click);
			// 
			// miFinancieleInfo
			// 
			this.miFinancieleInfo.Name = "miFinancieleInfo";
			this.miFinancieleInfo.Size = new System.Drawing.Size(180, 22);
			this.miFinancieleInfo.Text = "Financiele info";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Tan;
			this.label1.Location = new System.Drawing.Point(519, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(269, 37);
			this.label1.TabIndex = 1;
			this.label1.Text = "WEAPONS ARE US";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Tan;
			this.label2.Location = new System.Drawing.Point(12, 417);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(130, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Since 1972";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// FrmOver
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Tan;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmOver";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Over";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem miBestellingen;
		private System.Windows.Forms.ToolStripMenuItem miVerzendingen;
		private System.Windows.Forms.ToolStripMenuItem miStock;
		private System.Windows.Forms.ToolStripMenuItem miPersoneel;
		private System.Windows.Forms.ToolStripMenuItem miFinancieleInfo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}