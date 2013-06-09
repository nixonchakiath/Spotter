#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: IUnitOfWork.cs
Description	: A unit of work contract that that commits / flushes changes to the 
              data store as part of a business transaction.
Log
Date			Author			Comment
08-Jul-2012		Prince Joseph	Class created
*/
#endregion File Header

using System;

namespace Spotter.Framework.DAL
{
    /// <summary>
    /// A unit of work contract that that commits / flushes changes to the data store
    /// as part of a business transaction.
    /// </summary>
    public interface IUnitOfWork
    {
        #region Events

        /// <summary>
        /// This event is raised before changes are saved to persistant storage.
        /// </summary>
        event EventHandler BeforeCommit;

        /// <summary>
        /// This event is raised after changes are saved to persistant storage.
        /// </summary>
        event EventHandler AfterCommit;

        #endregion

        #region Methods

        /// <summary>
        /// Flushes the changes made in the unit of work to the data store.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollback all the changes made in the unit of work.
        /// </summary>
        void Rollback();

        #endregion
    }
}
