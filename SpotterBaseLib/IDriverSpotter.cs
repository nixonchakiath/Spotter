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
    public interface IDriverSpotter
    {
        [OperationContract]
        List<DriverDetails> GetAllDrivers();

        [OperationContract]
        bool AddDriver(DriverDetails vehicle);

        [OperationContract]
        bool RemoveDriver(int id);

        [OperationContract]
        DriverDetails GetDriver(int id);
    }
}
