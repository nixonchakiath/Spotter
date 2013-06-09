using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Spotter.Cloud.Service.Entities
{
    [Table("LocationDetails")]
    [DataContract]
    public class LocationDetails
    {
        /// <summary>
        /// Unique id of the location
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
        /// Location name
        /// </summary>
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Country where place belongs to
        /// </summary>
        [DataMember]
        public string Country
        {
            get;
            set;
        }

        /// <summary>
        /// State in the country where place belongs to
        /// </summary>
        [DataMember]
        public string State
        {
            get;
            set;
        }

        /// <summary>
        /// Longitude of the location in degress
        /// </summary>
        [DataMember]
        public double Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// Latitude of the location in degrees
        /// </summary>
        [DataMember]
        public double Latitude
        {
            get;
            set;
        }
    }
}
