using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Serialization;
using DAL;


namespace Grupp_17
{ 
    [Serializable]
    public class TestaRSSXML
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TestaRSSXML(string title, string descr)
        {
            Title = title;
            Description = descr;
        }
    }
    
    public class MyBinarySerializer
    {
        BinaryFormatter binaryFormatter;
        public MyBinarySerializer()
        {
            binaryFormatter = new BinaryFormatter();
        }

       public class MainClass
        {
            //  public void genvag()
            //{
            //    Avsnitt.TestaRSS(inputURL);

            //}


            

          
        }
    }

    
}
