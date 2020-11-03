using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BLL
{
    public class Validering : AnvandarException //Virtual/Override
    {
        public Validering()
        {


        }

        public override bool ValdFrekvens(string frekvens) //Virtual/Override
        {
            bool korrektFrekvens = Int32.TryParse(frekvens, out int frekvensArVald);
            if (!korrektFrekvens)
            {
                throw new AnvandarException("Ingen frekvens är vald");
            }
            else
            {
                Console.WriteLine("LYCKADES");
            }
            return korrektFrekvens;
        }

        public bool KorrektURLAdress(string urlAdress)
        {
            Uri uriResultat;
            bool korrektURL = Uri.TryCreate(urlAdress, UriKind.Absolute, out uriResultat)
                           && (uriResultat.Scheme == Uri.UriSchemeHttp || uriResultat.Scheme == Uri.UriSchemeHttps);
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
    }
}
