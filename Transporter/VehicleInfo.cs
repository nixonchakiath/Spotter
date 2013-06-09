using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transporter
{
    public enum VehicleSatus : int
    {
        Available,
        Assigned,
        Live,
        Lost,
        Breakdown
    }


    public class VehicleInfo
    {
        public VehicleInfo()
        {
            Status = VehicleSatus.Available;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Number {get; set;}
        public VehicleSatus Status { get; set; }
        public string Details { get; set; }
    }
}
