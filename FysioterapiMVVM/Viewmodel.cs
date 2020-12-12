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
        private string patientNoter;
        private int vægt;
        private int maskineID;
        private int dato;
        private int tid;
        private int indstillingID;
        private int indstillingtal;


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
        public string PatientNoter { get => patientNoter; set => patientNoter = value; }
        public int Vægt { get => vægt; set => vægt = value; }
        public int MaskineID { get => maskineID; set => maskineID = value; }
        public int Dato { get => dato; set => dato = value; }
        public int Tid { get => tid; set => tid = value; }
        public int IndstillingID { get => indstillingID; set => indstillingID = value; }
        public int IndstillingNavn { get => indstillingtal; set => indstillingtal = value; }

        public Patient Patienter { get; set; }
        public Medarbejde medarbejde { get; set; }
        public Træning Træning { get; set; }
        public Maskine Maskine { get; set; }
        public Indstilling Indstilling { get; set; }

        public RelayCommand Tilfojepatient { get; set; }
        public RelayCommand SletValgtPatient { get; set; }
        public RelayCommand TilfojeMedarbejder { get; set; }
        public RelayCommand SletValgtMedarbejder { get; set; }
        public RelayCommand aendreMedarbejde { get; set; }
        public RelayCommand aendrePatient { get; set; }
        public RelayCommand TilfojTræning { get; set; }
        public RelayCommand SletValgttræning { get; set; }

        // Vores Observablecollection tager udgangspunkt i vores patienter
        public ObservableCollection<Patient> Patientinfo { get; set; }
        public ObservableCollection<Medarbejde> Medarbejdeinfo { get; set; }
        public ObservableCollection<Træning> Træningsinfo { get; set; }

        public Viewmodel()
        {
            Patientinfo = new ObservableCollection<Patient>();
            Medarbejdeinfo = new ObservableCollection<Medarbejde>();
            Træningsinfo = new ObservableCollection<Træning>();

            // testdata           
            Patientinfo.Add(new Patient("Søren", 1209101789, 31343638,
                "ryg gigt", "2860 Soeborg, Fredehuseborgvej 34", "AvForSoeren@yahoo.com", "Er doven, når han er hos os"));
            Patientinfo.Add(new Patient("Jens Peter", 0907381715, 31313131,
                "mødestabil", "4700 Næstved, Brogade 83", "Jenspeter@blackhat.now", ""));
            Medarbejdeinfo.Add(new Medarbejde("Caroline", 0022334455, 45112266, "carolinesvej 10", "caroline@caroline.com"));
            Medarbejdeinfo.Add(new Medarbejde("Emma", 1122558844, 77889988, "Linde Alle 388", "emma@gg.fk"));

            Patienter = new Patient();
            medarbejde = new Medarbejde();
            Træning = new Træning();
            Maskine = new Maskine();
            Indstilling = new Indstilling();

            Tilfojepatient = new RelayCommand(Opretpatient);
            SletValgtPatient = new RelayCommand(SletPatient);
            TilfojeMedarbejder = new RelayCommand(OpretMedarbejde);
            SletValgtMedarbejder = new RelayCommand(SletMedarbejder);
            aendreMedarbejde = new RelayCommand(ÆndreMedarbejder);
            aendrePatient = new RelayCommand(ÆndrePatient);
            TilfojTræning = new RelayCommand(TilføjTræning);
            SletValgttræning = new RelayCommand(SletTræning);
        }


        /// <summary>
        /// Metorde tilføjer en patient, som brugen har skabt til databasen, samt til vores observablecollection
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
        /// Metorden sletter patient fra vores observablecollection og fra databasen
        /// </summary>
        public void SletPatient()
        {
            Patientinfo.Remove(Patienter);

            // Tjekker om patient kan slettes
            SletValgtPatient.RaiseCanExecuteChanged();

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

                    // sletter den valgt patient fra databasen
                    var PatientResponse = client.DeleteAsync($"api/Patientstabels/{Cprnr}").Result;

                    //Tjekker svar fra databasen, hvis det går galt kaster den en exception
                    PatientResponse.EnsureSuccessStatusCode();

                    //Får patient som en ICollection
                    var patient1 = PatientResponse.Content.ReadAsAsync<Patient>().Result;

                    // Tjekker om patient kan oprettes
                    SletValgtPatient.RaiseCanExecuteChanged();
                }
                catch
                {

                }
            }
        }

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
            Medarbejdeinfo.Remove(medarbejde);

            SletValgtMedarbejder.RaiseCanExecuteChanged();

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

                    // sletter den valgt patient fra databasen
                    var MedarbejdeResponse
                        = client.DeleteAsync($"api/Medarbejdetabels/{Cprnr}").Result;

                    //Tjekker svar fra databasen, hvis det går galt kaster den en exception
                    MedarbejdeResponse.EnsureSuccessStatusCode();

                    //Får patient som en ICollection
                    var patient1 = MedarbejdeResponse.Content.ReadAsAsync<Medarbejde>().Result;

                    // Tjekker om patient kan oprettes
                    SletValgtMedarbejder.RaiseCanExecuteChanged();
                }
                catch
                {

                }
            }
        }

        public void ÆndreMedarbejder()
        {
            
            Medarbejde medarbejder = new Medarbejde();
            Medarbejdeinfo.Remove(medarbejde);
            Medarbejdeinfo.Add(medarbejder);

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

                    // ændre den valgt medarbejde fra databasen
                    var MedarbejdeResponse
                        = client.PutAsJsonAsync<Medarbejde>($"api/Medarbejdetabels/{Cprnr}", medarbejde).Result;

                    //Tjekker svar fra databasen, hvis det går galt kaster den en exception
                    MedarbejdeResponse.EnsureSuccessStatusCode();

                    //Får medarbejde som en ICollection
                    var patient1 = MedarbejdeResponse.Content.ReadAsAsync<Medarbejde>().Result;

                    // Tjekker om medarbejde kan oprettes
                    aendreMedarbejde.RaiseCanExecuteChanged();
                }
                catch
                {

                }
            }
        }

        public void ÆndrePatient()
        {
            Patient patient = new Patient(Navn, Cprnr, Tlfnr, PatientNedsatteevne, Adresse, Email, PatientNoter);
            Patientinfo.Remove(Patienter);
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

                    // ændre den valgt medarbejde fra databasen
                    var MedarbejdeResponse
                        = client.PutAsJsonAsync<Patient>($"api/Patientstabels/{Cprnr}",patient ).Result;

                    //Tjekker svar fra databasen, hvis det går galt kaster den en exception
                    MedarbejdeResponse.EnsureSuccessStatusCode();

                    //Får medarbejde som en ICollection
                    var patient1 = MedarbejdeResponse.Content.ReadAsAsync<Patient>().Result;

                    // Tjekker om medarbejde kan oprettes
                    aendrePatient.RaiseCanExecuteChanged();
                }
                catch
                {

                }
            }
        }

        public void TilføjTræning()
        {
            Træning træning = new Træning(Dato, Tid, Vægt, MaskineID,IndstillingID) ;

            Træningsinfo.Add(træning);

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

                    // Den får alle træning fra databasen
                    var TræningResponse = client.PostAsJsonAsync<Træning>("api/træningstabels", træning).Result;

                    //Tjekker svar fra databasen, hvis det går galt kaster den en exception
                    TræningResponse.EnsureSuccessStatusCode();

                    //Får patient som en ICollection
                    var Træning1 = TræningResponse.Content.ReadAsAsync<Træning>().Result;

                    // Tjekker om patient kan oprettes
                    TilfojTræning.RaiseCanExecuteChanged();
                }
                catch
                {

                }
            }
        }

        public void SletTræning()
        {
            Træningsinfo.Remove(Træning);

            // Tjekker om Træning kan slettes
            SletValgttræning.RaiseCanExecuteChanged();

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

                    // sletter den valgt træning fra databasen
                    var TræningResponse = client.DeleteAsync($"api/Træningstabels/{Dato}").Result;

                    //Tjekker svar fra databasen, hvis det går galt kaster den en exception
                    TræningResponse.EnsureSuccessStatusCode();

                    //Får patient som en ICollection
                    var træning = TræningResponse.Content.ReadAsAsync<Træning>().Result;

                    // Tjekker om patient kan oprettes
                    SletValgtPatient.RaiseCanExecuteChanged();
                }
                catch
                {

                }
            }
        }

    }
}