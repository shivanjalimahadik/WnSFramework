//-----------------------------------------------------------------------
// <copyright file="QueryResult.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Util
{
    using System;

    /// <summary>
    ///     A result object with the generated SQL and dynamic PARAMAS.
    /// </summary>
    public class QueryResult
    {
        /// <summary>
        ///     The _result
        /// </summary>
        private readonly Tuple<string, dynamic> result;

        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryResult" /> class.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="param">The param.</param>
        public QueryResult(string sql, dynamic param)
        {
            this.result = new Tuple<string, dynamic>(sql, param);
        }

        /// <summary>
        ///     Gets the SQL.
        /// </summary>
        /// <value>
        ///     The SQL.
        /// </value>
        public string Sql
        {
            get { return this.result.Item1; }
        }

        /// <summary>
        ///     Gets the param.
        /// </summary>
        /// <value>
        ///     The param.
        /// </value>
        public dynamic Param
        {
            get { return this.result.Item2; }
        }
    }
}