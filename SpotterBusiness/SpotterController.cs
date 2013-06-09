using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spotter.Cloud.Service.Entities;
using Spotter.Cloud.Service.Common;
using Spotter.Cloud.Service.Interfaces;

namespace SpotterBusiness
{
    public class SpotterController : IDriverSpotter, IVehicleSpotter, IRouteSpotter, ISpotterController, ISpotterCallback
    {

        public bool AddDriver(DriverDetails vehicle)
        {
            throw new NotImplementedException();
        }

        public List<DriverDetails> GetAllDrivers()
        {
            throw new NotImplementedException();
        }

        public DriverDetails GetDriver(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDriver(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddVehicle(VehicleDetails vehicle)
        {
            throw new NotImplementedException();
        }

        public List<VehicleDetails> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public VehicleDetails GetVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveVehicle(int id)
        {
            throw new NotImplementedException();
        }

        public int AddRoute(int sourceLocId, int destLocId, TimeSpan estimatedTime)
        {
            throw new NotImplementedException();
        }

        public int AddRoute(RouteDetails route)
        {
            throw new NotImplementedException();
        }

        public List<RouteDetails> GetAllRoutes()
        {
            throw new NotImplementedException();
        }

        public LocationDetails GetRoute(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRoute(int id)
        {
            throw new NotImplementedException();
        }

        public List<LocationDetails> RetrieveRouteCheckPoints(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRouteCheckPoints(int id, List<LocationDetails> checkPoints)
        {
            throw new NotImplementedException();
        }

        public int AddTrip(int routeId, int vehicleId, int driverId)
        {
            throw new NotImplementedException();
        }

        public int AddTrip(TripDetails trip)
        {
            throw new NotImplementedException();
        }

        public bool CancelTrip(int id)
        {
            throw new NotImplementedException();
        }

        public List<TripDetails> GetAllActiveTrips()
        {
            throw new NotImplementedException();
        }

        public List<TripDetails> GetAllTrips()
        {
            throw new NotImplementedException();
        }

        TripDetails ISpotterController.GetRoute(int id)
        {
            throw new NotImplementedException();
        }

        public bool StartTrip(int id)
        {
            throw new NotImplementedException();
        }

        public void NotifyTripStateChange(TripDetails trip)
        {
            throw new NotImplementedException();
        }

        public void NotifyVehicleStateChange(VehicleDetails vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
