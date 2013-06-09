using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Spotter.Cloud.Service.Entities;
namespace Spotter.Cloud.Service.Interfaces
{
    [ServiceContract(CallbackContract = typeof(ISpotterCallback))]
    public interface ISpotterController
    {
        [OperationContract]
        List<TripDetails> GetAllTrips();

        [OperationContract]
        int AddTrip(TripDetails trip);

        [OperationContract]
        int AddTrip(int routeId, int vehicleId, int driverId);

        [OperationContract]
        bool CancelTrip(int id);

        [OperationContract]
        TripDetails GetRoute(int id);

        [OperationContract]
        bool StartTrip(int id);

        [OperationContract]
        List<TripDetails> GetAllActiveTrips();
    }
}
