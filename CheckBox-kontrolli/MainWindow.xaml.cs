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

namespace CheckBox_kontrolli
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

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            List<string> ShoppingList = new List<string>();
            if ((bool)chkMilk.IsChecked)
            {
                ShoppingList.Add(chkMilk.Content.ToString());
            }
            if ((bool)chkButter.IsChecked)
            {
                ShoppingList.Add(chkButter.Content.ToString());
            }
            if ((bool)chkBeer.IsChecked)
            {
                ShoppingList.Add(chkBeer.Content.ToString());
            }
            if ((bool)chkChicken.IsChecked)
            {
                ShoppingList.Add(chkChicken.Content.ToString());
            }
            if ((bool)chkLemonade.IsChecked)
            {
                ShoppingList.Add(chkLemonade.Content.ToString());
            }

            foreach (var item in ShoppingList)
            {
                txtList.Text = txtList.Text + item + " ";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
    }
}
