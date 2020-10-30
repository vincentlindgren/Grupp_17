using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.ServiceModel.Syndication;
using System.Xml;
using DAL.RepoMapp;

namespace BLL
{
    public class AvsnittKontroller
    {
        PodcastRep podRep = new PodcastRep();

        public AvsnittKontroller() {
            podRep = new PodcastRep();
        }


        public List<Avsnitt> HamtaAvsnittMedRssUrl(string inputURL) 
        {
            List<Avsnitt> avsnittLista = new List<Avsnitt>();
            try
            {
                XmlReader reader = XmlReader.Create(inputURL);
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                Console.WriteLine("--- Title ---" + feed.Title.Text);
                Console.WriteLine("--- Description ---" + feed.Description.Text);
                Console.WriteLine();

                //List<Avsnitt> avsnittLista = new List<Avsnitt>();

                foreach (var item in feed.Items)
                {

                    avsnittLista.Add(new Avsnitt(item.Title.Text, item.Summary.Text));

                    Console.WriteLine(item.Title.Text);
                    Console.WriteLine("-> " + item.Summary.Text);
                    Console.WriteLine();
                }
                //return avsnittLista; //Se till att när denna metod kallas på att den returnerade List<Avsnitt> faktiskt skickas till Serialize-metoden
            }
            catch (Exception e) //Fixa bättre exception-hantering än denna som fångar ALLA exceptions lol
            {
                Console.WriteLine(e);
                //throw; //throw används för att säga till medtoden att ej returna List<Avsnitt> om den catchar ett exception.
            }
            return avsnittLista;
        }

        public List<Avsnitt> HamtaAvsnittForPodcast(string valdPodcast) 
        {
            List<Avsnitt> avsnittListaAttReturnera = new List<Avsnitt>();
            List<Podcast> podcastLista = podRep.GetAll();

            foreach (var pod in podcastLista)
            {
                if (pod.PodcastsNamn.Equals(valdPodcast)) {
                    avsnittListaAttReturnera = pod.avsnittsLista;
                    break;
                }
            }
            return avsnittListaAttReturnera;
        }

        //public Podcast SokPodcastEfterNamn(string sokNamn)
        //{

        //    Podcast returneraPodcastOmHittad = new Podcast();
        //    List<Podcast> podLista = GetAll();

        //    foreach (var item in podLista)
        //    {
        //        if (item.PodcastsNamn.Equals(sokNamn))
        //        {
        //            returneraPodcastOmHittad = item;
        //            break;
        //        }
        //    }
        //    return returneraPodcastOmHittad;
        //}



        public int RaknaAntalAvsnitt(string url) //implementera TRY CATCH för om den inte hittar filen
        {
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed podAttRaknaAntalAvsnitt = SyndicationFeed.Load(reader);
            int antalAvsnitt = 0; 

                foreach (var item in podAttRaknaAntalAvsnitt.Items)
                {
                antalAvsnitt++;
                }
                return antalAvsnitt;
        }
    }
}
