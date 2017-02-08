using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Lottokone
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

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            List <int> rivi = new List<int>();
            string tmep = "";
            for (int i = 0; i < int.Parse(txtDraws.Text); i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    rivi.Add(rnd.Next(39));
                }
                for (int j = 0; j < 8; j++)
                {
                    Debug.Write(rivi[j] + " ");
                }
                Debug.Write(Environment.NewLine);
            }
        }
    }
}
