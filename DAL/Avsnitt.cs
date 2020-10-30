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
            AvsnittsNummer = ett; //Detta är egentligen "Avsnitts TITEL / RUBRIK"
            AvsnittsNamn = tva; //Detta är egentligen "Avsnitts BESKRIVNING"
            //mySerializerObj = new MyXMLSerializer();
        }

        public Avsnitt()
        {
            mySerializerObj = new MyXMLSerializer();
        }

        // Podcast, avsnittsnamn, avsnittsbeskrivningbeskrivning, avsnittsnummer //Grunden för metoden för att hämta och läsa XML-filen från RSS-URL
        public List<Avsnitt> TestaRSS(string inputURL, string podcastNamn) //Döp om metodnamn till annat än TESTARSS LOL
        {
            try
            {
                XmlReader reader = XmlReader.Create(inputURL); 
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                Console.WriteLine("--- Title ---" + feed.Title.Text);
                Console.WriteLine("--- Description ---" + feed.Description.Text);
                Console.WriteLine();

                List<Avsnitt> avsnittLista = new List<Avsnitt>();

                foreach (var item in feed.Items)
                {

                    avsnittLista.Add(new Avsnitt(item.Title.Text, item.Summary.Text));

                    Console.WriteLine(item.Title.Text);
                    Console.WriteLine("-> " + item.Summary.Text);
                    Console.WriteLine();
                }
                return avsnittLista; //Se till att när denna metod kallas på att den returnerade List<Avsnitt> faktiskt skickas till Serialize-metoden
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }

        //public List<Avsnitt> HamtaAvsnittForV

        public string hamtaPodcastNamn(string inputURL) { 
            //Läser RSS-feeden och returnerar podcastens titel som sträng.
            //Används för att sätta default - namn om användaren inte själv namnsätter podcasten.

            XmlReader reader = XmlReader.Create(inputURL); 
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            string namnAttReturnera = feed.Title.Text;
            return namnAttReturnera;
        }
    }
}
    

