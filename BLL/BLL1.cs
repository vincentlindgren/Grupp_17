using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    public class BLL1
    {
        public MyXMLSerializer myXmlObj { get; set; }
        public Avsnitt avsnittObj { get; set; }
        public Podcast podcastObj { get; set; }

        public BLL1() {
            myXmlObj = new MyXMLSerializer();
            avsnittObj = new Avsnitt();
            podcastObj = new Podcast();

        }

        public BLL1(MyXMLSerializer xmlObj) {
            myXmlObj = new MyXMLSerializer();
        }

        public void BLL1TestaRSS(string inputURL, string podcastNamn) {
            avsnittObj.TestaRSS(inputURL, podcastNamn);
           
        }

        public int BLL1RaknaAvsnitt(string podcastNamn)
        {
            int antalAvsnitt = myXmlObj.DeserializeList(podcastNamn);
            return antalAvsnitt;

        }

        public List<Podcast> LaddaInPodcasts() {

            List<Podcast> podListIBll = myXmlObj.DeserializePodcastList();
            return podListIBll;
        }


        public void SkickaPodInfoTillPodInfoSkapandet(string podcastNamn, string podcastURL, string podcastKategori, int antalAvsnitt) {
            List<Podcast> podLista = new List<Podcast>();
           // podLista.Add(new Podcast(podcastNamn, podcastURL, podcastKategori, antalAvsnitt));

            ListsForXml listsForXml = new ListsForXml();

            listsForXml.podcastLista = podLista;

            try
            {
                //podcastLista.Add(new Podcast(podcastNamn, podcastURL, podcastKategori, antalAvsnitt));
                myXmlObj.Serialize(listsForXml);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
