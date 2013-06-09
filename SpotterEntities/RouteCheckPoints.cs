using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Spotter.Cloud.Service.Common;

namespace Spotter.Cloud.Service.Entities
{
    [Table("RouteCheckPoints")]
    public class RouteCheckPoints
    {
        [Key]
        [Required]
        public int ID
        {
            get;
            set;
        }

        [Required]
        [ForeignKey("Route")]
        public int RouteId
        {
            get;
            set;
        }

        public virtual RouteDetails Route
        {
            get;
            set;
        }

        [Required]
        [ForeignKey("Location")]
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

        public int Order
        {
            get;
            set;
        }
    }
}
