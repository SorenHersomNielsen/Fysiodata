using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioterapiMVVM
{
    public class Indstilling
    {
        private string indstillingNavn;
        private int indstillingTal;

        public string IndstillingNavn { get { return indstillingNavn; } set { indstillingNavn = value; } }
        public int IndstillingTal { get { return indstillingTal; } set { indstillingTal = value; } }

        public Indstilling(string IndstillingNavn, int IndstillingTal)
        {
            this.indstillingNavn = IndstillingNavn;
            this.indstillingTal = IndstillingTal;
        }

        public Indstilling()
        {

        }
    }
}
