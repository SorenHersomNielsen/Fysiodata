using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioterapiMVVM
{
    public class Medarbejde
    {
        // instancefield (her gemmer vi vores medarbejders info)
        private string navn;
        private int cprnr;
        private int tlfnr;
        private string adresse;
        private string email;

        // Alt dette her er properties kan ses på kendetegnet (get; set;)
        public string Navn { get { return navn; } set { navn = value; } }
        public int Cprnr { get { return cprnr; } set { cprnr = value; } }
        public int Tlfnr { get { return tlfnr; } set { tlfnr = value; } }
        public string Adresse { get { return adresse; } set { adresse = value; } }
        public string Email { get { return email; } set { email = value; } }

        // kravene i parameteren skal opfyldes for at kunne oprette en medarbjde kan ses nedenunder.
        public Medarbejde(string Navn, int Cprnr, int Tlfnr, string Adresse, string Email)
        {
            this.navn = Navn;
            this.cprnr = Cprnr;
            this.tlfnr = Tlfnr;
            this.adresse = Adresse;
            this.email = Email;
        }
        public Medarbejde()
        {

        }
    }
}
