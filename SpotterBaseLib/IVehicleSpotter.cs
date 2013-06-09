using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Spotter.Cloud.Service.Entities;
namespace Spotter.Cloud.Service.Interfaces
{
    [ServiceContract]
    public interface IVehicleSpotter
    {
        [OperationContract]
        List<VehicleDetails> GetAllVehicles();

        [OperationContract]
        bool AddVehicle(VehicleDetails vehicle);

        [OperationContract]
        bool RemoveVehicle(int id);

        [OperationContract]
        VehicleDetails GetVehicle(int id);
    }
}
