using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Spotter.Cloud.Service.Entities;
namespace Spotter.Cloud.Service.Interfaces
{
    /// <summary>
    /// Callback Interface
    /// </summary>
    public interface ISpotterCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyVehicleStateChange(VehicleDetails vehicle);
        
        [OperationContract(IsOneWay = true)]
        void NotifyTripStateChange(TripDetails trip);
    }
}
