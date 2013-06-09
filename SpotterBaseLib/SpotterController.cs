using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Spotter.Cloud.Service.Interfaces;
using Spotter.Cloud.Service.Entities;

namespace Spotter.Cloud.Service
{
    public class SpotterController : ISpotterController
    {
        public List<TripDetails> GetAllTrips()
        {
            throw new NotImplementedException();
        }

        public int AddTrip(TripDetails trip)
        {
            throw new NotImplementedException();
        }

        public int AddTrip(int routeId, int vehicleId, int driverId)
        {
            throw new NotImplementedException();
        }

        public bool CancelTrip(int id)
        {
            throw new NotImplementedException();
        }

        public TripDetails GetRoute(int id)
        {
            throw new NotImplementedException();
        }

        public bool StartTrip(int id)
        {
            throw new NotImplementedException();
        }

        public List<TripDetails> GetAllActiveTrips()
        {
            throw new NotImplementedException();
        }
    }
}
