#region File Header
/*
Copyright Rudolph Technologies .
All rights are reserved. Reproduction or transmission in whole or in part, in any form or by any means, 
electronic, mechanical or otherwise, is prohibited without the prior written consent of the copyright owner.
File Name	: Utility.cs
Description	: This class performs common operations related to EFRepository
Log
Date			Author			Comment
08-Aug-2012		Prince Joseph	Class created
*/
#endregion File Header

using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Spotter.Framework.EF
{
    /// <summary>
    /// This class performs common operations related to EFRepository
    /// </summary>
    /// <remarks>This class is sensitive to EF revisions.<see cref="snippet"/></remarks>
    internal static class Utility
    {
        /// <summary>
        /// This method reads an entity class and gets delete query based on where condition
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity</typeparam>
        /// <param name="condition">Where condition as IQueryable object</param>
        /// <returns>Returns the sql delete query</returns>
        internal static string GetClause<TEntity>(IQueryable<TEntity> condition, params object[] paramValues) where TEntity : class
        {
            string snippet = "FROM [dbo].[";
            string sql = ((DbQuery<TEntity>)condition).ToString();
            sql = sql.Replace("\r\n", "");
            // Replace multiple spaces to single
            Regex regex = new Regex(@"[ ]{2,}", RegexOptions.None);
            sql = regex.Replace(sql, @" ");
            string sqlFirstPart = sql.Substring(sql.IndexOf(snippet));
            var sqlQuery = string.Format(CultureInfo.InvariantCulture, "DELETE [Extent1] {0}", sqlFirstPart);
            if (paramValues != null && paramValues.Count() > 0)
            {   
                int index = 0;
                foreach (var paramValue in paramValues)
                {
                    var paramName = "@p__linq__" + index;
                    sqlQuery = sqlQuery.Replace(paramName, paramValue.ToString());
                }
            }
            return sqlQuery;
        }

        /// <summary>
        /// This method reads an entity class and gets the table
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity</typeparam>
        /// <param name="context">Object context</param>
        /// <returns>Table name along with where condition</returns>
        internal static string GetTableName<TEntity>(ObjectContext context) where TEntity : class
        {
            string snippet = "FROM [dbo].[";
            string sql = context.CreateObjectSet<TEntity>().ToTraceString();
            string sqlFirstPart = sql.Substring(sql.IndexOf(snippet) + snippet.Length);
            string tableName = sqlFirstPart.Substring(0, sqlFirstPart.IndexOf("]"));
            return tableName;
        } 
    }
}
