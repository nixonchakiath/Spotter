#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: SpecificationExtension.cs
Description	: This class contains the extension methods to compose new expressions.
Log
Date			Author			Comment
07-Jul-2012		Prince Joseph	Class created
*/
#endregion File Header

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Spotter.Framework.DAL.Specification
{
    /// <summary>
    /// This class contains the extension methods to compose new expressions.
    /// </summary>
    public static class SpecificationExtension
    {
        #region Methods

        /// <summary>
        /// Method used for "And" operation.
        /// </summary>
        /// <typeparam name="T">Type of params in expression.</typeparam>
        /// <param name="first">Right Expression in And operation.</param>
        /// <param name="second">Left Expression in And operation.</param>
        /// <returns>New specification.</returns>
        public static Specification<T> And<T>(this Specification<T> first, Specification<T> second) where T : class
        {
            return new Specification<T>(
                first.Predicate
                .And(second.Predicate));
        }

        /// <summary>
        /// Method used for "Or" operation.
        /// </summary>
        /// <typeparam name="T">Type of params in expression.</typeparam>
        /// <param name="first">Right Expression in Or operation.</param>
        /// <param name="second">Left Expression in Or operation.</param>
        /// <returns>New specification.</returns>
        public static Specification<T> Or<T>(this Specification<T> first, Specification<T> second) where T : class
        {
            return new Specification<T>(
                first.Predicate
                .Or(second.Predicate));
        }

        /// <summary>
        /// Compose two expression and merge all in a new expression.
        /// </summary>
        /// <typeparam name="T">Type of params in expression.</typeparam>
        /// <param name="first">Expression instance.</param>
        /// <param name="second">Expression to merge.</param>
        /// <param name="merge">Function to merge.</param>
        /// <returns>New merged expressions.</returns>
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // Build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // Replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // Apply composition of lambda expression bodies to parameters from the first expression
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// And operation extesion.
        /// </summary>
        /// <typeparam name="T">Type of params in expression.</typeparam>
        /// <param name="first">Right Expression in And operation.</param>
        /// <param name="second">Left Expression in And operation.</param>
        /// <returns>New And expression.</returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        /// <summary>
        /// Or operation extension.
        /// </summary>
        /// <typeparam name="T">Type of params in expression.</typeparam>
        /// <param name="first">Right Expression in Or operation.</param>
        /// <param name="second">Left Expression in Or operation.</param>
        /// <returns>New Or expression.</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        #endregion
    }
}
