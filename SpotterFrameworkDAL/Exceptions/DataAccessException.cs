#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: DataAccessException.cs
Description	: Implementation of custom exxception 'DataAccessException'
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
    /// The base data layer exception class.
    /// </summary>
    [Serializable]
    public class DataAccessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        public DataAccessException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public DataAccessException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public DataAccessException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="info"/> parameter is null.
        /// </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">
        /// The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0).
        /// </exception>
        protected DataAccessException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
