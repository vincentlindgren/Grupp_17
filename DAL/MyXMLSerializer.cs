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
    //[Serializable]
    public class MyXMLSerializer
    {
        

        public MyXMLSerializer()
        {
            
        }

        //public void Serialize(List<Podcast> podLista) {                           <----------- Nästkommande 4 metoder ligger i DataSerializer (Ny fredag 30 okt)
        //    XmlSerializer xmlSerializer = new XmlSerializer(podLista.GetType());
        //    using (FileStream filSomSparas = new FileStream("PodcastInfo.xml", FileMode.Create, FileAccess.Write)) 
        //    {
        //        xmlSerializer.Serialize(filSomSparas, podLista);
        //    }
        //}

        //public List<Podcast> Deserialize() {
        //    List<Podcast> returnPodcastLista;
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Podcast>));

        //    using (FileStream sparadFil = new FileStream("PodcastInfo.xml", FileMode.Open, FileAccess.Read)) {
        //        returnPodcastLista = (List<Podcast>)xmlSerializer.Deserialize(sparadFil);
        //    }
        //    return returnPodcastLista;
        //}


        //public void Serialize(List<PodKategori> listAvKategorier) 
        //{  
        //    XmlSerializer xmlSerializer = new XmlSerializer(listAvKategorier.GetType());
        //    using (FileStream filSomSparas = new FileStream("PodcastKategorier.xml", FileMode.Create, FileAccess.Write))
        //    {
        //        xmlSerializer.Serialize(filSomSparas, listAvKategorier);
        //    }
        //}

        //public List<PodKategori> DeserializeKategoriLista() 
        //{ 
        //    List<PodKategori> returnKategoriLista;
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PodKategori>));

        //    using (FileStream sparadFil = new FileStream("PodcastInfo.xml", FileMode.Open, FileAccess.Read))
        //    {
        //        returnKategoriLista = (List<PodKategori>)xmlSerializer.Deserialize(sparadFil);
        //    }
        //    return returnKategoriLista;
        //}





        //Under denna rad gammal kod som ej fungerar helt 100
        public void Serialize(List<Avsnitt> avsnitt, string podcastNamn) //Method overloading kriteriet <--
        {
            XmlSerializer xmlSerializer = new XmlSerializer(avsnitt.GetType());
            using (FileStream filSomSparas = new FileStream(podcastNamn + ".xml", FileMode.Create, FileAccess.Write)) // Denna rad kan användas i catch-Blocket för att skapa ny fil om PodcastInfo.xml inte redan existerar.
            {

                xmlSerializer.Serialize(filSomSparas, avsnitt);
            }
        }

        public void Serialize(List<Podcast> podcasts)
        {
            //Denna metod är gamla, se om behöver ta något från denna!!!!!       <<<< -------

            ListsForXml listsForXml = new ListsForXml(); //Wrapper för podcastlista så att Det går att spara flera Podcasts i listan.
            listsForXml.podcastLista = podcasts;

            XmlSerializer xmlSerializer = new XmlSerializer(listsForXml.GetType());

            try
            {
                using (FileStream filSomFyllsPa = File.Open("PodcastInfo", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {

                    xmlSerializer.Serialize(filSomFyllsPa, listsForXml);
                }
            }
            catch (FileNotFoundException exFileNotFound)
            {
                using (FileStream filSomFyllsPa = new FileStream("PodcastInfo.xml", FileMode.Create, FileAccess.Write))
                {
                    Console.WriteLine(exFileNotFound);
                    xmlSerializer.Serialize(filSomFyllsPa, listsForXml);
                }
            }
        }


        public void Serialize(ListsForXml podxmlList)
        {  //Method overloading kriteriet <-- Wrappa listan i annat objekt. Annan klass som har lista av podcasts skickas in här
           
            XmlSerializer xmlSerializer = new XmlSerializer(podxmlList.GetType());
            

            try
            {
                using (FileStream filSomFyllsPa = File.Open("PodcastInfo.xml", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    xmlSerializer.Serialize(filSomFyllsPa, podxmlList);
                }
            }
            catch(FileNotFoundException exFileNotFound) {
                using (FileStream filSomSkapas = new FileStream("PodcastInfo.xml", FileMode.Create, FileAccess.Write))
                {
                    Console.WriteLine(exFileNotFound);
                    Console.WriteLine(podxmlList.ToString());
                    xmlSerializer.Serialize(filSomSkapas, podxmlList);
                }
            }
        }

        //catch (FileNotFoundException)
        //    {
        //        string directory = AppDomain.CurrentDomain.BaseDirectory;
        //System.IO.Path.Combine(directory, _filename);
        //        List<string> emptyList = new List<string>();
        //        return emptyList;
        //    }

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

            //XmlDocument xmlDokument = new XmlDocument(); Detta sätt kanske kan användas men kommer isf behöva skriva om hela koden
            //xmlDokument.Load("PodcastInfo.xml");

            //XmlElement rotElement = xmlDokument.CreateElement("podcastLista");
            //rotElement.AppendChild(listsForXml);

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
                Serialize(listsForXml.podcastLista);
            }

            return listsForXml.podcastLista;
        
        }

        
    }
}

