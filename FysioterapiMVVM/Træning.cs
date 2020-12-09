using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioterapiMVVM
{
 public class Træning
    {
        private int dato;
        private int tid;
        private int vægt;
        private int maskineID;
        private int indstillingid;

        public int Dato { get { return dato; } set { dato = value; } }
        public int Tid { get { return tid; } set { tid = value; } }
        public int Vægt { get { return vægt; } set { vægt = value; } }
        public int MaskineID { get { return maskineID; } set { maskineID = value; } }
        public int IndstillingID { get { return indstillingid; } set { indstillingid = value; } }

        public Træning(int Dato, int Tid, int Vægt, int MaskineID, int IndstillingID)
        {
            this.dato = Dato;
            this.tid = Tid;
            this.vægt = Vægt;
            this.maskineID = MaskineID;
            this.indstillingid = IndstillingID;
        }

        public Træning()
        {

        }
    }
}
