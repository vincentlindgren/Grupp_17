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
    public class Avsnitt
    {
        public string AvsnittsNummer { get; set; }
        public string AvsnittsNamn { get; set; }

        public Avsnitt(string ett, string tva)
        {
            AvsnittsNummer = ett;
            AvsnittsNamn = tva;

        }

        public Avsnitt()
        {
        }

        // Podcast, avsnittsnamn, avsnittsbeskrivningbeskrivning, avsnittsnummer //Grunden för metoden för att hämta och läsa XML-filen från RSS-URL "https://feed.pod.space/filipandfredrik"
        public static void TestaRSS(string inputURL)
        {
            XmlReader reader = XmlReader.Create(inputURL);
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            Console.WriteLine("--- Title ---" + feed.Title.Text);
            Console.WriteLine("--- Description ---" + feed.Description.Text);
            Console.WriteLine();

            List<Avsnitt> avsnitt = new List<Avsnitt>();

            foreach (var item in feed.Items)
            {
                avsnitt.Add(new Avsnitt(item.Title.Text, item.Summary.Text));

                Console.WriteLine(item.Title.Text);
                Console.WriteLine("-> " + item.Summary.Text);
                Console.WriteLine();

                //avsnittsNamn = feed.Title.Text;
                //avsnittsListaInnan.Add(avsnittsNamn, avsnittsNummer);
            }
            try
            {
                MyXMLSerializer.Serialize(avsnitt);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }

    }
}
    

