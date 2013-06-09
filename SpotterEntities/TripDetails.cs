using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Spotter.Cloud.Service.Common;

namespace Spotter.Cloud.Service.Entities
{
    /// <summary>
    /// Route details
    /// </summary>
    [Table("TripDetails")]
    [DataContract]
    public class TripDetails
    {
        /// <summary>
        /// Route ID
        /// </summary>
        [Key]
        [Required]
        [DataMember] 
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Source Location Id
        /// </summary>
        [Required]
        [ForeignKey("Route")]
        public int RouteId
        {
            get;
            set;
        }

        /// <summary>
        /// Source location
        /// </summary>
        [DataMember]
        public virtual RouteDetails Route
        {
            get;
            set;
        }

        /// <summary>
        /// Source Location Id
        /// </summary>
        [Required]
        [ForeignKey("Vehicle")]
        public int VehicleId
        {
            get;
            set;
        }

        /// <summary>
        /// Destination location
        /// </summary>
        [DataMember]
        public virtual VehicleDetails Vehicle
        {
            get;
            set;
        }

        /// <summary>
        /// Source Location Id
        /// </summary>
        [Required]
        [ForeignKey("Driver")]
        public int DriverId
        {
            get;
            set;
        }

        /// <summary>
        /// Estimated time to travel from source to destination
        /// </summary>
        [DataMember]
        public DriverDetails Driver
        {
            get;
            set;
        }

        /// <summary>
        /// Start time 
        /// </summary>
        [DataMember]
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// Current status of the trip
        /// </summary>
        [DataMember]
        [NotMapped]
        public TripStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// Status variable in db
        /// </summary>
        [Column("Status")]
        public int TripStatusDb
        {
            get;
            set;
        }

        /// <summary>
        /// Current status of the trip
        /// </summary>
        [DataMember]
        [NotMapped]
        public LocationDetails CurrentLocation
        {
            get;
            set;
        }
    }

}
