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
    }
}
