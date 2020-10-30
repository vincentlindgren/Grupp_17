using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.RepoMapp
{
    public interface IPodcastRep<T> : IRep<T> where T : Podcast
    {
        T SokPodcastEfterNamn(string sokNamn);
        string HamtaNamn(int index);
    }
}
