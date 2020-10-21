using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Serialization;

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
            public static void testaRSS()
            {
                XmlReader reader = XmlReader.Create("https://feed.pod.space/filipandfredrik");
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                Console.WriteLine("--- Title ---" + feed.Title.Text);
                Console.WriteLine("--- Description ---" + feed.Description.Text);
                Console.WriteLine();

                foreach (var item in feed.Items)
                {
                    Console.WriteLine(item.Title.Text);
                    Console.WriteLine("-> " + item.Summary.Text);
                    Console.WriteLine();
                }

            }

          
        }
    }


}
