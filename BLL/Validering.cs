using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLL
{
    public class Validering
    {
        public Validering()
        {


        }

        public bool ValdFrekvens(string frekvens)
        {
            bool korrektFrekvens = Int32.TryParse(frekvens, out int frekvensArVald);
            if (!korrektFrekvens)
            {
                throw new AnvandarException("Ingen frekvens är vald");

            }
            return korrektFrekvens;
        }

        public bool KorrektURLAdress(string urlAdress)
        {
            Uri uriResult;
            bool korrektURL = Uri.TryCreate(urlAdress, UriKind.Absolute, out uriResult)
                           && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!korrektURL)
            {
                throw new AnvandarException("URLadressen är inte korrekt");
            }
            return korrektURL;
        }


        public bool ValdKategori(string kategorinamn)
        {
            bool korrektKategori = Int32.TryParse(kategorinamn, out int valdkategori);
            if (!korrektKategori)
            {
                throw new AnvandarException("Ingen kategori är vald");

            }
            return korrektKategori;
        }

        //public bool ValdKategori(string kategorinamn)
        //{
        //    bool isNull = false;
        //    string inKategori = kategorinamn;

        //    if (string.IsNullOrEmpty(inKategori)) {
        //        isNull = true;
        //        throw new AnvandarException("Ingen kategori är vald");
        //    }
        //    return isNull;
        //}

    }
}
