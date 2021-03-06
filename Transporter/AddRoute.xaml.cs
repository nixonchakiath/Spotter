﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Transporter
{
    /// <summary>
    /// Interaction logic for AddRoute.xaml
    /// </summary>
    public partial class AddRoute : Window
    {
        public AddRoute()
        {
            InitializeComponent();
            this.RouteInfo = new RouteInfo();
            this.DataContext = this;
        }


        public ObservableCollection<LocationInfo> Locations { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        public RouteInfo RouteInfo { get; set; }
    }
}
