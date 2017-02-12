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

namespace HeaterUltimatum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        string thingy = "";
        Kiuas kiuas = new Kiuas();

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            thingy = thingy + (((Button)sender).Content).ToString();
            txtInput.Text = thingy;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            thingy = thingy.Substring(0, thingy.Length - 1);
            txtInput.Text = thingy;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((bool)radHeat.IsChecked)
                {
                    kiuas.Temperature = float.Parse(txtInput.Text);
                    txbTempValue.Text = kiuas.Temperature.ToString();
                }
                else
                {
                    kiuas.Humidity = float.Parse(txtInput.Text);
                    txbHumValue.Text = kiuas.Humidity.ToString();
                }
                txtInput.Text = "0";
                thingy = "";
                txbMessage.Text = kiuas.Error;

            }
            catch (Exception ex)
            {

                txbMessage.Text = ex.Message;
                txtInput.Text = "0";
                thingy = "";
            }
        }
    }

    public class Kiuas
    {
        public string Error = "";
        float kosteus;
        public float Humidity
        {
            get { return kosteus; }
            set
            {
                kosteus = value;
                if (kosteus < 0)
                {
                    kosteus = 0;
                    Error = "Too dry!";
                }
                else if (kosteus > 100)
                {
                    kosteus = 100;
                    Error = "Too moist!";
                }
            }
        }

        float lampo;
        public float Temperature
        {
            get { return lampo; }
            set
            {
                lampo = value;
                if (lampo < 0)
                {
                    lampo = 0;
                    Error = "Too cold!";
                }
                else if (lampo > 120)
                {
                    lampo = 120;
                    Error = "Too hot!";
                }
            }
        }
    }
}
