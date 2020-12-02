using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioterapiMVVM
{
    public class Patient
    {
        // instancefield (her gemmer vi vores patients info)
        private string navn;
        private int cprnr;
        private int tlfnr;
        private string sygdom;
        private string adresse;
        private string email;
        private string noter;

        // Alt dette her er properties kan ses på kendetegnet (get; set;)
        public string Navn { get { return navn; } set { navn = value; } }
        public int Cprnr { get { return cprnr; } set { cprnr = value; } }
        public int Tlfnr { get { return tlfnr; } set { tlfnr = value; } }
        public string Sygdom { get { return sygdom; } set { sygdom = value; } }
        public string Adresse { get { return adresse; } set { adresse = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Noter { get { return noter; } set { noter = value; } }

        // kravene i parameteren skal opfyldes for at kunne oprette en patient kan ses nedenunder.
        public Patient(string Navn, int Cprnr, int Tlfnr, string Sygdom, string Adresse, string Email)
        {
            this.navn = Navn;
            this.cprnr = Cprnr;
            this.tlfnr = Tlfnr;
            this.sygdom = Sygdom;
            this.adresse = Adresse;
            this.email = Email;
        }

        public Patient(string Noter)
        {
            this.noter = Noter;
        }

        public Patient()
        {

        }


    }
}
