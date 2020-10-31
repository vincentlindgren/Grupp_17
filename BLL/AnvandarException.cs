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
    }
}
