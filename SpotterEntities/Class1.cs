using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Spotter.Cloud.Service.Common;

namespace Spotter.Cloud.Service.Entities
{
    [Table("VehicleTracking")]
    public class VehicleTracking
    {
        [Key]
        [Required]
        public int ID
        {
            get;
            set;
        }

        [ForeignKey("Vehicle")]
        [Required]
        public int VehicleId
        {
            get;
            set;
        }

        public virtual VehicleDetails Vehicle
        {
            get;
            set;
        }

        [ForeignKey("Location")]
        [Required]
        public int LocationId
        {
            get;
            set;
        }

        public virtual LocationDetails Location
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }
    }
}
