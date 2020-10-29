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
using static DAL.DAL1;
using static DAL.Podcast;

namespace DAL
{
    [Serializable]
    public class MyXMLSerializer
    {
        public Podcast myPodcastObj {get; set;}
        public MyXMLSerializer()
        {
            myPodcastObj = new Podcast();
        }


        public void Serialize(List<Avsnitt> avsnitt, string podcastNamn) //Method overloading kriteriet <--
        {
            XmlSerializer xmlSerializer = new XmlSerializer(avsnitt.GetType());
            using (FileStream filSomSparas = new FileStream(podcastNamn + ".xml", FileMode.Create, FileAccess.Write)) // Denna rad kan användas i catch-Blocket för att skapa ny fil om PodcastInfo.xml inte redan existerar.
            {

                xmlSerializer.Serialize(filSomSparas, avsnitt);
            }
        }

        public void Serialize(List<Podcast> podcasts){  //Method overloading kriteriet <-- Wrappa listan i annat objekt. Annan klass som har lista av podcasts skickas in här

           ListsForXml listsForXml = new ListsForXml(); //Wrapper för podcastlista så att Det går att spara flera Podcasts i listan.
           listsForXml.podcastLista = podcasts;

           XmlSerializer xmlSerializer = new XmlSerializer(listsForXml.GetType());
           using (FileStream filSomFyllsPa = File.Open("PodcastInfo.xml", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
           {
              
              xmlSerializer.Serialize(filSomFyllsPa, listsForXml);
           }
        }

        public void Serialize(ListsForXml podxmlList)
        {  //Method overloading kriteriet <-- Wrappa listan i annat objekt. Annan klass som har lista av podcasts skickas in här
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListsForXml));
            //ListsForXml listsForXml = new ListsForXml();
            ListsForXml listsForXml = podxmlList;

            using (FileStream filSomFyllsPa = File.Open("PodcastInfo.xml", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {

                xmlSerializer.Serialize(filSomFyllsPa, listsForXml);
            }
        }

        public int DeserializeList(string podcastNamn) //implementera TRY CATCH för om den inte hittar filen
        {

            List<Avsnitt> listAvSparadPodcast;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Avsnitt>));
            
            using (FileStream inFile = new FileStream(podcastNamn + ".xml", FileMode.Open, FileAccess.Read))
            {
                listAvSparadPodcast = (List<Avsnitt>)xmlSerializer.Deserialize(inFile);

                    int i = 0;
                    foreach (var item in listAvSparadPodcast)
                    {
                        i++;
                    }
                    return i;
            }
        }

        public List<Podcast> DeserializePodcastList() {
            
            ListsForXml listsForXml = new ListsForXml();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListsForXml));

            try
            {
                using (FileStream inFile = new FileStream("PodcastInfo.xml", FileMode.Open, FileAccess.Read))
                {
                    listsForXml = (ListsForXml)xmlSerializer.Deserialize(inFile);
                }
            }
            catch (InvalidOperationException exc) {
                Console.WriteLine(exc);
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc);
                SkapaPodcastInfoXMLFilOmEjExist(listsForXml);
            }

            return listsForXml.podcastLista;
        
        }

        public void SkapaPodcastInfoXMLFilOmEjExist(ListsForXml listsForXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ListsForXml));
            using (FileStream filSomSparas = new FileStream("PodcastInfo.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(filSomSparas, listsForXml);
            }

        }
    }
}

