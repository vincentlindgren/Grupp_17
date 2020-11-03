using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.RepoMapp;

namespace BLL
{
    public class KategoriKontroller
    {

        //List<PodKategori> kategoriLista;
        DataSerializer dataSerializer;
        Podcast podcastobj;
        PodcastRep podRep;

        KategoriRep KategoriRep = new KategoriRep();
        

        public KategoriKontroller() {
            //kategoriLista = new List<PodKategori>();
            dataSerializer = new DataSerializer();
            //kategoriLista = GetAllKategorier();
            podcastobj = new Podcast();
            podRep = new PodcastRep();
            //KategoriRep = new KategoriRep();
        }
        

        public void SparaKategorier(string kategoriNamn) {

            PodKategori kategoriAttLäggaTill = new PodKategori(kategoriNamn);
            KategoriRep.Skapa(kategoriAttLäggaTill);

        }

        //Metod för ändra kategorinamn, metod nedan kan typ användas med modifieringar. Kalla på SparaKategorier(newKategoriNamn) för att spara & Serializea

        public List<Podcast> SokPodcastEfterPodcastKategori(string sokNamn) //Loopar igenom alla podcasts och returnerar en lista med samtliga podcasts som har en viss kategori.
        { 

            List<Podcast> returneraPodcastOmHittad = new List<Podcast>();
            List<Podcast> podLista = podRep.GetAll();

            foreach (var pod in podLista)
            {
                if (pod.PodcastsKategori.Equals(sokNamn))
                {
                    returneraPodcastOmHittad.Add(pod);
                    Console.WriteLine(pod.PodcastsNamn);
                }
            }
            return returneraPodcastOmHittad;
        }

        

        public List<PodKategori> GetAllKategorier()
        {
            List<PodKategori> kategoriListReturneras = KategoriRep.GetAll();
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

        public string HamtaKategoriNamn(string sokNamn) {
            string kategoriAttReturnera = "";
            List <PodKategori> katLista = KategoriRep.GetAll();

            foreach (var item in katLista)
            {
                if (item.KategoriNamn.Equals(sokNamn))
                {
                    kategoriAttReturnera = item.KategoriNamn;
                    break;
                }
            }
            return kategoriAttReturnera;
       
        }

        public void KallaPaAndraKategoriNamn(string oldKategoriNamn, string newKategoriNamn) {
           KategoriRep.AndraPodcastKategori(oldKategoriNamn, newKategoriNamn);
        }


        public void AnropaSparaKategoriLista() {
            KategoriRep.SparaAllaAndringar();
        }

        public void DeletePoddcastAtKategoriCompare(string sokNamn) // Samma som i PodcastKontroller KLAR!!!!
        {
            List<PodKategori> sokKategoriForKategoriList = KategoriRep.GetAll();

            foreach (var item in sokKategoriForKategoriList)
            {
                if (item.KategoriNamn.Equals(sokNamn))
                {
                    int index = sokKategoriForKategoriList.IndexOf(item);
                    KategoriRep.Delete2(index);
                }
            }
            //List<PodKategori> katLista = KategoriRep.GetAll();

            //for (int i = 0; i < katLista.Count; i++)
            //{

            //    if (katLista[i].KategoriNamn.Equals(sokNamn))
            //    {
            //        KategoriRep.Delete2(i);
            //        Console.WriteLine(sokNamn);
            //    }
            //}
        }

        //public void DeleteKategoriOchPodcasts(string kategoriNamn) {
        //    List<Podcast> kategoriListReturneras = podRep.SokPodcastEfterKategori(kategoriNamn);
        //    List<PodKategori> podKategorier = new List<PodKategori>();
        //    try
        //    {
        //        foreach (var item in kategoriListReturneras)
        //        {
        //            if (item.PodcastsKategori.Equals(kategoriNamn))
        //            {
        //                kategoriListReturneras.Remove(item);
        //                item.Clear();
        //            }
        //        }

        //        dataSerializer.Serialize(podKategorier);

        //    }
        //    catch (Exception exc)
        //    {
        //        Console.WriteLine(exc);
        //    }
        //}
    }
}
