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
        private string nedsatteevne;
        private string adresse;
        private string email;
        private string noter;

        // Alt dette her er properties kan ses på kendetegnet (get; set;)
        public string Navn { get { return navn; } set { navn = value; } }
        public int Cprnr { get { return cprnr; } set { cprnr = value; } }
        public int Tlfnr { get { return tlfnr; } set { tlfnr = value; } }
        public string Nedsatteevne { get { return nedsatteevne; } set { nedsatteevne = value; } }
        public string Adresse { get { return adresse; } set { adresse = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Noter { get { return noter; } set { noter = value; } }

        // kravene i parameteren skal opfyldes for at kunne oprette en patient kan ses nedenunder.
        public Patient(string Navn, int Cprnr, int Tlfnr, string Nedsatteevne, string Adresse, string Email, string Noter)
        {
            this.navn = Navn;
            this.cprnr = Cprnr;
            this.tlfnr = Tlfnr;
            this.nedsatteevne = Nedsatteevne;
            this.adresse = Adresse;
            this.email = Email;
            this.noter = Noter;
        }


        public Patient()
        {

        }


    }
}
