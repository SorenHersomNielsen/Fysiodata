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

        public int Dato { get { return dato; } set { dato = value; } }
        public int Tid { get { return tid; } set { tid = value; } }
        public int Vægt { get { return vægt; } set { vægt = value; } }

        public Træning(int Dato, int Tid, int Vægt)
        {
            this.dato = Dato;
            this.tid = Tid;
            this.vægt = Vægt;
        }
    }
}
