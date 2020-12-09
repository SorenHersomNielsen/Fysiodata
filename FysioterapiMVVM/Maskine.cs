using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioterapiMVVM
{
    public class Maskine
    {
        private string maskineNavn;

        public string MaskineNavn { get { return maskineNavn; } set { maskineNavn = value; } }

        public Maskine(string MaskineNavn)
        {
            this.maskineNavn = MaskineNavn;
        }

        public Maskine()
        {

        }
    }
}
