using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace Transporter
{
    /// <summary>
    /// Interaction logic for TansportMangement.xaml
    /// </summary>
    public partial class TansportMangement : UserControl
    {
        private TransportViewModel TransportViewModel { get; set; }
        public TansportMangement()
        {
            InitializeComponent();

            try
            {
                StreamReader fs = new StreamReader("Transport.xml");
                XmlSerializer xmlSer = new XmlSerializer(typeof(TransportViewModel));
                this.TransportViewModel = (TransportViewModel)xmlSer.Deserialize(fs);
                fs.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }

            if (null == this.TransportViewModel)
            {
                this.TransportViewModel = new TransportViewModel();
            }

            this.DataContext = this.TransportViewModel;
            Application.Current.Exit += new ExitEventHandler(Current_Exit);

        }

        void Current_Exit(object sender, ExitEventArgs e)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(TransportViewModel));
            FileStream fs = new FileStream("Transport.xml", FileMode.Create);
            xmlSer.Serialize(fs, this.TransportViewModel);
            fs.Close();
        }

        private void AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            AddVehicle window = new AddVehicle();
            if (window.ShowDialog().Value)
            {
                this.TransportViewModel.Vehicles.Add(window.DataContext as VehicleInfo);
            }
        }

        private void RemoveVehicle_Click(object sender, RoutedEventArgs e)
        {
            if (this.TransportViewModel.SelectedVehicle is VehicleInfo)
            {
                this.TransportViewModel.Vehicles.Remove(this.TransportViewModel.SelectedVehicle as VehicleInfo);
            }
        }

        private void AddLocation_Click(object sender, RoutedEventArgs e)
        {
            AddLocation window = new AddLocation();
            if (window.ShowDialog().Value)
            {
                this.TransportViewModel.Locations.Add(window.DataContext as LocationInfo);
            }
        }

        private void RemoveLocation_Click(object sender, RoutedEventArgs e)
        {
            if (this.TransportViewModel.SelectedLocation is LocationInfo)
            {
                this.TransportViewModel.Locations.Remove(this.TransportViewModel.SelectedLocation as LocationInfo);
            }
        }

        private void AddRoute_Click(object sender, RoutedEventArgs e)
        {
            AddRoute window = new AddRoute();
            window.Locations = this.TransportViewModel.Locations;
            if (window.ShowDialog().Value)
            {
                this.TransportViewModel.Routes.Add(window.RouteInfo as RouteInfo);
            }
        }

        private void RemoveRoute_Click(object sender, RoutedEventArgs e)
        {
            if (this.TransportViewModel.SelectedRoute is RouteInfo)
            {
                this.TransportViewModel.Routes.Remove(this.TransportViewModel.SelectedRoute as RouteInfo);
            }
        }

        private void AddCheckPoint_Click(object sender, RoutedEventArgs e)
        {
            AddCheckPoints window = new AddCheckPoints();
            if (window.ShowDialog().Value)
            {
                this.TransportViewModel.CheckPoints.Add(window.DataContext as RouteCheckpointInfo);
            }
        }

        private void RemoveCheckPoint_Click(object sender, RoutedEventArgs e)
        {
            if (this.TransportViewModel.SelectedCheckPoint is RouteCheckpointInfo)
            {
                this.TransportViewModel.CheckPoints.Remove(this.TransportViewModel.SelectedCheckPoint as RouteCheckpointInfo);
            }
        }
        
        /// <summary>
        /// Add a new driver
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            AddDriver window = new AddDriver();
            if (window.ShowDialog().Value)
            {
                this.TransportViewModel.Drivers.Add(window.DataContext as DriverInfo);
            }
        }

        /// <summary>
        /// Remove the selected driver
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveDriver_Click(object sender, RoutedEventArgs e)
        {
            if (this.TransportViewModel.SelectedDriver is DriverInfo)
            {
                this.TransportViewModel.Drivers.Remove(this.TransportViewModel.SelectedDriver as DriverInfo);
            }
        }

    }
}
