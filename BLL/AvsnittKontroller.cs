using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.ServiceModel.Syndication;
using System.Xml;
using DAL.RepoMapp;
using System.Threading.Tasks;
using System.Linq;

namespace BLL
{
    public class AvsnittKontroller
    {
        PodcastRep podRep = new PodcastRep();

        public AvsnittKontroller() {
            podRep = new PodcastRep();
        }


        public async Task<List<Avsnitt>> HamtaAvsnittMedRssUrlAsync(string inputURL)  //<<<<<----- ASYNQ
        {
            List<Avsnitt> avsnittLista = new List<Avsnitt>();
            try
            {
                XmlReader reader = XmlReader.Create(inputURL);
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                await Task.Run(() =>
                {
                    foreach (var item in feed.Items)
                    {
                        avsnittLista.Add(new Avsnitt(item.Title.Text, item.Summary.Text));
                        
                    }
                });
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
            return avsnittLista;
        }

        public List<Avsnitt> HamtaAvsnittMedRssUrl(string inputURL)
        {
            List<Avsnitt> avsnittLista = new List<Avsnitt>();
            try
            {
                XmlReader reader = XmlReader.Create(inputURL);
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                    foreach (var item in feed.Items)
                    {
                        avsnittLista.Add(new Avsnitt(item.Title.Text, item.Summary.Text));
                        
                    } 
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
            return avsnittLista;
        }

        public List<Avsnitt> HamtaAvsnittForPodcast(string valdPodcast) 
        {
            List<Avsnitt> avsnittListaAttReturnera = new List<Avsnitt>();
            List<Podcast> podcastLista = podRep.GetAll();
            foreach (var pod in from pod in podcastLista                        //<<<----- LINQ
                                where pod.PodcastsNamn.Equals(valdPodcast)
                                select pod)
            {
                avsnittListaAttReturnera = pod.avsnittsLista;
                break;
            }

            return avsnittListaAttReturnera;
        }

        public int RaknaAntalAvsnitt(string url) 
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
