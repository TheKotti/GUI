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

namespace Ikkunalaskuri
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
        private double leveys, korkeus, karmi;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(textBox.Text, out korkeus);
            double.TryParse(textBox_Copy.Text, out leveys);
            double.TryParse(textBox_Copy1.Text, out karmi);

            textBlock_Copy5.Text = (((korkeus + karmi) * (leveys + karmi))/100).ToString("0.00") + " cm^2";
            textBlock_Copy6.Text = ((korkeus * leveys)/100).ToString("0.00") + " cm^2";
            textBlock_Copy7.Text = ((korkeus + leveys) * 2 + karmi * 4).ToString("0.00") + " mm";
        }
    }
}
