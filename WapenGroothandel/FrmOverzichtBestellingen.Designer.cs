
namespace WapenGroothandel
{
    partial class FrmOverzichtBestellingen
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
            this.lbLeveranciers = new System.Windows.Forms.ListBox();
            this.lbBestellingen = new System.Windows.Forms.ListBox();
            this.txtArtikelOverzicht = new System.Windows.Forms.TextBox();
            this.lbArtikelen = new System.Windows.Forms.ListBox();
            this.txtOpmerking = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbLeveranciers
            // 
            this.lbLeveranciers.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeveranciers.FormattingEnabled = true;
            this.lbLeveranciers.ItemHeight = 16;
            this.lbLeveranciers.Location = new System.Drawing.Point(12, 24);
            this.lbLeveranciers.Name = "lbLeveranciers";
            this.lbLeveranciers.Size = new System.Drawing.Size(295, 100);
            this.lbLeveranciers.TabIndex = 0;
            this.lbLeveranciers.SelectedIndexChanged += new System.EventHandler(this.lbLeveranciers_SelectedIndexChanged);
            // 
            // lbBestellingen
            // 
            this.lbBestellingen.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBestellingen.FormattingEnabled = true;
            this.lbBestellingen.IntegralHeight = false;
            this.lbBestellingen.ItemHeight = 16;
            this.lbBestellingen.Location = new System.Drawing.Point(313, 24);
            this.lbBestellingen.Name = "lbBestellingen";
            this.lbBestellingen.Size = new System.Drawing.Size(233, 260);
            this.lbBestellingen.TabIndex = 0;
            this.lbBestellingen.SelectedIndexChanged += new System.EventHandler(this.lbBestellingen_SelectedIndexChanged);
            // 
            // txtArtikelOverzicht
            // 
            this.txtArtikelOverzicht.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArtikelOverzicht.Location = new System.Drawing.Point(12, 306);
            this.txtArtikelOverzicht.Multiline = true;
            this.txtArtikelOverzicht.Name = "txtArtikelOverzicht";
            this.txtArtikelOverzicht.ReadOnly = true;
            this.txtArtikelOverzicht.Size = new System.Drawing.Size(233, 102);
            this.txtArtikelOverzicht.TabIndex = 1;
            // 
            // lbArtikelen
            // 
            this.lbArtikelen.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArtikelen.FormattingEnabled = true;
            this.lbArtikelen.ItemHeight = 16;
            this.lbArtikelen.Location = new System.Drawing.Point(12, 151);
            this.lbArtikelen.Name = "lbArtikelen";
            this.lbArtikelen.Size = new System.Drawing.Size(295, 132);
            this.lbArtikelen.TabIndex = 0;
            this.lbArtikelen.SelectedIndexChanged += new System.EventHandler(this.lbArtikelen_SelectedIndexChanged);
            // 
            // txtOpmerking
            // 
            this.txtOpmerking.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpmerking.Location = new System.Drawing.Point(251, 306);
            this.txtOpmerking.Multiline = true;
            this.txtOpmerking.Name = "txtOpmerking";
            this.txtOpmerking.ReadOnly = true;
            this.txtOpmerking.Size = new System.Drawing.Size(295, 102);
            this.txtOpmerking.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Artikel gegevens";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bestelling gegevens";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Leveranciers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bestellingen gemaakt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Omschrijving";
            // 
            // FrmOverzichtBestellingen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(558, 419);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbArtikelen);
            this.Controls.Add(this.lbLeveranciers);
            this.Controls.Add(this.txtOpmerking);
            this.Controls.Add(this.txtArtikelOverzicht);
            this.Controls.Add(this.lbBestellingen);
            this.Name = "FrmOverzichtBestellingen";
            this.Text = "Overzicht Bestellingen";
            this.Load += new System.EventHandler(this.FrmOverzichtBestellingen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbLeveranciers;
        private System.Windows.Forms.ListBox lbBestellingen;
        private System.Windows.Forms.TextBox txtArtikelOverzicht;
        private System.Windows.Forms.ListBox lbArtikelen;
        private System.Windows.Forms.TextBox txtOpmerking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}