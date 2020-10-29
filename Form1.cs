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

//Kalla på metoder i logiklagret från denna klass. 

namespace Grupp_17 
{
    public partial class Form1 : Form
    {
        //Avsnitt avsnitt = new Avsnitt();
        public BLL1 bll1Objekt { get; set; } //Döp om BLL1 klassen till något beskrivande istället
        public Podcast podcastObj { get; set; }
        public Avsnitt avsnittObj { get; set; }

        public Form1()
        {
            bll1Objekt = new BLL1();
            podcastObj = new Podcast();
            avsnittObj = new Avsnitt();
            InitializeComponent();
            VisaPodcastsIListView();
           
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
                string podcastOmEmpty = avsnittObj.hamtaPodcastNamn(inputURL);
                podcastNamn = podcastOmEmpty;
            }
            else{  //Döper om podcastens namn om "namnTxtBox" innehåller en sträng
                podcastNamn = txtBoxPodcastNamn.Text;
            }

            bll1Objekt.BLL1TestaRSS(inputURL, podcastNamn);

            int antalAvsnitt = bll1Objekt.BLL1RaknaAvsnitt(podcastNamn);
            string intervall = "40";
            string kategori = "humor";

            ListViewItem item1 = new ListViewItem(podcastNamn, antalAvsnitt);
            item1.SubItems.Add(antalAvsnitt.ToString());
            item1.SubItems.Add(intervall);
            item1.SubItems.Add(kategori);
            
            PodcastListView.Items.AddRange(new ListViewItem[] { item1});
            //podcastObj.SkapaListForEnskildPodcast(podcastNamn, inputURL, "Seriös podcast", antalAvsnitt);
            bll1Objekt.SkickaPodInfoTillPodInfoSkapandet(podcastNamn, inputURL, "Seriös podcast", antalAvsnitt);
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
                    lblAvsnittPresentation.Text = bll1Objekt.BLL1RaknaAvsnitt(text).ToString(); //Skickar iväg vald podcast till metod som räknar antal avsnitt
                    Console.WriteLine(text);
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
                List<Podcast> podcastsSomLaddas = bll1Objekt.LaddaInPodcasts();

                foreach (var pod in podcastsSomLaddas)
                {
                    ListViewItem podcastItem = new ListViewItem(new[] { pod.PodcastsNamn, pod.AntalAvsnitt.ToString(), pod.PodcastsUrl, pod.PodcastsKategori });
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
    }
}
