using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FysioterapiMVVM
{
    public class Viewmodel
    {
        //Instancefield
        private string patientnavn;
        private int patientcprnr;
        private int patienttlfnr;
        private string patientsygdom;
        private string patientadresse;
        private string patientemail;

        // Alt dette her er properties kan ses på kendetegnet (get; set;)
        //properties
        // get og set som bære => betyder nøjagtig det samme som return.
        public string PatientNavn { get => patientnavn; set => patientnavn = value; }
        public int PatientCprnr { get => patientcprnr; set => patientcprnr = value; }
        public int PatientTlfnr { get => patienttlfnr; set => patienttlfnr = value; }
        public string PatientSygdom { get => patientsygdom; set => patientsygdom = value; }
        public string PatientAdresse { get => patientadresse; set => patientadresse = value; }
        public string PatientEmail { get => patientemail; set => patientemail = value; }
        public Patient Patienter { get; set; }

        // Vores Observablecollection tager udgangspunkt i vores patienter
        public ObservableCollection<Patient1> Patientinfo { get; set; }
        public Viewmodel()
        {
            Patientinfo = new ObservableCollection<Patient1>();
            // testdata           
            Patientinfo.Add(new Patient("Søren", 1209101789, 31343638,
                "ryg gigt", "2860 Soeborg, Fredehuseborgvej 34", "AvForSoeren@yahoo.com"));
            Patientinfo.Add(new Patient("Jens Peter", 0907381715, 31313131,
                "mødestabil", "4700 Næstved, Brogade 83", "Jenspeter@blackhat.now"));
            Patienter = new Patient1();
        }
    }
}
