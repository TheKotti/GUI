using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; //for ObservableCollection
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
using JAMK.ICT;

namespace WPFDataBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //koska useampi metodi tulee käyttämään näitä muuttujia, määritellään luokan tasolla
        JAMK.ICT.HockeyLeague liiga;
        ObservableCollection<JAMK.ICT.HockeyTeam> joukkueet;
        int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            //tänne kootusti omien kontrollien alustukset
            List<string> leffat = new List<string>();
            leffat.Add("Halloween");
            leffat.Add("Nightmare oin Elm Street");
            leffat.Add("Jasw");
            leffat.Add("Star wArs");
            cmbMovies.ItemsSource = leffat;

            //haetaan sm-liigajoukkueet
            liiga = new JAMK.ICT.HockeyLeague();
            joukkueet = liiga.GetTeams();
            cmbTeams.ItemsSource = joukkueet;
        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            //määritellään StackPanelin DataContext
            //Demo1: DataContextina on olio
            //HockeyTeam tiimi = new HockeyTeam("KeuPa", "Keuruu");
            //spRight.DataContext = tiimi;

            //Demo2: Kytketään oliokokoelman ensimmäiseen olioon
            spRight.DataContext = joukkueet[counter];
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            counter--;
            btnBind_Click(sender, e);
        }
        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            btnBind_Click(sender, e);
        }
    }
}
