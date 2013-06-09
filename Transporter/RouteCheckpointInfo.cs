// -----------------------------------------------------------------------
// <copyright file="RouteCheckpointInfo.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Transporter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class RouteCheckpointInfo
    {
        public int Id
        {
            get;
            set;
        }

        public RouteInfo Route
        {
            get;
            set;
        }

        public LocationInfo Location
        {
            get;
            set;
        }
    }
}
