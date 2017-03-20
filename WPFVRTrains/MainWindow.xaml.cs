using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JAMK.IT;
using System.Threading;

namespace WPFVRTrains
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Train> trains = new List<Train>();
        string selectedStation = "";
        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }
        #region METHODS

        void InitializeMyStuff()
        {
            //omat asetukset kootaan tänne
            //täytetään combobox asemilla
            GetStations();
        }

        private void GetStations()
        {
            List<Station> stations = new List<Station>();
            stations.Add(new JAMK.IT.Station("JY", "Jyväskylä"));
            stations.Add(new JAMK.IT.Station("HKI", "Helsinki"));
            stations.Add(new JAMK.IT.Station("TPE", "Tampere"));
            //vois hakea APIn jsonista jos jaksaa
            //kiinnitetään stations kokoelma comboboxiin
            cmbStations.DisplayMemberPath = "Name"; //käyttäjä näkee
            cmbStations.SelectedValuePath = "Code"; //käytetään hakuun
            cmbStations.DataContext = stations;
        }

        private void GetTrainsAt()
        {
            try
            {
                //haetaan asemalta lähtevät junat
                string st = cmbStations.SelectedValue.ToString(); //hakee Coden
                trains = JAMK.IT.TrainsVM.GetTrainsAt(st);
                dgTrains.DataContext = trains;
                txbMessage.Text = string.Format("Löytyi {0} junaa", trains.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void GetTrainsAtAsync()
        {
            //huom eri threadissa ajettava metodi EI VOI käsitellä GUIta
            //mutta muuttujia voi
            trains = JAMK.IT.TrainsVM.GetTrainsAt(selectedStation);
            UpdateUI();
        }
        private void UpdateUI()
        {
            Action action = () =>
            {
                dgTrains.DataContext = trains;
                txbMessage.Text = string.Format("Löytyi {0} junaa", trains.Count);
            };
            Dispatcher.BeginInvoke(action);
        }

        #endregion

        private void btnGetTrains_Click(object sender, RoutedEventArgs e)
        {
            if (cmbStations.SelectedValue != null)
            {
                //V1: alkuperäinen
                //txbMessage.Text = "Haetaan junat...";
                //GetTrainsAt();

                //V2: async omassa threadissa
                selectedStation = cmbStations.SelectedValue.ToString();
                new Thread(GetTrainsAtAsync).Start();
                txbMessage.Text = "Haetaan junia...";
            }
        }
    }
}
