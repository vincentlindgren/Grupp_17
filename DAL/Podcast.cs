using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Syndication;
using System.Xml;

namespace DAL
{
    public class Podcast 

    {
    public string PodcastsNamn { get; set; }

    public int AntalAvsnitt { get; set; }

    public string Frekvens { get; set; }

    public string PodcastsKategori { get; set; }

    public string PodcastsUrl { get; set; }

    public List<Avsnitt> avsnittsLista { get; set; }


        public Podcast(string namn, string url, string kategori, int antalAvsnitt, string frekvens, List<Avsnitt> avsnitt)
        {
            PodcastsNamn = namn;
            PodcastsUrl = url;
            PodcastsKategori = kategori;
            AntalAvsnitt = antalAvsnitt;
            Frekvens = frekvens;
            avsnittsLista = avsnitt;
        }

        public Podcast() {
            

        }

        //public class VisualPodcast : IPodcast {

        //    public void Play() { //om objektet är en "VisualPodcast" kommer denna metod att anropas
        //                                  //Detta används för att man ska kunna trycka på play oavsett vilken 

        //        List<IPodcast> pList = new List<IPodcast>();
        //        pList.Add(new Podcast());
        //        pList.Add(new VisualPodcast());

        //        foreach (var item in pList) {
        //            item.Play();
        //        }

        //    }
    }
}
