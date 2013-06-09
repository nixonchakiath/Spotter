#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: ParameterRebinder.cs
Description	: Helper for rebinder parameters without using Invoke method in expressions.
Log
Date			Author			Comment
07-Jul-2012		Prince Joseph	Class created
*/
#endregion File Header


using System.Collections.Generic;
using System.Linq.Expressions;

namespace Spotter.Framework.DAL.Specification
{
    /// <summary>
    /// Helper for rebinder parameters without using Invoke method in expressions.
    /// </summary>
    public class ParameterRebinder : ExpressionVisitor
    {
        #region Fields

        /// <summary>
        /// The map specification.
        /// </summary>
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        #endregion

        #region Constructors

        /// <summary>
        /// Default construcotr.
        /// </summary>
        /// <param name="map">Map specification.</param>
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Replate parameters in expression with a Map information.
        /// </summary>
        /// <param name="map">Map information.</param>
        /// <param name="exp">Expression to replace parameters.</param>
        /// <returns>Expression with parameters replaced.</returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        /// <summary>
        /// Visit pattern method.
        /// </summary>
        /// <param name="p">A Parameter expression.</param>
        /// <returns>New visited expression.</returns>
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }

        #endregion
    }
}
