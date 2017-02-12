using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
            try
            {
                int numCount = 0, extraCount = 0, maxNum = 0;
                switch (cmbName.SelectedIndex)
                {
                    case 0:
                        {
                            numCount = 7;
                            maxNum = 40;
                            break;
                        }
                    case 1:
                        {
                            numCount = 6;
                            maxNum = 49;
                            break;
                        }
                    case 2:
                        {
                            numCount = 5;
                            extraCount = 2;
                            maxNum = 51;
                            break;
                        }
                    default:
                        break;
                }
                for (int i = 0; i < int.Parse(txtDraws.Text); i++)
                {
                    txbNumbers.Text = txbNumbers.Text + new Rivi(numCount, extraCount, maxNum).ToString() + Environment.NewLine;
                    Thread.Sleep(20);
                }
            }
            catch (Exception ex)
            {

                txbNumbers.Text = ex.Message;
            }
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txbNumbers.Text = "";
        }
    }

    public class Rivi
    {
        private Random rnd;
        private List<int> numbers;
        public List<int> NumList
        {
            get { return numbers; }
        }
        private List<int> extras;
        public List<int> ExtraList
        {
            get { return extras; }
        }

        public Rivi(int num, int extra, int max)
        {
            numbers = new List<int>();
            extras = new List<int>();
            rnd = new Random();

            for (int i = 0; i < num; i++)
            { 
                int temp = rnd.Next(1, max);
                bool check = numbers.Contains(temp);
                while (check == true)
                {
                    rnd = new Random();
                    temp = rnd.Next(1, max);
                    check = numbers.Contains(temp);
                }
                numbers.Add(temp);
            }
            for (int i = 0; i < extra; i++)
            {
                int temp = rnd.Next(1, max);
                bool check = extras.Contains(temp);
                while (check == true)
                {
                    rnd = new Random();
                    temp = rnd.Next(1, max);
                    check = extras.Contains(temp);
                }
                extras.Add(temp);
            }
            numbers.Sort();
            extras.Sort();
        }

        public override string ToString()
        {
            string tmp = "";
            for (int i = 0; i < numbers.Count; i++)
            {
                tmp = tmp + numbers[i] + " ";
            }
            for (int i = 0; i < extras.Count; i++)
            {
                tmp = tmp + extras[i] + " ";
            }
            return tmp;
        }
    }
}
