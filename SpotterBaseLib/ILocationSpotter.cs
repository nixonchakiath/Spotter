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
    public interface ILocationSpotter
    {
        [OperationContract]
        List<LocationDetails> GetAllLocations();

        [OperationContract]
        bool AddLocation(LocationDetails vehicle);

        [OperationContract]
        bool RemoveLocation(int id);

        [OperationContract]
        LocationDetails GetLocation(int id);
    }
}
