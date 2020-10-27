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

        public Form1()
        {
            InitializeComponent();
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
                string podcastOmEmpty = Avsnitt.hamtaPodcastNamn(inputURL);
                podcastNamn = podcastOmEmpty;
            }
            else{  //Döper om podcastens namn om "namnTxtBox" innehåller en sträng
                podcastNamn = txtBoxPodcastNamn.Text;
            }

            BLL1.BLL1TestaRSS(inputURL, podcastNamn);

            int antalAvsnitt = 0;
            string intervall = "40";
            string kategori = "humor";

            ListViewItem item1 = new ListViewItem(podcastNamn, 0);
            item1.SubItems.Add(antalAvsnitt.ToString());
            item1.SubItems.Add(intervall);
            item1.SubItems.Add(kategori);
            
            PodcastListView.Items.AddRange(new ListViewItem[] { item1});
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var podcastNamnObj = PodcastListView.SelectedItems[Name];
                

            string podcastNamn = podcastNamnObj.ToString();
            Console.WriteLine(podcastNamn);
            //lblAvsnittPresentation.Text = BLL1.BLL1RaknaAvsnitt(podcastNamn).ToString();
            



            //string returneradPodNamn = Avsnitt.hamtaPodcastNamn(podcastNamn);


            //int antalAvsnitt = Avsnitt.RaknaAvsnitt(returneradPodNamn);

            //lblAvsnittPresentation.Text = antalAvsnitt.ToString(); //Ändra denna rad, använder lbl endast för att se resultat för test!!!
        }
    }
}
