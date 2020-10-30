using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using DAL;
using BLL;
using DAL.RepoMapp;


//Kalla på metoder i logiklagret från denna klass. 

namespace Grupp_17
{
    public partial class Form1 : Form
    {

        //Avsnitt avsnitt = new Avsnitt();
        public BLL1 bll1Objekt { get; set; } //Döp om BLL1 klassen till något beskrivande istället
        public Podcast podcastObj { get; set; }
        AvsnittKontroller avsnittKontroller = new AvsnittKontroller();

        PodcastKontroller podcastKontroller = new PodcastKontroller();
        PodcastRep podcastRep = new PodcastRep();

        KategoriKontroller kategoriKontroller = new KategoriKontroller();

        public Form1()
        {

            InitializeComponent();
            VisaPodcastsIListView();
            fyllFrekvens();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSpara_Click(object sender, EventArgs e)
        {
            string inputURL = txtBoxURL.Text;
            string podcastNamn;


            if (string.IsNullOrEmpty(txtBoxPodcastNamn.Text)) //Hämtar podcastens orginalnamn om "namnTxtBox" lämnas tom
            {
                string podcastOmEmpty = podcastKontroller.HamtaPodcastNamn(inputURL);
                podcastNamn = podcastOmEmpty;
            }
            else
            {  //Döper om podcastens namn om "namnTxtBox" innehåller en sträng
                podcastNamn = txtBoxPodcastNamn.Text;
            }

            string frekvens = CmbUpdateFrekvens.SelectedItem.ToString();
            string kategori = cmbKategori.SelectedItem.ToString();
            int antalAvsnitt = avsnittKontroller.RaknaAntalAvsnitt(inputURL);

            podcastKontroller.SkapaListForEnskildPodcast(podcastNamn, frekvens , kategori, inputURL);


            ListViewItem item1 = new ListViewItem(podcastNamn); //var tidigare (podcastNamn, antalAvsnitt)- återgå om ej funkar med endast podcastNamn
            item1.SubItems.Add(antalAvsnitt.ToString());
            item1.SubItems.Add(frekvens);
            item1.SubItems.Add(kategori);

            PodcastListView.Items.AddRange(new ListViewItem[] { item1 });
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) //Metoden funkar!! hämtar namn från vald podcast och konverterar till string
        {
            if (PodcastListView.SelectedIndices.Count <= 0)
            {
                return;
            }
            int valdIndex = PodcastListView.SelectedIndices[0];

            if (valdIndex >= 0)
            {
                string text = PodcastListView.Items[valdIndex].Text;
                try
                {
                    //lblAvsnittPresentation.Text = avsnittKontroller.RaknaAntalAvsnitt(text).ToString(); //Skickar iväg vald podcast till metod som räknar antal avsnitt
                    //Console.WriteLine(text);
                }
                catch (ArgumentOutOfRangeException skrivException)
                {
                    Console.WriteLine(skrivException);
                }
            }
            //lblAvsnittPresentation.Text = BLL1.BLL1RaknaAvsnitt(podcastNamn).ToString();
            //string returneradPodNamn = Avsnitt.hamtaPodcastNamn(podcastNamn);
            //int antalAvsnitt = Avsnitt.RaknaAvsnitt(returneradPodNamn);
            //lblAvsnittPresentation.Text = antalAvsnitt.ToString(); //Ändra denna rad, använder lbl endast för att se resultat för test!!!
        }

        public void VisaPodcastsIListView()
        {
            try
            {
                List<Podcast> podcastsSomLaddas = podcastRep.GetAll();

                foreach (var pod in podcastsSomLaddas)
                {
                    ListViewItem podcastItem = new ListViewItem(new[] { pod.PodcastsNamn, pod.AntalAvsnitt.ToString(), pod.Frekvens, pod.PodcastsKategori });
                    PodcastListView.Items.Add(podcastItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //catch (FileNotFoundException exFileNotFound)
            //{
            //    Console.WriteLine(exFileNotFound);
            //}
        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {
            {
                if (!String.IsNullOrEmpty(textBox2.Text))
                {
                    string kategoriNamn = textBox2.Text;

                    listBoxKategorier.Items.Add(kategoriNamn);
                    cmbKategori.Items.Add(kategoriNamn);
                    textBox2.Text = "";

                }
            }

        }

        private void btnSparaKategori_Click(object sender, EventArgs e)
        {
            {
                Boolean selected = true;
                var text = textBox2.Text;
                if (listBoxKategorier.SelectedItems.Count > 0)
                {
                    if (string.IsNullOrEmpty(text))
                    {
                        MessageBox.Show("Textfältet är tomt!");
                    }

                    if (selected)
                    {
                        int selectedIndex = listBoxKategorier.SelectedIndex;
                        listBoxKategorier.Items.RemoveAt(selectedIndex);
                        listBoxKategorier.Items.Insert(selectedIndex, textBox2.Text);
                        listBoxKategorier.ResetText();
                        cmbKategori.Items.RemoveAt(selectedIndex);
                        cmbKategori.Items.Insert(selectedIndex, textBox2.Text);
                        cmbKategori.ResetText();
                    }
                    textBox2.Clear();
                    MessageBox.Show("Du har nu ändrat kategorins namn!", "Kategorin", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("du måste välja en kategori");
                }

            }
        }
        public void fyllFrekvens()
        {
            CmbUpdateFrekvens.Items.Add("10");
            CmbUpdateFrekvens.Items.Add("30");
            CmbUpdateFrekvens.Items.Add("60");
        }
    }
}
