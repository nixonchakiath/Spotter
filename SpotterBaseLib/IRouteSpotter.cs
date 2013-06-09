using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Spotter.Cloud.Service.Entities;
namespace Spotter.Cloud.Service.Interfaces
{
    [ServiceContract]
    public interface IRouteSpotter
    {
        /// <summary>
        /// Get all routes available in the system
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<RouteDetails> GetAllRoutes();

        /// <summary>
        /// Adds a new route to the system
        /// </summary>
        /// <param name="route">Route details, set the id to -1, it will be automatically generated</param>
        /// <returns>If success, id of the route created. Otherwise, returns -1</returns>
        [OperationContract]
        int AddRoute(RouteDetails route);

        /// <summary>
        /// Adds a new route to the system
        /// </summary>
        /// <param name="sourceLocId">Source location id</param>
        /// <param name="destLocId">Destination location id</param>
        /// <param name="estimatedTime">Estimated time</param>
        /// <returns>return the id of the created route, otherwise return -1</returns>
        [OperationContract]
        int AddRoute(int sourceLocId, int destLocId, TimeSpan estimatedTime);

        /// <summary>
        /// Removes the route with given id from the system 
        /// </summary>
        /// <param name="id">Id of the route to be removed</param>
        /// <returns>true if the remove operation succeed, otherwise return false</returns>
        [OperationContract]
        bool RemoveRoute(int id);

        /// <summary>
        /// Get the route for the given id
        /// </summary>
        /// <param name="id">id of the route data to be retrieved</param>
        /// <returns>returns route data, if doesnt exist return null</returns>
        [OperationContract]
        LocationDetails GetRoute(int id);

        /// <summary>
        /// Update the check points for the given route.  
        /// </summary>
        /// <param name="id">Id of the route whose check points to be retrieved</param>
        /// <param name="checkPoints">Check points in the order of source to destination</param>
        /// <returns>true if the update was successful, otherwise false</returns>
        [OperationContract]
        bool UpdateRouteCheckPoints(int id, List<LocationDetails> checkPoints);

        /// <summary>
        /// Retrieve the route check points for given route
        /// </summary>
        /// <param name="id">id of the route whose check points to be retrieved</param>
        /// <returns>Returns all check points in the order of source to destination</returns>
        [OperationContract]
        List<LocationDetails> RetrieveRouteCheckPoints(int id);
    }
}
