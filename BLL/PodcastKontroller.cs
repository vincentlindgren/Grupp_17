using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.RepoMapp;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BLL
{
    public class PodcastKontroller : KontrollerKlass
    {
        AvsnittKontroller avsnittKontroller = new AvsnittKontroller();
        private PodcastRep podcastRep;
        
        
        public PodcastKontroller()
        {
            podcastRep = new PodcastRep();
        }


        public string HamtaPodcastNamn(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            string podNamnAttReturnera = feed.Title.Text;

            return podNamnAttReturnera;
        }

        public string HamtaPodcastURL(string podcastNamn)
        {
            string podUrlAttReturnera = "";

            List<Podcast> podLista = podcastRep.GetAll();

            foreach (var item in podLista)
            {
                if (item.PodcastsNamn.Equals(podcastNamn))
                {
                    podUrlAttReturnera = item.PodcastsUrl;
                    break;
                }
            }

            return podUrlAttReturnera;
        }

        public async Task SkapaListForEnskildPodcastAsync(string podcastNamn, string podcastURL, string podcastKategori, string frekvens)
        {

            List<Avsnitt> avsnittsLista = await avsnittKontroller.HamtaAvsnittMedRssUrlAsync(podcastURL);

            int antalAvsnitt = avsnittKontroller.RaknaAntalAvsnitt(podcastURL);

            Podcast podcast = new Podcast(podcastNamn, podcastURL, podcastKategori, antalAvsnitt, frekvens, avsnittsLista);
            Console.WriteLine(antalAvsnitt);

            try
            {
                podcastRep.Skapa(podcast);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }


        public void SkapaListForEnskildPodcast(string podcastNamn, string podcastURL, string podcastKategori, string frekvens)
        {

            List<Avsnitt> avsnittsLista = avsnittKontroller.HamtaAvsnittMedRssUrl(podcastURL);

            int antalAvsnitt = avsnittKontroller.RaknaAntalAvsnitt(podcastURL);

            Podcast podcast = new Podcast(podcastNamn, podcastURL, podcastKategori, antalAvsnitt, frekvens, avsnittsLista);
            Console.WriteLine(antalAvsnitt);

            try
            {
                podcastRep.Skapa(podcast);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }


        public int HamtaAntalAvsnitt(string namn)
        {
            int antalAvsnittAttReturnera = podcastRep.ReturnAntalAvsnitt(namn);
            return antalAvsnittAttReturnera;
        }

        public List<String> HamtaPodcastsForMinuter(string intervall)
        {
            List<string> minuter = new List<string>();
            try
            {
                List<Podcast> podcasts = podcastRep.GetAll();
                foreach (var item in podcasts)
                {
                    if (item.Frekvens.Equals(intervall))
                    {
                        minuter.Add(item.PodcastsUrl);
                    }
                }

            }
            catch (Exception)
            {
            }
            return minuter;  //Kanske returna i Loopen och starta timer efter varje return? Borde funka, kanske....

        }

        //public List<String> HamtaPodcastsForTrettioMinuter(string trettio)
        //{
        //    List<Podcast> podcasts30 = podcastRep.GetAll();
        //    List<string> trettioMinuter = new List<string>();
        //    foreach (var item in podcasts30)
        //    {
        //        if (item.Frekvens.Equals(trettio))
        //        {
        //            trettioMinuter.Add(item.PodcastsUrl);
        //        }
        //    }
        //    return trettioMinuter;  //Kanske returna i Loopen och starta timer efter varje return? Borde funka, kanske....
        //}

        //public List<String> HamtaPodcastsForSextioMinuter(string sextio)
        //{
        //    List<Podcast> podcasts60= podcastRep.GetAll();
        //    List<string> sextioMinuter = new List<string>();
        //    foreach (var item in podcasts60)
        //    {
        //        if (item.Frekvens.Equals(sextio))
        //        {
        //            sextioMinuter.Add(item.PodcastsUrl);
        //        }
        //    }
        //    return sextioMinuter;  //Kanske returna i Loopen och starta timer efter varje return? Borde funka, kanske....
        //}

        public void UppdateraPodcastForMinIntervallPK(List<string> minutIntervall) //kan användas även för deletea avsnitt för en specifik kategori om man först hämtar ut kategori i annan metod o skickar hit en list av string "kategori""
        {                                                                           //kallar på GetAll för att kunna jämföra varje item i podLista med listan av URL's som vi redan vet är 10min-intervallsPods
            try
            {
                List<Podcast> podLista = podcastRep.GetAll();
                int i = 0;                                                              //Sätter int i=0 så att vi kan kalla på podRep.Delete() och kan skicka med current int Index och deletea podcastItem när vi får en match
                foreach (var stringURL in minutIntervall)
                {
                    foreach (var podItem in podLista)                                   //Loop i Loop så att vi kan kolla fler URL's via en enda metodAnrop
                    {
                        i++;                                                            //Håller koll på index så att vi tar bort rätt podcast
                        if (stringURL.Equals(podItem.PodcastsUrl))
                        {                    //jämför strängarna och letar efter en matchning
                            podcastRep.DeleteForPodNamn(podItem.PodcastsNamn);                                           //tar bort vår sparade podcast från listan
                            List<Avsnitt> podSomUppdateras = avsnittKontroller.HamtaAvsnittMedRssUrl(stringURL); //hämtar podcast o alla avsnitt från den URL vi just nu jämför
                            podItem.avsnittsLista = podSomUppdateras;
                            /*SkapaListForEnskildPodcast(podItem.PodcastsNamn, podItem.PodcastsUrl, podItem.PodcastsKategori, podItem.Frekvens);*/ //Skapar en uppdaterad version av current podcast och sparar i XML
                        }
                    }
                    i = 0; //Sätter index till 0 igen för att leta starta om processen och leta matchningar för nästa URL i List<string>tioMinuterLista
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DeletePodcastForKategori(int index1, int index2) { 
            
        }

        public void DeletePoddcastAtUrlCompare(string url)
        {
            List<Podcast> podLista = podcastRep.GetAll();

            for (int i = 0; i < podLista.Count; i++)
            {

                if (podLista[i].PodcastsUrl.Equals(url))
                {
                    podcastRep.Delete2(i);
                }
            }
        }

        public void KallaPaDelete(int index) {
            podcastRep.Delete2(index);
        }

        //public void HamtaInterVallForAllaPodcasts(string tio, string trettio, string sextio) KANSKE ANVÄNDA DENNA; TROR DOCK EJ
        //{
        //    List<Podcast> podcastIntervall = new List<Podcast>();
        //    List<string> tioMinuter = new List<string>();
        //    List<string> trettioMinuter = new List<string>();
        //    List<string> sextioMinuter = new List<string>();

        //    foreach (var item in podcastIntervall)
        //    {
        //        if (item.Frekvens.Equals(tio)) 
        //        {
        //            tioMinuter.Add(item.PodcastsUrl + " ");
        //        }
        //            if (item.Frekvens.Equals(trettio))
        //            {
        //                trettioMinuter.Add(item.PodcastsUrl + " ");
        //            }
        //                if (item.Frekvens.Equals(sextio))
        //                {
        //                    sextioMinuter.Add(item.PodcastsUrl + " ");
        //                }
        //    }
        //}





        //Exempel på virtual nedanför
        public override void KontrollerMetod()
        {
            Console.WriteLine("Tjabba");
        }
    }


    public class KontrollerKlass
        {


            public KontrollerKlass()
            {

            }

            public virtual void KontrollerMetod()
            {
                Console.WriteLine("hej");
            }
        }
    }
