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

namespace Markkalaskuri
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double markanarvo = 5.95;
        private double muunnos;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (button.Content.ToString() == "-->")
            {
                button.Content = "<--";
            }
            else
            {
                button.Content = "-->";
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (button.Content.ToString() == "-->")
            {
                double.TryParse(textBox.Text, out muunnos);
                textBox1.Text = (markanarvo*muunnos).ToString("0.00");
            }
            else
            {
                double.TryParse(textBox1.Text, out muunnos);
                textBox.Text = (muunnos / markanarvo).ToString("0.00");
            }
        }
    }
}
