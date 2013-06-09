using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Spotter.Cloud.Service.Common;

namespace Spotter.Cloud.Service.Entities
{
    [Table("VehicleDetails")]
    [DataContract]
    public class VehicleDetails
    {
        /// <summary>
        /// Unique id of the number
        /// </summary>
        [Key]
        [Column("ID")]
        [DataMember]
        public int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Name of the vehicle
        /// </summary>
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Number of the vehicle
        /// </summary>
        [Column("ID")]
        [DataMember]
        public string Number
        {
            get;
            set;
        }

        /// <summary>
        /// Status of the vehicle
        /// </summary>
        [NotMapped]
        [DataMember]
        public VehicleSatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// Additional information, if any
        /// </summary>
        [DataMember]
        public string Comments
        {
            get;
            set;
        }
    }

}
