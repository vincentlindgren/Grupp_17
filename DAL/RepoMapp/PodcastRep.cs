using System;
using System.Collections.Generic;

namespace DAL.RepoMapp
{
    public class PodcastRep : IPodcastRep<Podcast>
    {
        DataSerializer dataSerializer;
        List<Podcast> podLista;

        public PodcastRep()
        {
            dataSerializer = new DataSerializer();
            podLista = new List<Podcast>();
            podLista = GetAll();
        }

        public void Skapa(Podcast podcast)
        {
            podLista.Add(podcast);
            SparaAllaAndringar();
        }

        public void Spara(int index, Podcast podcast)
        {

        }

        public void Delete2(int index)
        {
            podLista.RemoveAt(index);
            //SparaAllaAndringar();
        }

        public void Delete(int index)
        {
            //podLista.RemoveAt(index);
            List<Podcast> nyLista = GetAll();
            nyLista.RemoveAt(index);
            podLista = nyLista;
            SparaAllaAndringar();
        }

        public void DeleteForPodNamn(string namn)
        {
            List<Podcast> nyLista = GetAll();
            foreach (var podcast in nyLista)
            {
                if (podcast.PodcastsNamn.Equals(namn))
                {
                    podcast.avsnittsLista.Clear();
                }
            }
        }


        public void SparaAllaAndringar()
        {
            dataSerializer.Serialize(podLista);
        }

        public List<Podcast> GetAll()
        {
            List<Podcast> podListReturneras = new List<Podcast>();

            try
            {
                podListReturneras = dataSerializer.Deserialize();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            return podListReturneras;
        }

        public Podcast SokPodcastEfterNamn(string sokNamn)
        { //Denna metod kan användas till byte av PodcastNamn med små modifieringar. Ta in sokNamn och newName. Kalla på SparaAllaAndringar();

            Podcast returneraPodcastOmHittad = new Podcast();
            List<Podcast> podLista = GetAll();

            foreach (var item in podLista)
            {
                if (item.PodcastsNamn.Equals(sokNamn))
                {
                    returneraPodcastOmHittad = item;
                    break;
                }
            }
            return returneraPodcastOmHittad;
        }

        public int ReturnAntalAvsnitt(string namn)
        {
            List<Podcast> podLista = GetAll();
            int returneraAntalAvsnitt = 0;
            foreach (var item in podLista)
            {
                if (item.PodcastsNamn.Equals(namn))
                {
                    returneraAntalAvsnitt = item.AntalAvsnitt;
                    break;
                }
            }
            return returneraAntalAvsnitt;
        }

        public void DeletePodcastEfterKategori(string sokKategori)
        { 
            for (int index = GetAll().Count - 1; index >= 0; index--) {
                if (GetAll()[index].PodcastsKategori.Equals(sokKategori)) {
                    Delete2(index);
                }
            }
        }

        public List<Podcast> SokPodcastEfterKategori(string sokKategori)
        { //ska kallas på när man väljer kategori från cmb samt när man delete'ar alla podcasts i en kategori
            List<Podcast> sokPodcastsForKategoriList = new List<Podcast>();
            List<Podcast> podLista = GetAll();

            foreach (var item in podLista)
            {
                if (item.PodcastsKategori.Equals(sokKategori))
                {
                    sokPodcastsForKategoriList.Add(item);
                }
            }
            return sokPodcastsForKategoriList;
        }

        public string HamtaNamn(int index)
        {
            return podLista[index].PodcastsNamn;
        }

        public string HamtaURL(int index)
        {
            return podLista[index].PodcastsUrl;
        }
    }
}
