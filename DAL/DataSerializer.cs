using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System;

namespace DAL
{
    public class DataSerializer
    {
        
        public DataSerializer()
        {
                
        }

        public void Serialize(List<Podcast> podLista)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(podLista.GetType());
            using (FileStream filSomSparas = new FileStream("PodcastInfo.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(filSomSparas, podLista);
            }
        }

        public List<Podcast> Deserialize()
        {
            List<Podcast> returnPodcastLista;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Podcast>));

            using (FileStream sparadFil = new FileStream("PodcastInfo.xml", FileMode.Open, FileAccess.Read))
            {
                returnPodcastLista = (List<Podcast>)xmlSerializer.Deserialize(sparadFil);
            }
            return returnPodcastLista;
        }


        public void Serialize(List<PodKategori> listAvKategorier)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(listAvKategorier.GetType());
            using (FileStream filSomSparas = new FileStream("PodcastKategorier.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(filSomSparas, listAvKategorier);
            }
        }

        public List<PodKategori> DeserializeKategoriLista()
        {
            List<PodKategori> returnKategoriLista;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PodKategori>));

            using (FileStream sparadFil = new FileStream("PodcastKategorier.xml", FileMode.Open, FileAccess.Read))
            {
                returnKategoriLista = (List<PodKategori>)xmlSerializer.Deserialize(sparadFil);
            }
                return returnKategoriLista;
            }
        }
}
