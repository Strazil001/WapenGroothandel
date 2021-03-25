
namespace WapenGroothandel
{
	partial class FrmStock
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStock));
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtSerialnumber = new System.Windows.Forms.TextBox();
			this.btnDeleteArticle = new System.Windows.Forms.Button();
			this.txtWeight = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtType = new System.Windows.Forms.TextBox();
			this.txtID = new System.Windows.Forms.TextBox();
			this.txtArticlenumber = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBTW = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnAddData = new System.Windows.Forms.Button();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtModelnumber = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bestellingenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.verzendingenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.personeelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.financieleInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.overToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lstData = new System.Windows.Forms.ListBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.DimGray;
			this.btnCancel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.ForeColor = System.Drawing.SystemColors.Control;
			this.btnCancel.Location = new System.Drawing.Point(1047, 599);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(131, 43);
			this.btnCancel.TabIndex = 20;
			this.btnCancel.Text = "Annuleer";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtSerialnumber);
			this.groupBox1.Controls.Add(this.btnDeleteArticle);
			this.groupBox1.Controls.Add(this.txtWeight);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtType);
			this.groupBox1.Controls.Add(this.txtID);
			this.groupBox1.Controls.Add(this.txtArticlenumber);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtBTW);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.btnAddData);
			this.groupBox1.Controls.Add(this.txtDescription);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.txtPrice);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtModelnumber);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(769, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(409, 554);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Nieuw Artikel";
			// 
			// txtSerialnumber
			// 
			this.txtSerialnumber.BackColor = System.Drawing.SystemColors.Control;
			this.txtSerialnumber.Location = new System.Drawing.Point(125, 178);
			this.txtSerialnumber.Name = "txtSerialnumber";
			this.txtSerialnumber.Size = new System.Drawing.Size(195, 22);
			this.txtSerialnumber.TabIndex = 37;
			// 
			// btnDeleteArticle
			// 
			this.btnDeleteArticle.BackColor = System.Drawing.Color.DimGray;
			this.btnDeleteArticle.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeleteArticle.ForeColor = System.Drawing.SystemColors.Control;
			this.btnDeleteArticle.Location = new System.Drawing.Point(272, 505);
			this.btnDeleteArticle.Name = "btnDeleteArticle";
			this.btnDeleteArticle.Size = new System.Drawing.Size(131, 43);
			this.btnDeleteArticle.TabIndex = 22;
			this.btnDeleteArticle.Text = "Artikel Verwijderen";
			this.btnDeleteArticle.UseVisualStyleBackColor = false;
			this.btnDeleteArticle.Click += new System.EventHandler(this.btnDeleteArticle_Click);
			// 
			// txtWeight
			// 
			this.txtWeight.BackColor = System.Drawing.SystemColors.Control;
			this.txtWeight.Location = new System.Drawing.Point(125, 368);
			this.txtWeight.Name = "txtWeight";
			this.txtWeight.Size = new System.Drawing.Size(195, 22);
			this.txtWeight.TabIndex = 31;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(13, 181);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(73, 13);
			this.label11.TabIndex = 36;
			this.label11.Text = "Serienummer";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(13, 371);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(49, 13);
			this.label6.TabIndex = 30;
			this.label6.Text = "Gewicht";
			// 
			// txtType
			// 
			this.txtType.BackColor = System.Drawing.SystemColors.Control;
			this.txtType.Location = new System.Drawing.Point(125, 89);
			this.txtType.Name = "txtType";
			this.txtType.Size = new System.Drawing.Size(195, 22);
			this.txtType.TabIndex = 29;
			// 
			// txtID
			// 
			this.txtID.BackColor = System.Drawing.SystemColors.Control;
			this.txtID.Location = new System.Drawing.Point(131, 466);
			this.txtID.Name = "txtID";
			this.txtID.ReadOnly = true;
			this.txtID.Size = new System.Drawing.Size(195, 22);
			this.txtID.TabIndex = 28;
			// 
			// txtArticlenumber
			// 
			this.txtArticlenumber.BackColor = System.Drawing.SystemColors.Control;
			this.txtArticlenumber.Location = new System.Drawing.Point(125, 150);
			this.txtArticlenumber.Name = "txtArticlenumber";
			this.txtArticlenumber.Size = new System.Drawing.Size(195, 22);
			this.txtArticlenumber.TabIndex = 33;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(13, 153);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(85, 13);
			this.label7.TabIndex = 32;
			this.label7.Text = "Artikelnummer";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(19, 469);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 13);
			this.label1.TabIndex = 27;
			this.label1.Text = "ID";
			// 
			// txtBTW
			// 
			this.txtBTW.BackColor = System.Drawing.SystemColors.Control;
			this.txtBTW.Location = new System.Drawing.Point(125, 235);
			this.txtBTW.Name = "txtBTW";
			this.txtBTW.Size = new System.Drawing.Size(195, 22);
			this.txtBTW.TabIndex = 26;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(13, 238);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(25, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "BTW";
			// 
			// btnAddData
			// 
			this.btnAddData.BackColor = System.Drawing.Color.DimGray;
			this.btnAddData.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddData.ForeColor = System.Drawing.SystemColors.Control;
			this.btnAddData.Location = new System.Drawing.Point(139, 505);
			this.btnAddData.Name = "btnAddData";
			this.btnAddData.Size = new System.Drawing.Size(131, 43);
			this.btnAddData.TabIndex = 22;
			this.btnAddData.Text = "Artikel toevoegen";
			this.btnAddData.UseVisualStyleBackColor = false;
			this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
			// 
			// txtDescription
			// 
			this.txtDescription.BackColor = System.Drawing.SystemColors.Control;
			this.txtDescription.Location = new System.Drawing.Point(125, 266);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(195, 96);
			this.txtDescription.TabIndex = 23;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(13, 269);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(79, 13);
			this.label9.TabIndex = 22;
			this.label9.Text = "Omschrijving";
			// 
			// txtPrice
			// 
			this.txtPrice.BackColor = System.Drawing.SystemColors.Control;
			this.txtPrice.Location = new System.Drawing.Point(125, 206);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(195, 22);
			this.txtPrice.TabIndex = 21;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(13, 209);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "Prijs";
			// 
			// txtModelnumber
			// 
			this.txtModelnumber.BackColor = System.Drawing.SystemColors.Control;
			this.txtModelnumber.Location = new System.Drawing.Point(125, 122);
			this.txtModelnumber.Name = "txtModelnumber";
			this.txtModelnumber.Size = new System.Drawing.Size(195, 22);
			this.txtModelnumber.TabIndex = 17;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(13, 125);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Modelnummer";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(13, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Type";
			// 
			// txtName
			// 
			this.txtName.BackColor = System.Drawing.SystemColors.Control;
			this.txtName.Location = new System.Drawing.Point(125, 56);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(195, 22);
			this.txtName.TabIndex = 13;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(13, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Naam";
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.Tan;
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.infoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1190, 24);
			this.menuStrip1.TabIndex = 24;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestellingenToolStripMenuItem,
            this.verzendingenToolStripMenuItem,
            this.personeelToolStripMenuItem,
            this.financieleInfoToolStripMenuItem});
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.menuToolStripMenuItem.Text = "Menu";
			// 
			// bestellingenToolStripMenuItem
			// 
			this.bestellingenToolStripMenuItem.Name = "bestellingenToolStripMenuItem";
			this.bestellingenToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.bestellingenToolStripMenuItem.Text = "Bestellingen";
			this.bestellingenToolStripMenuItem.Click += new System.EventHandler(this.bestellingenToolStripMenuItem_Click);
			// 
			// verzendingenToolStripMenuItem
			// 
			this.verzendingenToolStripMenuItem.Name = "verzendingenToolStripMenuItem";
			this.verzendingenToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.verzendingenToolStripMenuItem.Text = "Verzendingen";
			this.verzendingenToolStripMenuItem.Click += new System.EventHandler(this.verzendingenToolStripMenuItem_Click);
			// 
			// personeelToolStripMenuItem
			// 
			this.personeelToolStripMenuItem.Name = "personeelToolStripMenuItem";
			this.personeelToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.personeelToolStripMenuItem.Text = "Personeel";
			this.personeelToolStripMenuItem.Click += new System.EventHandler(this.personeelToolStripMenuItem_Click);
			// 
			// financieleInfoToolStripMenuItem
			// 
			this.financieleInfoToolStripMenuItem.Name = "financieleInfoToolStripMenuItem";
			this.financieleInfoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.financieleInfoToolStripMenuItem.Text = "Financiele info";
			// 
			// infoToolStripMenuItem
			// 
			this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overToolStripMenuItem});
			this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.infoToolStripMenuItem.Text = "Info";
			// 
			// overToolStripMenuItem
			// 
			this.overToolStripMenuItem.Name = "overToolStripMenuItem";
			this.overToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.overToolStripMenuItem.Text = "Over";
			// 
			// lstData
			// 
			this.lstData.FormattingEnabled = true;
			this.lstData.Location = new System.Drawing.Point(12, 28);
			this.lstData.Name = "lstData";
			this.lstData.Size = new System.Drawing.Size(751, 550);
			this.lstData.TabIndex = 25;
			this.lstData.SelectedIndexChanged += new System.EventHandler(this.lstData_SelectedIndexChanged);
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.Color.DimGray;
			this.btnSave.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.ForeColor = System.Drawing.SystemColors.Control;
			this.btnSave.Location = new System.Drawing.Point(908, 599);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(131, 43);
			this.btnSave.TabIndex = 26;
			this.btnSave.Text = "Opslaan";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// FrmStock
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Tan;
			this.ClientSize = new System.Drawing.Size(1190, 654);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.lstData);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FrmStock";
			this.Text = "Stock";
			this.Load += new System.EventHandler(this.FrmStock_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnAddData;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtModelnumber;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnDeleteArticle;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bestellingenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem verzendingenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem personeelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem financieleInfoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem overToolStripMenuItem;
		private System.Windows.Forms.ListBox lstData;
		private System.Windows.Forms.TextBox txtBTW;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtType;
		private System.Windows.Forms.TextBox txtWeight;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtSerialnumber;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtArticlenumber;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnSave;
	}
}