using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace DAL
{
    public class Avsnitt //Döp om klassen till mer beskrivande för funktionen
    {
        public string AvsnittsNummer { get; set; }
        public string AvsnittsNamn { get; set; }

        public MyXMLSerializer mySerializerObj { get; set; }


        public Avsnitt(string ett, string tva)
        {
            AvsnittsNummer = ett;
            AvsnittsNamn = tva;
            mySerializerObj = new MyXMLSerializer();
        }

        public Avsnitt()
        {
            mySerializerObj = new MyXMLSerializer();
        }

        // Podcast, avsnittsnamn, avsnittsbeskrivningbeskrivning, avsnittsnummer //Grunden för metoden för att hämta och läsa XML-filen från RSS-URL
        public void TestaRSS(string inputURL, string podcastNamn) //Döp om metodnamn till annat än TESTARSS LOL
        {
            XmlReader reader = XmlReader.Create(inputURL); 
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            Console.WriteLine("--- Title ---" + feed.Title.Text);
            Console.WriteLine("--- Description ---" + feed.Description.Text);
            Console.WriteLine();

           
            List<Avsnitt> avsnitt = new List<Avsnitt>();
            
            avsnitt.Add(new Avsnitt(inputURL, podcastNamn)); //Tror inte denna rad används, tror vi skrev den för att få med URL-en i det sparade XML-dokumentet
            try
            {
                foreach (var item in feed.Items)
            {
                avsnitt.Add(new Avsnitt(item.Title.Text, item.Summary.Text));

                    Console.WriteLine(item.Title.Text);
                    Console.WriteLine("-> " + item.Summary.Text);
                    Console.WriteLine();
            }
            
                mySerializerObj.Serialize(avsnitt, podcastNamn); //Skickar listan av avsnitt från URL till annan klass som skapar ny XML fil & sparar xml-filen lokalt
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        public string hamtaPodcastNamn(string inputURL) { //fixa ta bort statisk
            //Läser RSS-feeden och returnerar podcastens titel som sträng.
            //Används för att sätta default - namn om användaren inte själv namnsätter podcasten.

            XmlReader reader = XmlReader.Create(inputURL); 
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            string namnAttReturnera = feed.Title.Text;
            return namnAttReturnera;
        }
    }
}
    

