using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spotter.Cloud.Service.Common
{
    public enum TripStatus : int
    {
        /// <summary>
        /// Default state
        /// </summary>
        Scheduled,
        /// <summary>
        /// if the trip has started
        /// </summary>
        Live,
        /// <summary>
        /// if the trip has paused due to vehicle breakdown, etc
        /// </summary>
        Paused,
        /// <summary>
        /// if the trip has cancelled or aborted
        /// </summary>
        Halted,
        /// <summary>
        /// if the trip has successfuly completed
        /// </summary>
        Completed
    }

    /// <summary>
    /// Enumeration used to indicate the type of Tool.
    /// </summary>
    public enum VehicleSatus : int
    {
        /// <summary>
        /// No trips scheduled for the vehicle
        /// </summary>
        Available,
        /// <summary>
        /// Assigned trip for the vehicle, Yet to start the assigned trip.
        /// </summary>
        Assigned,
        /// <summary>
        /// The trip has started and Vehicle is live.
        /// </summary>
        Live,
        /// <summary>
        /// The trip has started, but status of vehicle is unknown
        /// </summary>
        Lost,
        /// <summary>
        /// The trip has started, but vehicle got break down
        /// </summary>
        Breakdown
    }
}
