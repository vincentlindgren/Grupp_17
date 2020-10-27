using System;
using DAL;

namespace BLL
{
    public class BLL1
    {
        public static void BLL1TestaRSS(string inputURL, string podcastNamn) {
            Avsnitt.TestaRSS(inputURL, podcastNamn);
           
        }

        public static int BLL1RaknaAvsnitt(string podcastNamn)
        {
            int antalAvsnitt = 0;
            MyXMLSerializer.DeserializeList(podcastNamn);

            return antalAvsnitt;

        }

    }
}
