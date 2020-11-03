using System;
using System.Collections.Generic;
using System.Text;


namespace BLL
{
    [Serializable]
    public class AnvandarException : Exception
    {
        public AnvandarException(string text)
        : base(text)
        { }

        public AnvandarException() { 
            
        }

        public virtual bool ValdFrekvens(string frekvens) //Virtual/Override
        {

            bool korrektFrekvens = Int32.TryParse(frekvens, out int frekvensArVald);
            if (!korrektFrekvens)
            {
                throw new AnvandarException("Ingen frekvens");

            }

            return korrektFrekvens;
        }
    }
}

