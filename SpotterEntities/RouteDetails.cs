using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Spotter.Cloud.Service.Entities
{
    /// <summary>
    /// Route details
    /// </summary>
    [DataContract]
    public class RouteDetails
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
        [ForeignKey("Source")]
        public int SourceLocId
        {
            get;
            set;
        }

        /// <summary>
        /// Source location
        /// </summary>
        [DataMember]
        public virtual LocationDetails Source
        {
            get;
            set;
        }

        /// <summary>
        /// Source Location Id
        /// </summary>
        [Required]
        [ForeignKey("Destination")]
        public int DestinationLocId
        {
            get;
            set;
        }

        /// <summary>
        /// Destination location
        /// </summary>
        [DataMember]
        public virtual LocationDetails Destination
        {
            get;
            set;
        }

        /// <summary>
        /// Estimated time to travel from source to destination
        /// </summary>
        [DataMember]
        public TimeSpan EstimatedTime
        {
            get;
            set;
        }
    }

}
