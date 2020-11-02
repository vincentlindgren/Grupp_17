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
using System.Linq.Expressions;
using System.Diagnostics;
using System.Timers;


//Kalla på metoder i logiklagret från denna klass. 

namespace Grupp_17
{
    public partial class Form1 : Form
    {

        //Avsnitt avsnitt = new Avsnitt();
        public BLL1 bll1Objekt { get; set; } //ANVÄNDS EJ
        public Podcast podcastObj { get; set; }

        AvsnittKontroller avsnittKontroller = new AvsnittKontroller();


        PodcastKontroller podcastKontroller = new PodcastKontroller();
        PodcastRep podcastRep = new PodcastRep();

        KategoriKontroller kategoriKontroller = new KategoriKontroller();
        PodKategori podKategori = new PodKategori();

        Validering validation = new Validering();

        private static System.Timers.Timer timer;

        public Form1()
        {

            InitializeComponent();
            VisaPodcastsIListView();
            fyllFrekvens();
            fyllKategorier();
            hamtaAllaMinIntervall();


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

        private async void btnSpara_Click(object sender, EventArgs e)
        {
            try
            {
                string inputURL = txtBoxURL.Text;
                string podcastNamn;

                if (validation.KorrektURLAdress(inputURL) && validation.ValdFrekvens(CmbUpdateFrekvens.Text))
                {
                    if (cmbKategori.SelectedItem != null)
                    {
                        if (string.IsNullOrEmpty(txtBoxPodcastNamn.Text))
                        {
                            string podcastOmEmpty = podcastKontroller.HamtaPodcastNamn(inputURL);
                            podcastNamn = podcastOmEmpty;
                        }
                        else
                        {
                            podcastNamn = txtBoxPodcastNamn.Text;
                        }

                        string frekvens = CmbUpdateFrekvens.SelectedItem.ToString();
                        string kategori = cmbKategori.Text;
                        int antalAvsnitt = avsnittKontroller.RaknaAntalAvsnitt(inputURL);

                        await podcastKontroller.SkapaListForEnskildPodcastAsync(podcastNamn, inputURL, kategori, frekvens);

                        ListViewItem item1 = new ListViewItem(podcastNamn); 
                        item1.SubItems.Add(antalAvsnitt.ToString());
                        item1.SubItems.Add(frekvens);
                        item1.SubItems.Add(kategori);

                        PodcastListView.Items.AddRange(new ListViewItem[] { item1 });
                    }
                    else {
                        MessageBox.Show("Vänligen välj en kategori!");
                    }
                }
            }
            catch (AnvandarException E) {
                MessageBox.Show(E.Message);
            }
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (PodcastListView.SelectedIndices.Count <= 0)
            {
                return;
            }
            int valdIndex = PodcastListView.SelectedIndices[0];

            if (valdIndex >= 0)
            {
                string text = PodcastListView.Items[valdIndex].Text;
                List<Avsnitt> avsnittLista = avsnittKontroller.HamtaAvsnittForPodcast(text); 
                try
                {
                    listViewAvsnitt.Items.Clear();
                    int avsnittsnummer = podcastKontroller.HamtaAntalAvsnitt(text) + 1; //Hämta antal avsnitt för podcastObjekt för att räkna och skriva avsnittsnummer i avsnittslistan.

                    foreach (var item in avsnittLista) {
                        avsnittsnummer = avsnittsnummer - 1;
                        ListViewItem avsnittItem = new ListViewItem(new[] { avsnittsnummer.ToString(), item.AvsnittsNummer }); ;
                        listViewAvsnitt.Items.Add(avsnittItem);
                    }
                }
                catch (ArgumentOutOfRangeException skrivException)
                {
                    Console.WriteLine(skrivException);
                }
            }
            
        }

        public void VisaPodcastsIListView()
        {
            try
            {
                List<Podcast> podcastsSomLaddas = podcastRep.GetAll(); //Fixa metod i PodcastKontroller som hämtar GetAll() från podcastRep DAL.

                foreach (var pod in podcastsSomLaddas)
                {
                    ListViewItem podcastItem = new ListViewItem(new[] { pod.PodcastsNamn, pod.AntalAvsnitt.ToString(), pod.Frekvens, pod.PodcastsKategori });
                    PodcastListView.Items.Add(podcastItem);
                }
            }
            catch (FileNotFoundException e)
            {

                Console.WriteLine(e);
            }
        }

        private void btnNyKategori_Click(object sender, EventArgs e)
        {
            {
                if (!String.IsNullOrEmpty(textBox2.Text))
                {
                    string kategoriNamn = textBox2.Text;
                    kategoriKontroller.SparaKategorier(kategoriNamn);
                    listBoxKategorier.Items.Add(kategoriNamn);
                    cmbKategori.Items.Add(kategoriNamn);
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Textfältet är tomt");
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

        public void fyllKategorier() { 
            try
            {
                List<PodKategori> listaSomReturneras = kategoriKontroller.GetAllKategorier();

                foreach (var pod in listaSomReturneras)
                {
                    listBoxKategorier.Items.Add(pod.KategoriNamn);
                    cmbKategori.Items.Add(pod.KategoriNamn);
                }
            }
            catch (FileNotFoundException exc) {
                Console.WriteLine(exc);
            }
        }

        public void fyllFrekvens()
        {
            CmbUpdateFrekvens.Items.Add("10");
            CmbUpdateFrekvens.Items.Add("30");
            CmbUpdateFrekvens.Items.Add("60");
        }

        private void listBoxAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void hamtaAllaMinIntervall()//Dessa används för att starta timers för respektive podcast
        {
            try
            {
                List<string> tioMinList = podcastKontroller.HamtaPodcastsForMinuter("10");
                List<string> trettioMinList = podcastKontroller.HamtaPodcastsForMinuter("30");
                List<string> sextioMinList = podcastKontroller.HamtaPodcastsForMinuter("60");

                foreach (var item in tioMinList)
                {
                    int intervall = 10;
                    StartaTimer(intervall);
                    Console.WriteLine(item);
                }

                foreach (var item in trettioMinList)
                {
                    int intervall = 30;
                    StartaTimer(intervall);
                    Console.WriteLine(item);
                }

                foreach (var item in sextioMinList)
                {
                    int intervall = 60;
                    StartaTimer(intervall);
                    Console.WriteLine(item);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }


        private void StartaTimer(int intervall)
        {
            
            if (intervall == 10) {
                timer = new System.Timers.Timer();
                timer.Interval = 6000; //00; 
                timer.Elapsed += OnTimedEvent10;
                timer.AutoReset = true;
                timer.Enabled = true;
                Console.WriteLine(intervall.ToString());
            }
             
            else if (intervall == 30)
                {
                    timer = new System.Timers.Timer();
                timer.Interval = 1800000; 
                    timer.Elapsed += OnTimedEvent30;
                    timer.AutoReset = true;
                    timer.Enabled = true;
                    Console.WriteLine(intervall.ToString());
                }
            else if (intervall == 60) {
                timer = new System.Timers.Timer();
                timer.Interval = 3600000;
                timer.Elapsed += OnTimedEvent60;
                timer.AutoReset = true;
                timer.Enabled = true;
                Console.WriteLine(intervall.ToString());
            }
        }

        private void OnTimedEvent10(Object source, System.Timers.ElapsedEventArgs e) {
            List<string> tioMinList = podcastKontroller.HamtaPodcastsForMinuter("10");
            podcastKontroller.UppdateraPodcastForMinIntervallPK(tioMinList);
            Console.WriteLine("5 sekunder har gått: tioMinList");
        }

        private void OnTimedEvent30(Object source, System.Timers.ElapsedEventArgs e)
        {
            List<string> trettioMinList = podcastKontroller.HamtaPodcastsForMinuter("30");
            podcastKontroller.UppdateraPodcastForMinIntervallPK(trettioMinList);
            Console.WriteLine("8 sekunder har gått: trettioMinList");
        }
        private void OnTimedEvent60(Object source, System.Timers.ElapsedEventArgs e)
        {
            List<string> sextioMinList = podcastKontroller.HamtaPodcastsForMinuter("60");
            podcastKontroller.UppdateraPodcastForMinIntervallPK(sextioMinList);
        }

        private void btnTaBort_Click(object sender, EventArgs e)
        {
            int valdIndex = PodcastListView.SelectedIndices[0];
            try
            {
                if (valdIndex >= 0)
                {
                    if (DialogResult.Yes == MessageBox.Show
                      ("Vill du ta bort podden?", "Confirmation",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {

                        string poddAttTaBort = PodcastListView.Items[valdIndex].Text;

                        string url = podcastKontroller.HamtaPodcastURL(poddAttTaBort);
                        podcastKontroller.DeletePoddcastAtUrlCompare(url);
                        PodcastListView.Items.RemoveAt(valdIndex);
                        Console.WriteLine(url);
                    }
                }
                else
                {
                    MessageBox.Show("Försök igen. Vänligen välj en podd att ta bort");
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show("Det gick inte att ta bort podden, försök igen!");
                Console.WriteLine(excep);
            }
        }

        private void listBoxKategorier_SelectedIndexChanged(object sender, EventArgs e) //Sortera podcasts efter kategori
        {
            if (listBoxKategorier.SelectedIndices.Count <= 0)
            {
                return;
            }
            int valdIndex = listBoxKategorier.SelectedIndices[0];

            if (valdIndex >= 0)
            {
                string text = listBoxKategorier.Items[valdIndex].ToString();
                List<Podcast> podListaForKategori = kategoriKontroller.SokPodcastEfterPodcastKategori(text);
                try
                {
                    PodcastListView.Items.Clear();

                    foreach (var item in podListaForKategori)
                    {
                        ListViewItem podcastItem = new ListViewItem(new[] { item.PodcastsNamn, item.AntalAvsnitt.ToString(), item.Frekvens, item.PodcastsKategori }); ;
                        PodcastListView.Items.Add(podcastItem);
                    }
                }
                catch (ArgumentOutOfRangeException skrivException)
                {
                    Console.WriteLine(skrivException);
                }
            }
        }

        private void btnVisaAllaPods_Click(object sender, EventArgs e) //Återställer och visar samtliga podcasts igen
        {
            if (listBoxKategorier.SelectedIndices.Count <= 0)
            {
                return;
            }
            ClearAndReload();



        }

        private void btnNy_Click(object sender, EventArgs e)
        {

        }

        private void btnTaBortKategori_Click(object sender, EventArgs e)
        {
            if (listBoxKategorier.SelectedIndices.Count <= 0)
            {
                return;
            }
            int valdIndex = listBoxKategorier.SelectedIndices[0];
            try
            {
                if (valdIndex >= 0)
                {
                    if (DialogResult.Yes == MessageBox.Show
                      ("Vill du ta bort kategorin och alla Podcasts i kategorin?", "Confirmation",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {

                        string kategoriAttTaBort = listBoxKategorier.Items[valdIndex].ToString();

                        string katNamn = kategoriKontroller.HamtaKategoriNamn(kategoriAttTaBort);
                        kategoriKontroller.DeletePoddcastAtKategoriCompare(katNamn);

                        List<Podcast> poddarSomSkaDeletas = kategoriKontroller.SokPodcastEfterPodcastKategori(kategoriAttTaBort);

                        int i = 0;
                        int i2 = 0;
                        foreach (var item in poddarSomSkaDeletas)
                            i2++;
                        Console.WriteLine(i2);
                        {

                        
                        while (i < i2) {
                                Console.WriteLine(i);
                                podcastKontroller.KallaPaDelete(i);
                            i++;
                            ClearAndReload();
                            
                            //listBoxKategorier.ClearSelected();
                            

                        }
                           
                            //for(int i = 0; i<poddarSomSkaDeletas.Count(); i++)
                            //{
                            //    podcastKontroller.KallaPaDelete(i);
                            //}

                        

                        //podcastKontroller.KallaPaDelete(valdIndex);
                        Console.WriteLine(katNamn);
                        ClearAndReload();
                    }
                }
                else
                {
                    MessageBox.Show("Försök igen. Vänligen välj en kategori att ta bort");
                }
            }
            catch (Exception excep)
            {
                MessageBox.Show("Det gick inte att ta bort kategorin, försök igen!");
                Console.WriteLine(excep);
            }


        }

        public void ClearAndReload() {
            listBoxKategorier.ClearSelected();
            listBoxKategorier.Items.Clear();
            PodcastListView.Items.Clear();
            cmbKategori.Items.Clear();
            cmbKategori.Text = "";
            VisaPodcastsIListView();
            fyllKategorier();
            
        }
    }
}


