#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: RepositoryChangeEventArgs.cs
Description	: Repository change event args.
Log
Date			Author			Comment
08-Jul-2012		Prince Joseph	Class created
*/
#endregion File Header

using System;

namespace Spotter.Framework.DAL
{
    /// <summary>
    /// Repository change event args.
    /// </summary>
    public class RepositoryChangeEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// Gets the change type.
        /// </summary>
        /// <value>The change type.</value>
        public RepositoryChangeType ChangeType { get; private set; }

        /// <summary>
        /// Gets the repository entity instance.
        /// </summary>
        /// <value>The repository entity instance.</value>
        public object Entity { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryChangeEventArgs"/> class.
        /// </summary>
        /// <param name="changeType">The change type.</param>
        /// <param name="entity">The domain entity instance.</param>
        public RepositoryChangeEventArgs(RepositoryChangeType changeType, object entity)
        {
            ChangeType = changeType;
            Entity = entity;
        }

        #endregion
    }
}
