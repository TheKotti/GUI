﻿using System;
using System.Collections.Generic;
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

namespace WPFThreadDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }
        #region METHODS

        void InitializeMyStuff()
        {
            btnFire.IsEnabled = false;
        }

        void UpdateMessage(string msg)
        {
            txtMessage.Text = msg;
        }

        void DoWork()
        {
            Thread.Sleep(5000);
            UpdateMessageAsync("Loooong work done");
        }

        void UpdateMessageAsync(string msg)
        {
            Action action = () =>
            {
                txtMessage.Text = msg;
                btnFire.IsEnabled = false;
            };
            //suorittaa annetun delegaatin asyncronisesti siinä threadissa mishin Dispatcher liittyy
            Dispatcher.BeginInvoke(action);
        }

        #endregion

        #region EVENTHANDLERS
        
        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            count++;
            UpdateMessage("Fire #" + count.ToString());
        }
       
        private void btnWork_Click(object sender, RoutedEventArgs e)
        {
            //käynnistetään pitkäkestoinen tapahtuma
            btnFire.IsEnabled = true;
            //V1: normaalisti tämä toimisi mutta nyt metodin pitkän keston takia ei kerkiä päivittyä
            //UpdateMessage("Long work started");
            //DoWork();
            //V2: Säikeeseen
            UpdateMessage("Long work started");
            new Thread(DoWork).Start();
        }
        #endregion
    }
}
