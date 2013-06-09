using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Transporter
{
    public class TransportViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<VehicleInfo> vehicles;
        public ObservableCollection<VehicleInfo> Vehicles
        {
            get
            {
                if (this.vehicles == null)
                {
                    this.vehicles = new ObservableCollection<VehicleInfo>();
                }

                return vehicles;
            }

            private set { vehicles = value; }
        }

        private ObservableCollection<LocationInfo> locations;
        public ObservableCollection<LocationInfo> Locations
        {
            get
            {
                if (this.locations == null)
                {
                    this.locations = new ObservableCollection<LocationInfo>();
                }

                return locations;
            }
            private set { locations = value; }
        }

        private ObservableCollection<DriverInfo> drivers;
        public ObservableCollection<DriverInfo> Drivers
        {
            get
            {
                if (this.drivers == null)
                {
                    this.drivers = new ObservableCollection<DriverInfo>();
                }

                return drivers;
            }
            private set { drivers = value; }
        }

        private DriverInfo selectedDriver;
        public DriverInfo SelectedDriver
        {
            get
            {
                return selectedDriver;
            }
            set
            {
                selectedDriver = value;
                this.OnPropertyChanged("SelectedDriver");
            }
        }

        private ObservableCollection<RouteInfo> routes;

        public ObservableCollection<RouteInfo> Routes
        {
            get
            {
                if (this.routes == null)
                {
                    this.routes = new ObservableCollection<RouteInfo>();
                }

                return routes;
            }
            private set { routes = value; }
        }

        private ObservableCollection<RouteCheckpointInfo> checkPoints;

        public ObservableCollection<RouteCheckpointInfo> CheckPoints
        {
            get
            {
                if (this.checkPoints == null)
                {
                    this.checkPoints = new ObservableCollection<RouteCheckpointInfo>();
                }

                return checkPoints;
            }
            private set { checkPoints = value; }
        }

        private VehicleInfo selectedVehicle;
        public VehicleInfo SelectedVehicle
        {
            get { return selectedVehicle; }
            set
            {
                selectedVehicle = value;
                this.OnPropertyChanged("SelectedVehicle");
            }
        }

        private LocationInfo selectedLocation;
        public LocationInfo SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                selectedLocation = value;
                this.OnPropertyChanged("SelectedLocation");
            }
        }

        private RouteInfo selectedRoute;
        public RouteInfo SelectedRoute
        {
            get { return selectedRoute; }
            set
            {
                selectedRoute = value;
                this.OnPropertyChanged("SelectedRoute");
            }
        }

        private RouteCheckpointInfo selectedCheckPoint;
        public RouteCheckpointInfo SelectedCheckPoint
        {
            get { return selectedCheckPoint; }
            set
            {
                selectedCheckPoint = value;
                this.OnPropertyChanged("SelectedCheckPoint");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string p)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        } 
    }
}
