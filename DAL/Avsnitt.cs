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
        public string AvsnittsNummer { get; set; }       //Detta är egentligen "Avsnitts TITEL / RUBRIK"
        public string AvsnittsNamn { get; set; }         //Detta är egentligen "Avsnitts BESKRIVNING"



        public Avsnitt(string ett, string tva)
        {
            AvsnittsNummer = ett; //Detta är egentligen "Avsnitts TITEL / RUBRIK"
            AvsnittsNamn = tva; //Detta är egentligen "Avsnitts BESKRIVNING"
        }

        public Avsnitt()
        {
            
        }

    }
}
    

