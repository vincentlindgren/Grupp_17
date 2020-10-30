using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.RepoMapp;
using System.ServiceModel.Syndication;
using System.Xml;

namespace BLL
{
   public class PodcastKontroller
    {
        AvsnittKontroller avsnittKontroller = new AvsnittKontroller();
        PodcastRep podRep = new PodcastRep();
        private IPodcastRep<Podcast> podcastRep;

        public PodcastKontroller() {
            podcastRep = new PodcastRep();
        }

        public string HamtaPodcastNamn(string url) 
        {
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            string podNamnAttReturnera = feed.Title.Text;

            return podNamnAttReturnera;
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
            catch (Exception exc) {
                Console.WriteLine(exc);
            }
        }

    }
}
