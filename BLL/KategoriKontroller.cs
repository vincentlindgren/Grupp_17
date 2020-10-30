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
        }
        

        public void SparaKategorier(string kategoriNamn) {
            PodKategori kategoriAttLäggaTill = new PodKategori(kategoriNamn);
            kategoriLista.Add(kategoriAttLäggaTill);
            dataSerializer.Serialize(kategoriLista);
        }

        public List<PodKategori> LaddaInKategorier() {
            List<PodKategori> kategoriListaAttReturnera = new List<PodKategori>();

            List<PodKategori> laddaKategoriLista = dataSerializer.DeserializeKategoriLista();

            foreach (var item in laddaKategoriLista)
            {
                kategoriListaAttReturnera.Add(item);
            }
            Console.WriteLine(kategoriListaAttReturnera);
            return kategoriListaAttReturnera;
            

        }
    }
}
