using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.RepoMapp
{
    public class PodcastRep : IPodcastRep<Podcast>
    {
        DataSerializer dataSerializer;
        List<Podcast> podLista;

        public PodcastRep() {
            dataSerializer = new DataSerializer();
            podLista = new List<Podcast>();
            podLista = GetAll();
        }

        public void Skapa(Podcast podcast) {
            podLista.Add(podcast);
            SparaAllaAndringar();
        }

        public void Spara(int index, Podcast podcast) { 
            
        }

        public void Delete(int index) {

              podLista.RemoveAt(index);
            
        }

        public void SparaAllaAndringar() {
            dataSerializer.Serialize(podLista);
        }

        public List<Podcast> GetAll()
        {
            List<Podcast> podListReturneras = new List<Podcast>();

            try
            {
                podListReturneras = dataSerializer.Deserialize();
            }
                catch(Exception exc) 
                {
                    Console.WriteLine(exc);
                }
                return podListReturneras;
        }

        public Podcast SokPodcastEfterNamn(string sokNamn) {

            Podcast returneraPodcastOmHittad = new Podcast();
            List<Podcast> podLista = GetAll();

                foreach (var item in podLista)
                {
                    if (item.PodcastsNamn.Equals(sokNamn)) {
                        returneraPodcastOmHittad = item;
                    break;
                    }
                }
            return returneraPodcastOmHittad;
        }

        public List<Podcast> SokPodcastEfterKategori(string sokKategori) { //ska kallas på när man väljer kategori från cmb samt när man delete'ar alla podcasts i en kategori
            List<Podcast> sokPodcastsForKategoriList = new List<Podcast>();
            List<Podcast> podLista = GetAll();

            foreach (var item in podLista) {
                if (item.PodcastsKategori.Equals(sokKategori)) {
                    sokPodcastsForKategoriList.Add(item);
                } 
            }
            return sokPodcastsForKategoriList;
        }

        public string HamtaNamn(int index) {
            return podLista[index].PodcastsNamn;
        }
    }
}
