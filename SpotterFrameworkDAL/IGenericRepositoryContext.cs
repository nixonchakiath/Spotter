#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: IGenericRepositoryContext.cs
Description	: The interface that manages the repository context.
Log
Date			Author			Comment
08-Jul-2012		Prince Joseph	Class created
*/
#endregion File Header

using System;

namespace Spotter.Framework.DAL
{
    /// <summary>
    /// The interface that manages the repository context.
    /// </summary>
    public interface IGenericRepositoryContext: IUnitOfWork, IDisposable
    {
        /// <summary>
        /// This method will return the repository of the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <returns>Instance of the repository.</returns>
        IGenericRepository GetRepository();
    }
}