using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.RepoMapp
{
    public interface IRep<T> where T : class
    {
        void Skapa(T entity);
        void Spara(int index, T entity);
        void Delete(int index);
        void SparaAllaAndringar();
        List<T> GetAll();

    }
}
