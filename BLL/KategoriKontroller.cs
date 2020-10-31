using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace BLL
{
    public class KategoriKontroller
    {

        List<PodKategori> kategoriLista;
        DataSerializer dataSerializer;

        public KategoriKontroller() {
            kategoriLista = new List<PodKategori>();
            dataSerializer = new DataSerializer();
            kategoriLista = GetAllKategorier();
        }
        

        public void SparaKategorier(string kategoriNamn) {
            PodKategori kategoriAttLäggaTill = new PodKategori(kategoriNamn);
            kategoriLista.Add(kategoriAttLäggaTill);
            
            dataSerializer.Serialize(kategoriLista);
        }



        public List<PodKategori> GetAllKategorier()
        {

            List<PodKategori> kategoriListReturneras = new List<PodKategori>();

            try
            {
                kategoriListReturneras = dataSerializer.DeserializeKategoriLista();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return kategoriListReturneras;
        }
    
    }
}
