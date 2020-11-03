using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.RepoMapp;

namespace BLL
{
    public class KategoriKontroller
    {

        
        DataSerializer dataSerializer;
        Podcast podcastobj;
        PodcastRep podRep;

        KategoriRep KategoriRep = new KategoriRep();
        

        public KategoriKontroller() {
            dataSerializer = new DataSerializer();
            podcastobj = new Podcast();
            podRep = new PodcastRep();
        }
        

        public void SparaKategorier(string kategoriNamn) {

            PodKategori kategoriAttLäggaTill = new PodKategori(kategoriNamn);
            KategoriRep.Skapa(kategoriAttLäggaTill);

        }


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


        //public string HamtaKategoriNamn(string sokNamn) {
        //    string kategoriAttReturnera = "";
        //    List <PodKategori> katLista = KategoriRep.GetAll();

        //    foreach (var item in katLista)
        //    {
        //        if (item.KategoriNamn.Equals(sokNamn))
        //        {
        //            kategoriAttReturnera = item.KategoriNamn;
        //            break;
        //        }
        //    }
        //    return kategoriAttReturnera;
        //}
                                                //^^ Kommenterat bort för att testa att testa ifall det kan tas bort ^^^^^^


        public void KallaPaAndraKategoriNamn(string oldKategoriNamn, string newKategoriNamn) {
           KategoriRep.AndraPodcastKategori(oldKategoriNamn, newKategoriNamn);
        }


        //public void AnropaSparaKategoriLista() {
        //    KategoriRep.SparaAllaAndringar();
        //}
                                                    //^^ Kommenterat bort för att testa att testa ifall det kan tas bort ^^^^^^



        public void DeletePoddcastAtKategoriCompare(string sokNamn) 
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
        }
    }
}
