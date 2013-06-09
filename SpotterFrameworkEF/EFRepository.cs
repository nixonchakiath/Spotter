#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: EFRepository.cs
Description	: Implementation of <see cref="GenericRepository" /> class that uses Entity Framework
              for the repository operations. Also Implements IUnitOfWork pattern as well as IDisposible.
Log
Date			Author			Comment
09-Jul-2012		Prince Joseph	Class created
*/
#endregion File Header

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using Spotter.Framework.DAL;
using Spotter.Framework.DAL.Specification;

namespace Spotter.Framework.EF
{
    /// <summary>
    /// Implementation of <see cref="GenericRepository" /> class that uses Entity Framework
    /// for the repository operations. Implements IUnitOfWork pattern as well as IDisposible.
    /// </summary>
    public class EFRepository : GenericRepository, IUnitOfWork, IDisposable
    {
        #region Fields

        /// <summary>
        /// A boolean value indicating whether the current object is disposed or not.
        /// </summary>
        private bool disposed;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EFRepository" /> class
        /// </summary>
        /// <param name="context">The DbContext.</param>
        public EFRepository(DbContext context)
        {
            if (context == null)
            {
                throw new Exception(Messages.DbContextNull);
            }

            this.DataContext = context;
        }

        #endregion

        #region Events

        /// <summary>
        /// This event is raised before changes are saved to persistant storage.
        /// </summary>
        public event EventHandler BeforeCommit;

        /// <summary>
        /// This event is raised after changes are saved to persistant storage.
        /// </summary>
        public event EventHandler AfterCommit;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the entity framework Data Context.
        /// </summary>
        public DbContext DataContext { get; private set; }

        /// <summary>
        /// Gets the entity framework Object Context.
        /// </summary>
        public ObjectContext Context
        {
            get { return ((IObjectContextAdapter)this.DataContext).ObjectContext; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns list of entities from the repository or store
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>Strongly typed <see cref="IEnumerable{TEntity}"/>.</returns>
        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            string methodName = "EFRepository::GetAll";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            DbSet<TEntity> dataSet = null;
            try
            {
               dataSet = this.DataContext.Set<TEntity>();                
            }
            catch (DataException ex)
            {
                //Logger.Instance().Log(methodName, ex);
                throw ex;
            }

            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);

            return dataSet.ToList();
        }

        /// <summary>
        /// Returns a list of entities from the repository based on the given specification.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>The list of entities.</returns>
        public override IEnumerable<TEntity> GetBySpecification<TEntity>(Specification<TEntity> specification)
        {
            string methodName = "EFRepository::GetBySpecification";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            IEnumerable<TEntity> items;

            if (specification.Predicate == null)
            {
                //Logger.Instance().Log(methodName, Messages.MissingPredicate, //Logger.LogLevel.Warnings);
                throw new Exception(Messages.MissingPredicate);              
            }

            try
            {
                items = this.DataContext.Set<TEntity>().Where(specification.Predicate).AsEnumerable();
                //// This code is added to ensure that the above query executed properly. 
                //// For example, if data connection is invalid, the above statement will not throw an exception.
                //// So, while accessing the items, an exception shall be thrown in case of any failures.
                //// var count = items.Count();                
            }
            catch (DataException ex)
            {
                //Logger.Instance().Log(methodName, ex);
                throw ex;                
            }

            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);

            return items;
        }

        /// <summary>
        /// Returns an entity that has the specified entity key.
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <typeparam name="TEntity">Entity type</typeparam> 
        /// <returns>Entity with the unique ID</returns>
        /// <exception cref="NotSupportedException">Occurs if the Entity Type(TEntity) is not stored in the given repository</exception>
        public override TEntity GetById<TEntity>(int id)
        {
            string methodName = "EFRepository::GetById";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            try
            {
                DbSet<TEntity> dataSet = this.DataContext.Set<TEntity>();
                var objSet = this.Context.CreateObjectSet<TEntity>();
                var entitySet = objSet.EntitySet;
                string[] keyNames = entitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
                if (keyNames.Length == 1)
                {
                    //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);

                    return dataSet.Find(id);
                }
                else
                {
                    object[] compositeIds = new object[keyNames.Length];
                    object compositeKeyIdentifier = id;
                    PropertyDescriptorCollection keyObjectProperties = TypeDescriptor.GetProperties(compositeKeyIdentifier);
                    int counter = 0;
                    foreach (var keyMember in keyNames)
                    {
                        PropertyDescriptor propertyDescriptor = keyObjectProperties.Find(keyMember, true);
                        var val = propertyDescriptor.GetValue(compositeKeyIdentifier);
                        compositeIds[counter++] = val;
                    }

                    //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);

                    return dataSet.Find(compositeIds);
                }
            }
            catch (DataException ex)
            {
                //Logger.Instance().Log(methodName, ex);
                throw ex;
            }
        }

