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

namespace Transporter
{
    /// <summary>
    /// Interaction logic for Tracker.xaml
    /// </summary>
    public partial class Tracker : UserControl
    {
        private List<Trip> tripDetails;
        public List<Trip> TripDetails
        {
            get { return tripDetails; }
            set { tripDetails = value; }
        }
        public Tracker()
        {
            InitializeComponent();
            this.tripDetails = new List<Trip>()
            {
                new Trip(){Name="Tvm-Kzktm", Status="Available", Time=DateTime.Now},
                new Trip(){Name="Skm-Kzktm", Status="Assigned", Time=DateTime.Now},
                new Trip(){Name="Kdmp-Tvm", Status="Available", Time=DateTime.Now},
                new Trip(){Name="Skm-Ptm", Status="Available", Time=DateTime.Now},
                new Trip(){Name="Mdc-Kzktm", Status="Live", Time=DateTime.Now},
                new Trip(){Name="Skm-Kzktm", Status="Live", Time=DateTime.Now},
                new Trip(){Name="Skm-Kzktm", Status="Lost", Time=DateTime.Now},
                new Trip(){Name="Skm-Kzktm", Status="Breakdown", Time=DateTime.Now}
            };

            this.DataContext = this;
        }
    }
}
