﻿using System;
using System.Collections.Generic;
using System.Linq;

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
            
        }

        public void Delete(int index)
        {
            
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
        
        public void AndraPodcastKategori(string podcastNamn, string newKategori) {
            podLista = GetAll();

            foreach (var item in podLista)
            {
                if (item.PodcastsNamn.Equals(podcastNamn)) {
                    item.PodcastsKategori = "";
                    item.PodcastsKategori = newKategori;
                    Console.WriteLine(item.PodcastsKategori);
                    SparaAllaAndringar();
                }
            }
        }

        public void AndraPodcastFrekvens(string podcastNamn, string newFrekvens)
        {
            podLista = GetAll();

            foreach (var item in podLista)
            {
                if (item.PodcastsNamn.Equals(podcastNamn))
                {
                    item.Frekvens = "";
                    item.Frekvens = newFrekvens;
                    Console.WriteLine(item.PodcastsKategori);
                    SparaAllaAndringar();
                }
            }
        }

        public void AndraPodcastNamn(string oldPodcastNamn, string newPodcastNamn)
        {
            podLista = GetAll();

            foreach (var item in podLista)
            {
                if (item.PodcastsNamn.Equals(oldPodcastNamn))
                {
                    item.PodcastsNamn = "";
                    item.PodcastsNamn = newPodcastNamn;
                    Console.WriteLine(item.PodcastsNamn);
                    SparaAllaAndringar();
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
            podLista = GetAll();
            Podcast podItem = new Podcast(); 
            foreach (var item in podLista)
            {
                if (item.PodcastsNamn.Equals(namn))
                {
                    podItem = item;
                    break;
                }
            }
            int antal = podItem.AntalAvsnitt;
            return antal;
        }

        public void DeletePodcastEfterKategori(string sokKategori)
        { 
            for (int index = GetAll().Count - 1; index >= 0; index--) {
                if (GetAll()[index].PodcastsKategori.Equals(sokKategori)) {
                    Delete2(index);
                }
            }
        }

       

        public string HamtaNamn(int index)
        {
            return podLista[index].PodcastsNamn;
        }

    }
}