        /// <summary>
        /// Add an entity to the repository.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam> 
        /// <param name="entity">The entity to add.</param>
        /// <returns>The entity.</returns>
        public override TEntity Add<TEntity>(TEntity entity)
        {
            string methodName = "EFRepository::Add";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            if (object.Equals(entity, default(TEntity)))
            {
                //Logger.Instance().Log(methodName, Messages.ArgumentCouldNotBeDefault, //Logger.LogLevel.Warnings);
                throw new Exception(Messages.ArgumentCouldNotBeDefault);
            }

            try
            {
                DbSet<TEntity> dataSet = this.DataContext.Set<TEntity>();
                this.OnRepositoryChanging(RepositoryChangeType.Add, entity);
                dataSet.Add(entity);
                this.OnRepositoryChanged(RepositoryChangeType.Add, entity);
            }
            catch (DataException ex)
            {
                //Logger.Instance().Log(methodName, ex);
                throw ex;
            }

            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);

            return entity;
        }

        /// <summary>
        /// This method updates an entity in the repository.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="entity">Entity instance</param>
        public override void Update<TEntity>(TEntity entity) 
        {
            string methodName = "EFRepository::Update";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            if (object.Equals(entity, default(TEntity)))
            {
                //Logger.Instance().Log(methodName, Messages.ArgumentCouldNotBeDefault, //Logger.LogLevel.Warnings);
                throw new Exception(Messages.ArgumentCouldNotBeDefault);
            }

            var entityState = this.DataContext.Entry<TEntity>(entity).State;
            if (entityState == System.Data.EntityState.Deleted)
            {
                //Logger.Instance().Log(methodName, Messages.ArgumentCouldNotBeUpdated, //Logger.LogLevel.Warnings);
                throw new Exception(Messages.ArgumentCouldNotBeUpdated);
            }

            var objSet = this.Context.CreateObjectSet<TEntity>();
            var entityKey = this.Context.CreateEntityKey(objSet.EntitySet.Name, entity);
            object originalItem;
            if (!this.Context.TryGetObjectByKey(entityKey, out originalItem))
            {
                //Logger.Instance().Log(methodName, Messages.ObjectDoesNotLongerExists, //Logger.LogLevel.Warnings);
                throw new Spotter.Framework.DAL.Exceptions.OptimisticConcurrencyException(Messages.ObjectDoesNotLongerExists, entity.GetType().Name, entityKey);
            }

            try
            {
                this.OnRepositoryChanging(RepositoryChangeType.Update, entity);
                this.DataContext.Entry<TEntity>(entity).State = System.Data.EntityState.Modified;
                this.OnRepositoryChanged(RepositoryChangeType.Update, entity);
            }
            catch (DataException ex)
            {
                //Logger.Instance().Log(methodName, ex);
                throw ex;
            }

            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);
        }

        /// <summary>
        /// Mark an entity for deletion in the repository.
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam> 
        /// <param name="entity">The entity to delete.</param>
        public override void Delete<TEntity>(TEntity entity)
        {
            string methodName = "EFRepository::Delete";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            if (object.Equals(entity, default(TEntity)))
            {
                //Logger.Instance().Log(methodName, Messages.ArgumentCouldNotBeDefault, //Logger.LogLevel.Warnings);
                throw new Exception(Messages.ArgumentCouldNotBeDefault);
            }

            var objSet = this.Context.CreateObjectSet<TEntity>();
            var entityKey = this.Context.CreateEntityKey(objSet.EntitySet.Name, entity);
            object originalItem;
            if (!this.Context.TryGetObjectByKey(entityKey, out originalItem))
            {
                //Logger.Instance().Log(methodName, Messages.ObjectDoesNotLongerExists, //Logger.LogLevel.Warnings);
                throw new Spotter.Framework.DAL.Exceptions.OptimisticConcurrencyException(Messages.ObjectDoesNotLongerExists, entity.GetType().Name, entityKey);
            }

            try
            {
                this.OnRepositoryChanging(RepositoryChangeType.Delete, entity);
                this.Context.DeleteObject(entity);
                this.OnRepositoryChanged(RepositoryChangeType.Delete, entity);
            }
            catch (DataException ex)
            {
                //Logger.Instance().Log(methodName, ex);
                throw ex;
            }

            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);
        }

        /// <summary>
        /// This method deletes all the entities of given type from repository
        /// </summary>
        /// <remarks>This method deletes data from requested table and cascaded records
        /// will also be deleted.</remarks>
        /// <typeparam name="TEntity">Entity type to be deleted</typeparam>
        /// <overload>An override of the method that exists which accepts where condition</overload>
        public override void DeleteAll<TEntity>()
        {
            string methodName = "EFRepository::DeleteAll";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            try
            {
                string sqlClause = Utility.GetTableName<TEntity>(this.Context);
                this.DataContext.Database.ExecuteSqlCommand(string.Format(CultureInfo.InvariantCulture, "DELETE {0}", sqlClause));
                // this.Context.Refresh(RefreshMode.StoreWins, TEntity);

                //var dataSet = DataContext.Set<TEntity>();
                //if (dataSet != null)
                //{
                //    foreach (var entity in dataSet)
                //    {
                //        DataContext.Set<TEntity>().Remove(entity);
                //    }
                //}
            }
            catch (DataException ex)
            {
                //Logger.Instance().Log(methodName, ex);
                throw ex;
            }
            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);
        }

        /// <summary>
        /// This method deletes all the entities of given type from repository
        /// </summary>
        /// <remarks>This method deletes data from requested table and cascaded records
        /// will also be deleted.</remarks>
        /// <typeparam name="TEntity">Entity type to be deleted</typeparam>
        /// <param name="clause">IQueryable entity object</param>
        /// <param name="paramValues">Dynamic parameter values</param>
        /// <overload>An override of the method that exists which accepts where condition</overload>
        public override void DeleteAll<TEntity>(IQueryable<TEntity> clause, params object[] paramValues)
        {
            string methodName = "EFRepository::DeleteAll(IQueryable<TEntity>)";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            try
            {
                string sqlQuery = Utility.GetClause<TEntity>(clause, paramValues);
                this.DataContext.Database.ExecuteSqlCommand(sqlQuery);
                // this.Context.Refresh(RefreshMode.StoreWins, TEntity);
            }
            catch (DataException ex)
            {
                //Logger.Instance().Log(methodName, ex);
                throw ex;
            }
            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);
        }

        #endregion

        #region Unit of Work Methods

        /// <summary>
        /// Flushes the changes made in the unit of work to the data store.
        /// </summary>
        public void Commit()
        {
            string methodName = "EFRepository::Commit";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            this.OnBeforeSaveChanges();

            try
            {
                this.DataContext.SaveChanges();
            }
            catch (DataException ex)
            {
                //Logger.Instance().Log(methodName, ex);
                throw ex;
            }

            this.OnAfterSaveChanges();
            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);
        }

        /// <summary>
        /// Rollback all the changes made in the unit of work.
        /// </summary>
        public void Rollback()
        {
            string methodName = "EFRepository::Rollback";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            this.DataContext.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = System.Data.EntityState.Unchanged);
            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);
        }

        /// <summary>
        /// This function is used to create the specified instance of type TEntity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The identifier that uniquely identifies the data item.</typeparam>
        /// <returns>Instance of Repository.</returns>
        public IGenericRepository GetRepository()
        {
            string methodName = "EFRepository::GetRepository";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            EFRepository repository = new EFRepository(this.DataContext);
            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);

            return repository;
        }

        /// <summary>
        /// Raises BeforeSaveChanges event.
        /// </summary>
        private void OnBeforeSaveChanges()
        {
            string methodName = "EFRepository::OnBeforeSaveChanges";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);

            //// BeforeCommit(this, EventArgs.Empty);
            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);
        }

        /// <summary>
        /// Raises AfterSaveChanges event.
        /// </summary>
        private void OnAfterSaveChanges()
        {
            string methodName = "EFRepository::OnAfterSaveChanges";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            //// AfterCommit(this, EventArgs.Empty);
            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            string methodName = "EFRepository::Dispose";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            this.Dispose(true);
            GC.SuppressFinalize(this);
            //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);
        }

        /// <summary>
        /// Disposes the managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">Boolean value indicating whether to dispose or not.</param>
        private void Dispose(bool disposing)
        {
            string methodName = "EFRepository::Dispose";
            //Logger.Instance().Log(methodName, "Method Entered", //Logger.LogLevel.Info);
            if (!disposing)
            {
                //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);

                return;
            }

            if (this.disposed)
            {
                //Logger.Instance().Log(methodName, "Method Exited", //Logger.LogLevel.Info);

                return;
            }

            this.disposed = true;
        }

        #endregion
    }
}