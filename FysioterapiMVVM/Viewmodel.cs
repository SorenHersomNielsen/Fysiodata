using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        const string URL = "http://localhost:60928/";


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

        public RelayCommand Tilføjepatient { get; set; }
        public RelayCommand SletValgtPatient {get; set;}


        // Vores Observablecollection tager udgangspunkt i vores patienter
        public ObservableCollection<Patient> Patientinfo { get; set; }
        public Viewmodel()
        {
            Patientinfo = new ObservableCollection<Patient>();
            // testdata           
            Patientinfo.Add(new Patient("Søren", 1209101789, 31343638,
                "ryg gigt", "2860 Soeborg, Fredehuseborgvej 34", "AvForSoeren@yahoo.com"));
            Patientinfo.Add(new Patient("Jens Peter", 0907381715, 31313131,
                "mødestabil", "4700 Næstved, Brogade 83", "Jenspeter@blackhat.now"));
            Patienter = new Patient();

            Tilføjepatient = new RelayCommand(Opretpatient); 
        }


        /// <summary>
        /// Metorde tilføjer en patient, som brugen har skabt til databasen samt til vores observablecollection
        /// </summary>

        public void Opretpatient()
        {
            Patient patient = new Patient(PatientNavn, PatientCprnr, PatientTlfnr, PatientSygdom, PatientAdresse, PatientEmail);
            Patientinfo.Add(patient);


            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                //Initialize client
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Clear();

                //Request JSON format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {

                    //Get all the flower orders from the database
                    var PatientResponse = client.PostAsJsonAsync<Patient>("api/Patientstabels", patient).Result;

                    //Check response -> throw exception if NOT successful
                    PatientResponse.EnsureSuccessStatusCode();

                    //Get the hotels as a ICollection
                    var flowerOrder = PatientResponse.Content.ReadAsAsync<Patient>().Result;

                    Tilføjepatient.RaiseCanExecuteChanged();
                }
                catch
                {

                }


            }


        }
    }
}
