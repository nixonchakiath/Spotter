#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: DataIntegrityViolationException.cs
Description	: Implementation of custom exception 'DataIntegrityViolationException' that 
              indicates data integration violations errors. Like foreign key violation.
Log
Date			Author			Comment
06-Jul-2012		Prince Joseph	Class created
*/
#endregion File Header

using System;
using System.Runtime.Serialization;

namespace Spotter.Framework.DAL.Exceptions
{
    /// <summary>
    /// Represents an exception that indicates data integration violations errors. Like foreign key violation.
    /// </summary>
    [Serializable]
    public class DataIntegrityViolationException : DataAccessException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataIntegrityViolationException"/> class.
        /// </summary>
        public DataIntegrityViolationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataIntegrityViolationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public DataIntegrityViolationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataIntegrityViolationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public DataIntegrityViolationException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataIntegrityViolationException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="info"/> parameter is null.
        /// </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">
        /// The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0).
        /// </exception>
        protected DataIntegrityViolationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
