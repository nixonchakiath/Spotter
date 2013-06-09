#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: OptimisticConcurrencyException.cs
Description	: Implementation of custom exception 'OptimisticConcurrencyException' that 
              occurs in case when concurent data modification access.
Log
Date			Author			Comment
07-Jul-2012		Prince Joseph	Class created
*/
#endregion File Header

using System;
using System.Runtime.Serialization;

namespace Spotter.Framework.DAL.Exceptions
{
    /// <summary>
    /// Represents an exception that occurs in case when concurent data modification access.
    /// </summary>
    [Serializable]
    public class OptimisticConcurrencyException : DataAccessException
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OptimisticConcurrencyException"/> class.
        /// Use this constructor if the entity and indetifier that caused the concurency exception is unknown.
        /// </summary>
        /// <param name="message">The message.</param>
        public OptimisticConcurrencyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptimisticConcurrencyException"/> class.
        /// Use this constructor if the entity and indetifier that caused the concurency exception is unknown.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public OptimisticConcurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptimisticConcurrencyException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="identifier">The identifier.</param>
        public OptimisticConcurrencyException(string message, string entityName, object identifier) : base(message)
        {
            // Requires.NotNullOrEmpty(entityName, "entityName");
            // Requires.NotNull(identifier, "identifier"); // TODO: Prince - Uncomment this
            EntityName = entityName;
            Identifier = identifier;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptimisticConcurrencyException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="identifier">The identifier.</param>
        /// <param name="inner">The inner.</param>
        public OptimisticConcurrencyException(string message, string entityName, object identifier, Exception inner) : base(message, inner)
        {
            // Requires.NotNullOrEmpty(entityName, "entityName");
            // Requires.NotNull(identifier, "identifier"); // TODO: Prince - Uncomment this
            EntityName = entityName;
            Identifier = identifier;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptimisticConcurrencyException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected OptimisticConcurrencyException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            EntityName = info.GetValue("entityName", typeof(string)) as string;
            Identifier = info.GetValue("identifier", typeof(object));
        }

        #endregion

        /// <summary>
        /// Gets the name of the entity that caused the concurrency exception.
        /// </summary>
        /// <value>The name of the entity.</value>
        public string EntityName { get; private set; }

        /// <summary>
        /// Gets or sets the identifier of entity that caused the concurrency exception.
        /// </summary>
        /// <value>The key value.</value>
        public object Identifier { get; private set; }
    }
}