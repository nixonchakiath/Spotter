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
using System.Windows.Shapes;
using GMapTestApplication;

namespace Transporter
{
    /// <summary>
    /// Interaction logic for AddLocation.xaml
    /// </summary>
    public partial class AddLocation : Window
    {
        public AddLocation()
        {
            InitializeComponent();
            this.DataContext = new LocationInfo();
        }

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

        private void ShowMap_Click(object sender, RoutedEventArgs e)
        {
            MapControl myMapDialog = new MapControl(true);
            Window mywindow = new Window();
            mywindow.Width = mywindow.Height = 800;
            mywindow.Content = myMapDialog;
            mywindow.WindowStyle = System.Windows.WindowStyle.ToolWindow;
            mywindow.ShowDialog();
            LocationInfo locationInfo = (this.DataContext as LocationInfo);
            if (locationInfo != null)
            {
                locationInfo.Latitude = myMapDialog.Latitude;
                locationInfo.Longitude = myMapDialog.Longitude;
            }
            
        }
    }
}
