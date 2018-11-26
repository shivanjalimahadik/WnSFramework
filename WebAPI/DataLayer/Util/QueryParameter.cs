//-----------------------------------------------------------------------
// <copyright file="QueryParameter.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Util
{
    /// <summary>
    /// Class that models the data structure in converting the expression tree into SQL and PARAMS.
    /// </summary>
    internal class QueryParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParameter" /> class.
        /// </summary>
        /// <param name="linkingOperator">The linking operator.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyValue">The property value.</param>
        /// <param name="queryOperator">The query operator.</param>
        internal QueryParameter(string linkingOperator, string propertyName, object propertyValue, string queryOperator)
        {
            this.LinkingOperator = linkingOperator;
            this.PropertyName = propertyName;
            this.PropertyValue = propertyValue;
            this.QueryOperator = queryOperator;
        }

        /// <summary>
        /// Gets or sets Linkage operator
        /// </summary>
        public string LinkingOperator { get; set; }

        /// <summary>
        /// Gets or sets property name
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets property value
        /// </summary>
        public object PropertyValue { get; set; }

        /// <summary>
        /// Gets or sets query operator
        /// </summary>
        public string QueryOperator { get; set; }
    }
}