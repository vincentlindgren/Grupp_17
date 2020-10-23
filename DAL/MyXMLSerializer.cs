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
            public static void Serialize(List<Avsnitt> avsnitt) {
                XmlSerializer xmlSerializer = new XmlSerializer(avsnitt.GetType());
                using (FileStream outFile = new FileStream("AvsnittsLista.xml", FileMode.Create, FileAccess.Write)) {
                    xmlSerializer.Serialize(outFile, avsnitt);
                }
            }

     
    }

}

