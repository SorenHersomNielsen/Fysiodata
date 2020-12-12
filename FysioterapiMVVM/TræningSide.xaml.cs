using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FysioterapiMVVM
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TræningSide : Page
    {
        public Viewmodel Viewmodel { get; set; }
        public TræningSide()
        {
            this.InitializeComponent();
            Viewmodel = new Viewmodel();
        }
        private void Forside(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Vispatientside(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Patientside));
        }

        private void VisMedarbejdeSide(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Medarbejderside));
        }
    }
}
