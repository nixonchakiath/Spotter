#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: Specification.cs
Description	: Specification is a small piece of logic which is independent and give an answer
              to the question “does this match ?”
Log
Date			Author			Comment
07-Jul-2012		Prince Joseph	Class created
*/
#endregion File Header


using System;
using System.Linq.Expressions;

namespace Spotter.Framework.DAL.Specification
{
    /// <summary>
    /// Specification is a small piece of logic which is independent and give an answer
    /// to the question “does this match ?”. With Specification, it is possible to isolate the logic that do the selection
    /// into a reusable business component that can be passed around easily from the entity we are selecting.
    /// </summary>
    /// <typeparam name="T">Type of item against which the specificaton is to be evaluated.</typeparam>
    public class Specification<T>
    {
        #region Fields

        /// <summary>
        /// The expression predicate.
        /// </summary>
        private readonly Expression<Func<T, bool>> expression;

        /// <summary>
        /// Function to evaluate the expression against an instance.
        /// </summary>
        private Func<T, bool> evaluateExpression;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Specification class.
        /// </summary>
        /// <param name="predicate">Expression predicate.</param>
        public Specification(Expression<Func<T, bool>> predicate)
        {
            this.expression = predicate;
        }

        /// <summary>
        /// Initializes a new instance of the Specification class.
        /// </summary>
        protected Specification()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the expression predicate.
        /// </summary>
        /// <value>The expression predicate.</value>
        public virtual Expression<Func<T, bool>> Predicate
        {
            get
            {
                if (expression != null)
                {
                    return expression;
                }

                //throw ExceptionBuilder.NotOverridden("Predicate"); // TODO: Prince - commented by Prince
                throw new Exception(); 
            }
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Evaluates the specification against an instance.
        /// </summary>
        /// <param name="candidate">The instance against which the specificaton is to be evaluated.</param>
        /// <returns>Should return <c>true</c> if the specification was satisfied by the entity, else <c>false</c>.</returns>
        public bool IsSatisfiedBy(T candidate)
        {
            if (evaluateExpression == null)
            {
                evaluateExpression = expression.Compile();
            }

            return evaluateExpression(candidate);
        }

        #endregion
    }
}
