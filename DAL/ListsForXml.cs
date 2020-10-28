using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ListsForXml
    {
        public List<Podcast> podcastLista {get; set;}

        public ListsForXml() {
            podcastLista = new List<Podcast>();
        }
        
    }
}
