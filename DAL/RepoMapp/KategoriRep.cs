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


        public PodKategori SokKategoriEfterNamn(string sokNamn)
        { //Denna metod kan användas till byte av PodcastNamn med små modifieringar. Ta in sokNamn och newName. Kalla på SparaAllaAndringar();

            PodKategori katListReturneras = new PodKategori();
            List<PodKategori> katLista = GetAll();

            foreach (var item in katLista)
            {
                if (item.KategoriNamn.Equals(sokNamn))
                {
                    katListReturneras = item;
                    break;
                }
            }
            return katListReturneras;
        }

        public string HamtaNamn(int index)
        {
            return podKatLista[index].KategoriNamn;
        }

        
    }
}
