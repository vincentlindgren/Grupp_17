using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class PodKategori
    {
        public string KategoriNamn { get; set; }


        public PodKategori(string kategoriNamn) {

            KategoriNamn = kategoriNamn;
        }

        public PodKategori() { 
            
        }
         
        private static readonly string[] forInlagdaKategorier = { //Kolla funktionaliteten <-------
            @"Humor", @"Forskning", @"Filosofi", @"Politik", @"Dokumentärer"

        };
    }
}
