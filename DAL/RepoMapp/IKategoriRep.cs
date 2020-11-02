using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.RepoMapp
{
    public interface IKategoriRep<T> : IRep<T> where T : PodKategori
    {

        T SokKategoriEfterNamn(string sokNamn);
        string HamtaNamn(int index);
    }
}
