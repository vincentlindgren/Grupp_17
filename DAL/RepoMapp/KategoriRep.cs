using System;
using System.Collections.Generic;
using System.Text;
using DAL;
namespace DAL.RepoMapp
{
    public class KategoriRep : IKategoriRep<PodKategori>
    {
        DataSerializer dataSerializer;
        List<PodKategori> podKatLista;

        public KategoriRep() {

            dataSerializer = new DataSerializer();
            podKatLista = new List<PodKategori>();
            podKatLista  = GetAll();
            
        }

 
        public void Skapa(PodKategori podKategori) {
            podKatLista.Add(podKategori);
            SparaAllaAndringar();
        }
        public void Spara(int index, PodKategori podKategori) { 
        
            
        }
        public void Delete(int index) {
            List<PodKategori> nyLista = GetAll();
            nyLista.RemoveAt(index);
            podKatLista = nyLista;
            SparaAllaAndringar();
        }

        public void Delete2(int index) {
            podKatLista.RemoveAt(index);
            SparaAllaAndringar();
        }

        public void SparaAllaAndringar() {
            dataSerializer.Serialize(podKatLista);
        }

        public List<PodKategori> GetAll() {

            List<PodKategori> katListReturneras = new List<PodKategori>();

            try
            {
                katListReturneras = dataSerializer.DeserializeKategoriLista();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return katListReturneras;
        }


        

        public void AndraPodcastKategori(string oldKategoriNamn, string newKategoriNamn)
        {
            podKatLista = GetAll();
            foreach (var item in podKatLista)
            {
                if (item.KategoriNamn.Equals(oldKategoriNamn))
                {
                    item.KategoriNamn = "";
                    item.KategoriNamn = newKategoriNamn;
                    Console.WriteLine(item.KategoriNamn);
                    SparaAllaAndringar();
                }
            }
        }
    }
}
