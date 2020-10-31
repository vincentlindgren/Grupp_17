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

        //Metod för ändra kategorinamn, metod nedan kan typ användas med modifieringar. Kalla på SparaKategorier(newKategoriNamn) för att spara & Serializea

        //public Podcast SokPodcastEfterNamn(string sokNamn)
        //{ //Denna metod kan användas till byte av PodcastNamn med små modifieringar. Ta in sokNamn och newName. Kalla på SparaAllaAndringar();

        //    Podcast returneraPodcastOmHittad = new Podcast();
        //    List<Podcast> podLista = GetAll();

        //    foreach (var item in podLista)
        //    {
        //        if (item.PodcastsNamn.Equals(sokNamn))
        //        {
        //            returneraPodcastOmHittad = item;
        //            break;
        //        }
        //    }
        //    return returneraPodcastOmHittad;
        //}

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
