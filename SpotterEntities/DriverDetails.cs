using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Spotter.Cloud.Service.Entities
{
    [Table("DriverDetails")]
    [DataContract]
    public class DriverDetails
    {
        /// <summary>
        /// Unique id of the driver
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
        /// Name of the driver
        /// </summary>
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Cell Number of the driver
        /// </summary>
        [DataMember]
        public string CellNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Staying address
        /// </summary>
        [DataMember]
        public string Address
        {
            get;
            set;
        }
    }

}
