using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Podcast 

    {
        public string PodcastsNamn { get; set; }

        public string PodcastsUrl { get; set; }

        public string PodcastsKategori { get; set; }

        public int AntalAvsnitt { get; set; }

        public int MyProperty { get; set; }

        public MyXMLSerializer xMLSerializer { get; set; }

   
        public Podcast(string namn, string url, string kategori, int antalAvsnitt)
        {
            PodcastsNamn = namn;
            PodcastsUrl = url;
            PodcastsKategori = kategori;
            AntalAvsnitt = antalAvsnitt;
            xMLSerializer = new MyXMLSerializer();
        }

        public Podcast() {
            
        }


        public void SkapaListForEnskildPodcast(string podcastNamn, string podcastURL, string podcastKategori, int antalAvsnitt) {

            List<Podcast> podcastLista = new List<Podcast>();

            podcastLista.Add(new Podcast(podcastNamn, podcastURL, podcastKategori, antalAvsnitt));
            try
            {
                xMLSerializer.Serialize(podcastLista); //Skickar listan av avsnitt från URL till annan klass som skapar ny XML fil & sparar xml-filen lokalt
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    //    public void Play() { } //om objektet är en "Podcast" kommer denna metod att anropas
    //                                   //Denna i sin egen klass ska spela upp en podcast
 
    //    }

    //public interface IPodcast { //Interface skapas i en egen fil helst, gör detta här också

    //     void Play();
    //}



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
