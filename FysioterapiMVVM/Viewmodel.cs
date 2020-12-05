using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FysioterapiMVVM
{
    public class Viewmodel
    {
        //Instancefield
        private string navn;
        private int cprnr;
        private int tlfnr;
        private string patientnedsatteevne;
        private string adresse;
        private string email;
        private string PatientNoter;


        /// <summary>
        /// Det sammen URL blive brugt under hele projektet
        /// </summary>
        const string URL = "http://localhost:60928";
        private const string RequestUri = "api/Patientstabels";
        
        // Alt dette her er properties kan ses på kendetegnet (get; set;)
        //properties
        // get og set som bære => betyder nøjagtig det samme som return.
        public string Navn { get => navn; set => navn = value; }
        public int Cprnr { get => cprnr; set => cprnr = value; }
        public int Tlfnr { get => tlfnr; set => tlfnr = value; }
        public string PatientNedsatteevne { get => patientnedsatteevne; set => patientnedsatteevne = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Email { get => email; set => email = value; }
        public string PatietNoter { get => PatientNoter; set => PatientNoter = value; }

        public Patient Patienter { get; set; }
        public Medarbejde medarbejde { get; set; }

        public RelayCommand Tilfojepatient { get; set; }
        public RelayCommand SletValgtPatient {get; set;}
        public RelayCommand TilfojeMedarbejder { get; set;}
        public RelayCommand SletValgtMedarbejder { get; set; }

        // Vores Observablecollection tager udgangspunkt i vores patienter
        public ObservableCollection<Patient> Patientinfo { get; set; }
        public ObservableCollection<Medarbejde> Medarbejdeinfo { get; set; }
        
        public Viewmodel()
        {
            Patientinfo = new ObservableCollection<Patient>();
            Medarbejdeinfo = new ObservableCollection<Medarbejde>();

            // testdata           
            Patientinfo.Add(new Patient("Søren", 1209101789, 31343638,
                "ryg gigt", "2860 Soeborg, Fredehuseborgvej 34", "AvForSoeren@yahoo.com","Er doven, når han er hos os"));
            Patientinfo.Add(new Patient("Jens Peter", 0907381715, 31313131,
                "mødestabil", "4700 Næstved, Brogade 83", "Jenspeter@blackhat.now",""));
            Medarbejdeinfo.Add(new Medarbejde("Caroline",0022334455,45112266,"carolinesvej 10","caroline@caroline.com"));
            Medarbejdeinfo.Add(new Medarbejde("Emma", 1122558844, 77889988, "Linde Alle 388", "emma@gg.fk"));
            
            Patienter = new Patient();
            medarbejde = new Medarbejde();

            Tilfojepatient = new RelayCommand(Opretpatient);
            SletValgtPatient = new RelayCommand(SletPatient);
            TilfojeMedarbejder = new RelayCommand(OpretMedarbejde);
            SletValgtMedarbejder = new RelayCommand(SletMedarbejder);
        }


        /// <summary>
        /// Metorde tilføjer en patient, som brugen har skabt til databasen samt til vores observablecollection
        /// </summary>

        public void Opretpatient()
        {
            Patient patient = new Patient(Navn, Cprnr, Tlfnr, PatientNedsatteevne, Adresse, Email, PatientNoter);
            Patientinfo.Add(patient);


            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {

                //Initialiser klienten
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Clear();

                //Laver en forespøgelse om at få en JSON format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {

                    // Den får alle patienter fra databasen
                    var PatientResponse = client.PostAsJsonAsync<Patient>(RequestUri, patient).Result;

                    //Tjekker svar fra databasen, hvis det går galt kaster den en exception
                    PatientResponse.EnsureSuccessStatusCode();

                    //Får patient som en ICollection
                    var patient1 = PatientResponse.Content.ReadAsAsync<Patient>().Result;

                    // Tjekker om patient kan oprettes
                    Tilfojepatient.RaiseCanExecuteChanged();
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Metorden sletter patient fra vores observablecollection
        /// </summary>
        public void SletPatient()
        {
            Patientinfo.Remove(Patienter);

            // Tjekker om patient kan slettes
            SletValgtPatient.RaiseCanExecuteChanged();
        }
        
        //
        public void OpretMedarbejde()
        {
            Medarbejde medarbejde = new Medarbejde(Navn, Cprnr, Tlfnr, Adresse, Email);
            Medarbejdeinfo.Add(medarbejde);


            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {

                //Initialiser klienten
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Clear();

                //Laver en forespøgelse om at få en JSON format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {

                    // Den får alle medarbejde fra databasen
                    var MedarbejderResponse = client.PostAsJsonAsync<Medarbejde>("api/Medarbejdetabels", medarbejde).Result;

                    //Tjekker svar fra databasen, hvis det går galt kaster den en exception
                    MedarbejderResponse.EnsureSuccessStatusCode();

                    //Får patient som en ICollection
                    var patient1 = MedarbejderResponse.Content.ReadAsAsync<Medarbejde>().Result;

                    // Tjekker om medarbejde kan oprettes
                    TilfojeMedarbejder.RaiseCanExecuteChanged();
                }
                catch
                {

                }
            }
        }

        public void SletMedarbejder()
        {
            Medarbejdeinfo.Add(medarbejde);

            SletValgtMedarbejder.RaiseCanExecuteChanged();
        }
    }
}
