#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: GenericRepository.cs
Description	: An abstract base class that implements <see cref="IGenericRepository"/>.
Log
Date			Author			Comment
08-Jul-2012		Prince Joseph	Class created
*/
#endregion File Header

using System;
using System.Collections.Generic;
using System.Linq;
using Spotter.Framework.DAL.Specification;

namespace Spotter.Framework.DAL
{
    /// <summary>
    /// An abstract base class that implements <see cref="IGenericRepository"/>.
    /// </summary>
    public abstract class GenericRepository : IGenericRepository
    {
        #region Events

        /// <summary>
        /// Raised before repository is going to be changed.
        /// </summary>
        public event EventHandler<RepositoryChangeEventArgs> RepositoryChanging;

        /// <summary>
        /// Raised after repository is changed.
        /// </summary>
        public event EventHandler<RepositoryChangeEventArgs> RepositoryChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Returns list of entities from the repository or store.
        /// </summary>
        /// <returns>Strongly typed <see cref="IEnumerable{TEntity}"/>.</returns>
        public abstract IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;

        /// <summary>
        /// Returns a list of entities from the repository based on the given specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The entity matching the specification.</returns>
        public abstract IEnumerable<TEntity> GetBySpecification<TEntity>(Specification<TEntity> specification) where TEntity : class;

        /// <summary>
        /// Returns an entity that has the specified entity key.
        /// </summary>
        /// <param name="id">Entity key value.</param>
        /// <returns>The entity.</returns>
        public abstract TEntity GetById<TEntity>(int id) where TEntity : class;

        /// <summary>
        /// Add entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        public abstract TEntity Add<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Updates entity within the the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public abstract void Update<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Mark entity to be deleted within the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public abstract void Delete<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Mark all entities to delete within the repository
        /// </summary>
        /// <remarks>This method deletes data from requested table and cascaded records
        /// will also be deleted.</remarks>
        /// <param name="entity">The entity type to delete.</param>
        public abstract void DeleteAll<TEntity>() where TEntity : class;

        /// <summary>
        /// Mark all entities to delete within the repository that matches condition 
        /// </summary>
        /// <remarks>This method deletes data from requested table and cascaded records
        /// will also be deleted.</remarks>
        /// <param name="entity">The entity type to delete.</param>
        /// <param name="paramValues">Dynamic parameter values</param>
        public abstract void DeleteAll<TEntity>(IQueryable<TEntity> condition, params object[] paramValues) where TEntity : class;

        /// <summary>
        /// Raises <see cref="RepositoryChanging"/> event.
        /// </summary>
        /// <param name="changeType">Change type.</param>
        /// <param name="entity">The enitity instance.</param>
        protected virtual void OnRepositoryChanging<TEntity>(RepositoryChangeType changeType, TEntity entity) where TEntity : class
        {
            EventHandler<RepositoryChangeEventArgs> handler = RepositoryChanging;

            if (handler != null)
            {
                handler(this, new RepositoryChangeEventArgs(changeType, entity));
            }
        }

        /// <summary>
        /// Raises <see cref="RepositoryChanged"/> event.
        /// </summary>
        /// <param name="changeType">Change type.</param>
        /// <param name="entity">The entity instance.</param>
        protected virtual void OnRepositoryChanged<TEntity>(RepositoryChangeType changeType, TEntity entity) where TEntity : class
        {
            EventHandler<RepositoryChangeEventArgs> handler = RepositoryChanged;

            if (handler != null)
            {
                handler(this, new RepositoryChangeEventArgs(changeType, entity));
            }
        }

        #endregion
    }
}