﻿namespace Grupp_17
{
    partial class Form1
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
            this.CmbUpdateFrekvens = new System.Windows.Forms.ComboBox();
            this.cmbKategori = new System.Windows.Forms.ComboBox();
            this.btnSpara = new System.Windows.Forms.Button();
            this.btnTaBort = new System.Windows.Forms.Button();
            this.txtBoxURL = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listboxPodcasts = new System.Windows.Forms.ListBox();
            this.listBoxKategorier = new System.Windows.Forms.ListBox();
            this.btnNyKategori = new System.Windows.Forms.Button();
            this.btnSparaKategori = new System.Windows.Forms.Button();
            this.btnTaBortKategori = new System.Windows.Forms.Button();
            this.lblPodcastAvsnitt = new System.Windows.Forms.Label();
            this.lblKategorier = new System.Windows.Forms.Label();
            this.lblAvsnittPresentation = new System.Windows.Forms.Label();
            this.lblURL = new System.Windows.Forms.Label();
            this.lblUpdtFrekvens = new System.Windows.Forms.Label();
            this.lblKategoriCmb = new System.Windows.Forms.Label();
            this.txtBoxPodcastNamn = new System.Windows.Forms.TextBox();
            this.lblPodcastNamn = new System.Windows.Forms.Label();
            this.btnAndra = new System.Windows.Forms.Button();
            this.PodcastListView = new System.Windows.Forms.ListView();
            this.PodcastHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AntalAvsnittHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IntervallHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KategoriHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewAvsnitt = new System.Windows.Forms.ListView();
            this.AvsnittsNummer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AvsnittsNamn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVisaAllaPods = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lvBeskrivning = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // CmbUpdateFrekvens
            // 
            this.CmbUpdateFrekvens.FormattingEnabled = true;
            this.CmbUpdateFrekvens.Location = new System.Drawing.Point(245, 275);
            this.CmbUpdateFrekvens.Name = "CmbUpdateFrekvens";
            this.CmbUpdateFrekvens.Size = new System.Drawing.Size(133, 21);
            this.CmbUpdateFrekvens.TabIndex = 0;
            this.CmbUpdateFrekvens.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cmbKategori
            // 
            this.cmbKategori.FormattingEnabled = true;
            this.cmbKategori.Location = new System.Drawing.Point(384, 275);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(134, 21);
            this.cmbKategori.TabIndex = 1;
            this.cmbKategori.SelectedIndexChanged += new System.EventHandler(this.cmbKategori_SelectedIndexChanged);
            // 
            // btnSpara
            // 
            this.btnSpara.Location = new System.Drawing.Point(245, 318);
            this.btnSpara.Name = "btnSpara";
            this.btnSpara.Size = new System.Drawing.Size(87, 23);
            this.btnSpara.TabIndex = 3;
            this.btnSpara.Text = "Spara";
            this.btnSpara.UseVisualStyleBackColor = true;
            this.btnSpara.Click += new System.EventHandler(this.btnSpara_Click);
            // 
            // btnTaBort
            // 
            this.btnTaBort.Location = new System.Drawing.Point(435, 320);
            this.btnTaBort.Name = "btnTaBort";
            this.btnTaBort.Size = new System.Drawing.Size(87, 23);
            this.btnTaBort.TabIndex = 4;
            this.btnTaBort.Text = "Ta bort";
            this.btnTaBort.UseVisualStyleBackColor = true;
            this.btnTaBort.Click += new System.EventHandler(this.btnTaBort_Click);
            // 
            // txtBoxURL
            // 
            this.txtBoxURL.Location = new System.Drawing.Point(12, 275);
            this.txtBoxURL.Name = "txtBoxURL";
            this.txtBoxURL.Size = new System.Drawing.Size(227, 20);
            this.txtBoxURL.TabIndex = 5;
            this.txtBoxURL.TextChanged += new System.EventHandler(this.txtBoxURL_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(589, 275);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(328, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // listboxPodcasts
            // 
            this.listboxPodcasts.FormattingEnabled = true;
            this.listboxPodcasts.Location = new System.Drawing.Point(828, 12);
            this.listboxPodcasts.Name = "listboxPodcasts";
            this.listboxPodcasts.Size = new System.Drawing.Size(89, 30);
            this.listboxPodcasts.TabIndex = 7;
            // 
            // listBoxKategorier
            // 
            this.listBoxKategorier.FormattingEnabled = true;
            this.listBoxKategorier.Location = new System.Drawing.Point(589, 54);
            this.listBoxKategorier.Name = "listBoxKategorier";
            this.listBoxKategorier.Size = new System.Drawing.Size(328, 199);
            this.listBoxKategorier.TabIndex = 8;
            this.listBoxKategorier.SelectedIndexChanged += new System.EventHandler(this.listBoxKategorier_SelectedIndexChanged);
            // 
            // btnNyKategori
            // 
            this.btnNyKategori.Location = new System.Drawing.Point(589, 302);
            this.btnNyKategori.Name = "btnNyKategori";
            this.btnNyKategori.Size = new System.Drawing.Size(102, 23);
            this.btnNyKategori.TabIndex = 9;
            this.btnNyKategori.Text = "Ny";
            this.btnNyKategori.UseVisualStyleBackColor = true;
            this.btnNyKategori.Click += new System.EventHandler(this.btnNyKategori_Click);
            // 
            // btnSparaKategori
            // 
            this.btnSparaKategori.Location = new System.Drawing.Point(701, 301);
            this.btnSparaKategori.Name = "btnSparaKategori";
            this.btnSparaKategori.Size = new System.Drawing.Size(102, 24);
            this.btnSparaKategori.TabIndex = 10;
            this.btnSparaKategori.Text = "Spara";
            this.btnSparaKategori.UseVisualStyleBackColor = true;
            this.btnSparaKategori.Click += new System.EventHandler(this.btnSparaKategori_Click);
            // 
            // btnTaBortKategori
            // 
            this.btnTaBortKategori.Location = new System.Drawing.Point(815, 301);
            this.btnTaBortKategori.Name = "btnTaBortKategori";
            this.btnTaBortKategori.Size = new System.Drawing.Size(102, 24);
            this.btnTaBortKategori.TabIndex = 11;
            this.btnTaBortKategori.Text = "Ta bort";
            this.btnTaBortKategori.UseVisualStyleBackColor = true;
            this.btnTaBortKategori.Click += new System.EventHandler(this.btnTaBortKategori_Click);
            // 
            // lblPodcastAvsnitt
            // 
            this.lblPodcastAvsnitt.AutoSize = true;
            this.lblPodcastAvsnitt.Location = new System.Drawing.Point(13, 379);
            this.lblPodcastAvsnitt.Name = "lblPodcastAvsnitt";
            this.lblPodcastAvsnitt.Size = new System.Drawing.Size(77, 13);
            this.lblPodcastAvsnitt.TabIndex = 13;
            this.lblPodcastAvsnitt.Text = "Podcastavsnitt";
            this.lblPodcastAvsnitt.Click += new System.EventHandler(this.lblPodcastAvsnitt_Click);
            // 
            // lblKategorier
            // 
            this.lblKategorier.AutoSize = true;
            this.lblKategorier.Location = new System.Drawing.Point(589, 35);
            this.lblKategorier.Name = "lblKategorier";
            this.lblKategorier.Size = new System.Drawing.Size(58, 13);
            this.lblKategorier.TabIndex = 14;
            this.lblKategorier.Text = "Kategorier:";
            // 
            // lblAvsnittPresentation
            // 
            this.lblAvsnittPresentation.AutoSize = true;
            this.lblAvsnittPresentation.Location = new System.Drawing.Point(587, 372);
            this.lblAvsnittPresentation.Name = "lblAvsnittPresentation";
            this.lblAvsnittPresentation.Size = new System.Drawing.Size(98, 13);
            this.lblAvsnittPresentation.TabIndex = 15;
            this.lblAvsnittPresentation.Text = "Avsnittsbeskrivning";
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(13, 259);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(32, 13);
            this.lblURL.TabIndex = 17;
            this.lblURL.Text = "URL:";
            // 
            // lblUpdtFrekvens
            // 
            this.lblUpdtFrekvens.AutoSize = true;
            this.lblUpdtFrekvens.Location = new System.Drawing.Point(242, 259);
            this.lblUpdtFrekvens.Name = "lblUpdtFrekvens";
            this.lblUpdtFrekvens.Size = new System.Drawing.Size(114, 13);
            this.lblUpdtFrekvens.TabIndex = 18;
            this.lblUpdtFrekvens.Text = "Uppdateringsfrekvens:";
            // 
            // lblKategoriCmb
            // 
            this.lblKategoriCmb.AutoSize = true;
            this.lblKategoriCmb.Location = new System.Drawing.Point(384, 259);
            this.lblKategoriCmb.Name = "lblKategoriCmb";
            this.lblKategoriCmb.Size = new System.Drawing.Size(49, 13);
            this.lblKategoriCmb.TabIndex = 19;
            this.lblKategoriCmb.Text = "Kategori:";
            this.lblKategoriCmb.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtBoxPodcastNamn
            // 
            this.txtBoxPodcastNamn.Location = new System.Drawing.Point(12, 320);
            this.txtBoxPodcastNamn.Name = "txtBoxPodcastNamn";
            this.txtBoxPodcastNamn.Size = new System.Drawing.Size(227, 20);
            this.txtBoxPodcastNamn.TabIndex = 20;
            // 
            // lblPodcastNamn
            // 
            this.lblPodcastNamn.AutoSize = true;
            this.lblPodcastNamn.Location = new System.Drawing.Point(13, 304);
            this.lblPodcastNamn.Name = "lblPodcastNamn";
            this.lblPodcastNamn.Size = new System.Drawing.Size(38, 13);
            this.lblPodcastNamn.TabIndex = 21;
            this.lblPodcastNamn.Text = "Namn:";
            // 
            // btnAndra
            // 
            this.btnAndra.Location = new System.Drawing.Point(338, 318);
            this.btnAndra.Name = "btnAndra";
            this.btnAndra.Size = new System.Drawing.Size(87, 24);
            this.btnAndra.TabIndex = 22;
            this.btnAndra.Text = "Ändra";
            this.btnAndra.UseVisualStyleBackColor = true;
            this.btnAndra.Click += new System.EventHandler(this.btnAndra_Click);
            // 
            // PodcastListView
            // 
            this.PodcastListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PodcastHeader,
            this.AntalAvsnittHeader,
            this.IntervallHeader,
            this.KategoriHeader});
            this.PodcastListView.HideSelection = false;
            this.PodcastListView.Location = new System.Drawing.Point(16, 12);
            this.PodcastListView.MultiSelect = false;
            this.PodcastListView.Name = "PodcastListView";
            this.PodcastListView.Size = new System.Drawing.Size(506, 241);
            this.PodcastListView.TabIndex = 0;
            this.PodcastListView.UseCompatibleStateImageBehavior = false;
            this.PodcastListView.View = System.Windows.Forms.View.Details;
            this.PodcastListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // PodcastHeader
            // 
            this.PodcastHeader.Text = "Podcast";
            this.PodcastHeader.Width = 227;
            // 
            // AntalAvsnittHeader
            // 
            this.AntalAvsnittHeader.Text = "Antal Avsnitt";
            this.AntalAvsnittHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AntalAvsnittHeader.Width = 86;
            // 
            // IntervallHeader
            // 
            this.IntervallHeader.Text = "Intervall";
            this.IntervallHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IntervallHeader.Width = 56;
            // 
            // KategoriHeader
            // 
            this.KategoriHeader.Text = "Kategori";
            this.KategoriHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.KategoriHeader.Width = 132;
            // 
            // listViewAvsnitt
            // 
            this.listViewAvsnitt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AvsnittsNamn,
            this.AvsnittsNummer});
            this.listViewAvsnitt.HideSelection = false;
            this.listViewAvsnitt.Location = new System.Drawing.Point(16, 398);
            this.listViewAvsnitt.Name = "listViewAvsnitt";
            this.listViewAvsnitt.Size = new System.Drawing.Size(506, 173);
            this.listViewAvsnitt.TabIndex = 24;
            this.listViewAvsnitt.UseCompatibleStateImageBehavior = false;
            this.listViewAvsnitt.View = System.Windows.Forms.View.Details;
            this.listViewAvsnitt.SelectedIndexChanged += new System.EventHandler(this.listViewAvsnitt_SelectedIndexChanged);
            // 
            // AvsnittsNummer
            // 
            this.AvsnittsNummer.DisplayIndex = 0;
            this.AvsnittsNummer.Text = "Avsnittsnummer";
            this.AvsnittsNummer.Width = 90;
            // 
            // AvsnittsNamn
            // 
            this.AvsnittsNamn.DisplayIndex = 1;
            this.AvsnittsNamn.Text = "Avsnitssnamn";
            this.AvsnittsNamn.Width = 385;
            // 
            // btnVisaAllaPods
            // 
            this.btnVisaAllaPods.Location = new System.Drawing.Point(589, 331);
            this.btnVisaAllaPods.Name = "btnVisaAllaPods";
            this.btnVisaAllaPods.Size = new System.Drawing.Size(101, 21);
            this.btnVisaAllaPods.TabIndex = 25;
            this.btnVisaAllaPods.Text = "Visa alla";
            this.btnVisaAllaPods.UseVisualStyleBackColor = true;
            this.btnVisaAllaPods.Click += new System.EventHandler(this.btnVisaAllaPods_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvBeskrivning});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(589, 398);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(328, 173);
            this.listView1.TabIndex = 26;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // lvBeskrivning
            // 
            this.lvBeskrivning.Text = "Avsnittsbeskrivning";
            this.lvBeskrivning.Width = 300;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 583);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnVisaAllaPods);
            this.Controls.Add(this.listViewAvsnitt);
            this.Controls.Add(this.PodcastListView);
            this.Controls.Add(this.btnAndra);
            this.Controls.Add(this.lblPodcastNamn);
            this.Controls.Add(this.txtBoxPodcastNamn);
            this.Controls.Add(this.lblKategoriCmb);
            this.Controls.Add(this.lblUpdtFrekvens);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.lblAvsnittPresentation);
            this.Controls.Add(this.lblKategorier);
            this.Controls.Add(this.lblPodcastAvsnitt);
            this.Controls.Add(this.btnTaBortKategori);
            this.Controls.Add(this.btnSparaKategori);
            this.Controls.Add(this.btnNyKategori);
            this.Controls.Add(this.listBoxKategorier);
            this.Controls.Add(this.listboxPodcasts);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtBoxURL);
            this.Controls.Add(this.btnTaBort);
            this.Controls.Add(this.btnSpara);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.CmbUpdateFrekvens);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbUpdateFrekvens;
        private System.Windows.Forms.ComboBox cmbKategori;
        private System.Windows.Forms.Button btnSpara;
        private System.Windows.Forms.Button btnTaBort;
        private System.Windows.Forms.TextBox txtBoxURL;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listboxPodcasts;
        private System.Windows.Forms.Button btnNyKategori;
        private System.Windows.Forms.Button btnSparaKategori;
        private System.Windows.Forms.Button btnTaBortKategori;
        private System.Windows.Forms.Label lblPodcastAvsnitt;
        private System.Windows.Forms.Label lblKategorier;
        private System.Windows.Forms.Label lblAvsnittPresentation;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Label lblUpdtFrekvens;
        private System.Windows.Forms.Label lblKategoriCmb;
        private System.Windows.Forms.ListBox listBoxKategorier;
        private System.Windows.Forms.TextBox txtBoxPodcastNamn;
        private System.Windows.Forms.Label lblPodcastNamn;
        private System.Windows.Forms.Button btnAndra;
        private System.Windows.Forms.ListView PodcastListView;
        private System.Windows.Forms.ColumnHeader PodcastHeader;
        private System.Windows.Forms.ColumnHeader AntalAvsnittHeader;
        private System.Windows.Forms.ColumnHeader IntervallHeader;
        private System.Windows.Forms.ColumnHeader KategoriHeader;
        private System.Windows.Forms.ListView listViewAvsnitt;
        private System.Windows.Forms.ColumnHeader AvsnittsNummer;
        private System.Windows.Forms.ColumnHeader AvsnittsNamn;
        private System.Windows.Forms.Button btnVisaAllaPods;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader lvBeskrivning;
    }
}

