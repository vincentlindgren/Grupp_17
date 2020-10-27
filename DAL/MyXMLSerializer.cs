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

namespace DAL
{
    [Serializable]
    public class MyXMLSerializer
    {

        public MyXMLSerializer()
        {
            
        }


        public static void Serialize(List<Avsnitt> avsnitt, string podcastNamn)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(avsnitt.GetType());
            using (FileStream filSomSparas = new FileStream(podcastNamn + ".xml", FileMode.Create, FileAccess.Write))
            {

                xmlSerializer.Serialize(filSomSparas, avsnitt);
            }
        }


        public static int DeserializeList(string podcastNamn)
        {
            List<Avsnitt> listOfstudentObjToBeReturned;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Avsnitt>));
            
            using (FileStream inFile = new FileStream(podcastNamn + ".xml", FileMode.Open, FileAccess.Read))
            {
                listOfstudentObjToBeReturned = (List<Avsnitt>)xmlSerializer.Deserialize(inFile);

                    int i = 0;
                    foreach (var item in listOfstudentObjToBeReturned)
                    {
                        i++;
                    }

                    return i;
            }

        }

    }
}

