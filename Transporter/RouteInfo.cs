// -----------------------------------------------------------------------
// <copyright file="RouteInfo.cs" company="">
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
    public class RouteInfo
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public LocationInfo StartLocation
        {
            get;
            set;
        }

        public LocationInfo EndLocation
        {
            get;
            set;
        }
    }
}
