//-----------------------------------------------------------------------
// <copyright file="DynamicQuery.cs" company="SA Technology">
//     Copyright (c) SA Technology. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DataAccess.Util
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Class for dynamic query
    /// </summary>
    public sealed class DynamicQuery
    {
        /// <summary>
        /// Gets the insert query.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="item">The item.</param>
        /// <returns>
        ///     The SQL query based on the item properties.
        /// </returns>
        public static string GetInsertQuery(string tableName, dynamic item)
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            var columns = props.Select(x => x.Name).Where(x => x != "Id");
            var propertyInfo = item.GetType().GetProperty("Id");
            dynamic value = null;
            if (propertyInfo != null)
            {
                value = propertyInfo.GetValue(item, null);
            }

            if (value != null)
            {
                columns = props.Select(x => x.Name);
            }

            return string.Format("INSERT INTO {0} ({1}) OUTPUT inserted.Id VALUES (@{2})", tableName, string.Join(",", columns), string.Join(",@", columns));
        }

        /// <summary>
        ///     Gets the update query.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="item">The item.</param>
        /// <returns>
        ///     The SQL query based on the item properties.
        /// </returns>
        public static string GetUpdateQuery(string tableName, dynamic item)
        {
            PropertyInfo[] props = item.GetType().GetProperties();
            var columns = props.Select(p => p.Name).Where(s => s != "Id").ToArray();

            var parameters = columns.Select(name => name + "=@" + name).ToList();

            return string.Format("UPDATE {0} SET {1} WHERE ID=@ID", tableName, string.Join(",", parameters));
        }

        /// <summary>
        /// Gets paging query
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortProperty">Sort property</param>
        /// <param name="sortDescending">Whether to sort descending</param>
        /// <param name="searchText">Search text</param>
        /// <returns>SQL query</returns>
        public static string GetPagingQuery(string tableName, int pageNumber, int pageSize, string sortProperty, bool sortDescending, string searchText)
        {
            var sortField = "Name";
            var soql = " SELECT * " +
                             " FROM " + tableName;

            soql += " ORDER BY " + sortField;
            if (sortDescending)
            {
                soql += " DESC ";
            }

            int offset = (pageNumber * pageSize) - pageSize;
            if (offset <= 2000)
            {
                soql += " LIMIT " + pageSize + " OFFSET " + offset;
            }
            else
            {
                soql += " LIMIT " + ((pageNumber * pageSize) - 2000) + " OFFSET 2000";
            }

            return soql;
        }

        /// <summary>
        /// Gets dynamic page query
        /// </summary>
        /// <typeparam name="T">Type of the item</typeparam>
        /// <param name="tableName">Table name</param>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sortProperty">Sort property</param>
        /// <param name="sortDescending">Whether to sort descending</param>
        /// <param name="expression">Predicate expression</param>
        /// <returns>Query result object</returns>
        public static QueryResult GetDynamicPageQuery<T>(string tableName, int pageNumber, int pageSize, string sortProperty, bool sortDescending, Expression<Func<T, bool>> expression)
        {
            var queryResult = GetDynamicQuery(tableName, expression);
            var builder = new StringBuilder();

            /*if (!String.IsNullOrEmpty(searchText))
            {
                // This is also temporary
                builder.AppendFormat(" AND ( FirstName LIKE '%{0}%' OR LastName LIKE '%{0}%' )", searchText);
            }*/
            var sortOrder = sortDescending ? "DESC" : "ASC";
            builder.AppendFormat(" ORDER BY {0} {1}", sortProperty, sortOrder);
            builder.AppendFormat(" OFFSET {0} ROWS ", (pageNumber - 1) * pageSize);
            builder.AppendFormat(" FETCH NEXT {0} ROWS ONLY", pageSize);
            return new QueryResult(queryResult.Sql + builder.ToString().TrimEnd(), queryResult.Param);
        }

        /// <summary>
        ///     Gets the dynamic query.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="expression">The expression.</param>
        /// <typeparam name="T">Value of type T</typeparam>
        /// <returns>A result object with the generated SQL and dynamic PARAMS.</returns>
        public static QueryResult GetDynamicQuery<T>(string tableName, Expression<Func<T, bool>> expression)
        {
            var queryProperties = new List<QueryParameter>();
            IDictionary<string, object> expando = new ExpandoObject();
            var builder = new StringBuilder();

            // walk the tree and build up a list of query parameter objects
            // from the left and right branches of the expression tree
            WalkTree(expression.Body, ExpressionType.Default, ref queryProperties);

            // convert the query parms into a SQL string and dynamic property object
            builder.Append("SELECT * FROM ");
            builder.Append(tableName);
            builder.Append(" WHERE ");

            if (expression.Body.ToString().Contains("AndAlso") && queryProperties.Count() > 2)
            {
                for (var i = 0; i < queryProperties.Count(); i++)
                {
                    var item = queryProperties[i];
                    var placeHolderName = item.PropertyName + i;
                    if (item.PropertyValue == null && queryProperties.Count() == 1)
                    {
                        builder.Append(string.Format(" {0} {1} ", item.PropertyName, item.QueryOperator));
                    }
                    else
                    {
                        if (i == 1)
                        {
                            builder.Append("(" + " ");
                        }

                        if (item.PropertyValue == null && queryProperties.Count() != 1)
                        {
                            if (i == queryProperties.Count() - 1)
                            {
                                builder.Append(string.Format(" {0} {1} ", item.PropertyName, item.QueryOperator));
                                builder.Append(")");
                            }

                            builder.Append(string.Format(" {0} {1}  {2}", item.PropertyName, item.QueryOperator, item.LinkingOperator));
                        }
                        else
                        {
                            if (i == queryProperties.Count() - 1)
                            {
                                builder.Append(string.Format(" {0}  {1}  @{2} ", item.PropertyName, item.QueryOperator, placeHolderName));
                                builder.Append(")");
                            }
                            else
                            {
                                builder.Append(string.Format(" {0}  {1}  @{2}   {3} ", item.PropertyName, item.QueryOperator, placeHolderName, item.LinkingOperator));
                            }
                        }
                    }

                    expando[placeHolderName] = item.PropertyValue;
                }
            }
            else
            {
                for (var i = 0; i < queryProperties.Count(); i++)
                {
                    var item = queryProperties[i];
                    var placeHolderName = item.PropertyName + i;
                    if (!string.IsNullOrEmpty(item.LinkingOperator) && i > 0)
                    {
                        builder.Append(" " + item.LinkingOperator);
                    }

                    if (item.PropertyValue == null)
                    {
                        builder.Append(string.Format(" {0} {1} ", item.PropertyName, item.QueryOperator));
                    }
                    else
                    {
                        builder.Append(string.Format(" {0} {1} @{2} ", item.PropertyName, item.QueryOperator, placeHolderName));
                    }

                    expando[placeHolderName] = item.PropertyValue;
                }
            }

            return new QueryResult(builder.ToString().TrimEnd(), expando);
        }

        /// <summary>
        /// Get dynamic content
        /// </summary>
        /// <typeparam name="T">Value of the type T</typeparam>
        /// <param name="tableName">Table name</param>
        /// <param name="expression">The expression</param>
        /// <returns>Query result object</returns>
        public static QueryResult GetDynamicCount<T>(string tableName, Expression<Func<T, bool>> expression)
        {
            var queryProperties = new List<QueryParameter>();
            IDictionary<string, object> expando = new ExpandoObject();
            var builder = new StringBuilder();

            // walk the tree and build up a list of query parameter objects
            // from the left and right branches of the expression tree
            WalkTree(expression.Body, ExpressionType.Default, ref queryProperties);

            // convert the query parms into a SQL string and dynamic property object
            builder.Append("SELECT Count(*) FROM ");
            builder.Append(tableName);
            builder.Append(" WHERE ");

            for (var i = 0; i < queryProperties.Count(); i++)
            {
                var item = queryProperties[i];

                if (!string.IsNullOrEmpty(item.LinkingOperator) && i > 0)
                {
                    builder.Append(" " + item.LinkingOperator);
                }

                if (item.PropertyValue == null)
                {
                    builder.Append(string.Format(" {0} {1} ", item.PropertyName, item.QueryOperator));
                }
                else
                {
                    builder.Append(string.Format(" {0} {1} @{0} ", item.PropertyName, item.QueryOperator));
                }

                expando[item.PropertyName] = item.PropertyValue;
            }

            return new QueryResult(builder.ToString().TrimEnd(), expando);
        }

        /// <summary>
        ///     Gets the dynamic query for count.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="expression">The expression.</param>
        /// <typeparam name="T">Value of type T</typeparam>
        /// <returns>A result object with the generated SQL and dynamic PARAMS.</returns>
        public static QueryResult GetCountDynamicQuery<T>(string tableName, Expression<Func<T, bool>> expression)
        {
            var queryProperties = new List<QueryParameter>();
            IDictionary<string, object> expando = new ExpandoObject();
            var builder = new StringBuilder();

            // walk the tree and build up a list of query parameter objects
            // from the left and right branches of the expression tree
            WalkTree(expression.Body, ExpressionType.Default, ref queryProperties);

            // convert the query parms into a SQL string and dynamic property object
            builder.Append("SELECT COUNT(*) FROM ");
            builder.Append(tableName);
            builder.Append(" WHERE ");
            for (var i = 0; i < queryProperties.Count(); i++)
            {
                var item = queryProperties[i];
                var placeHolderName = item.PropertyName + i;

                if (!string.IsNullOrEmpty(item.LinkingOperator) && i > 0)
                {
                    builder.Append(" " + item.LinkingOperator);
                }

                if (item.PropertyValue == null)
                {
                    builder.Append(string.Format(" {0} {1} ", item.PropertyName, item.QueryOperator));
                }
                else
                {
                    builder.Append(string.Format(" {0} {1} @{2} ", item.PropertyName, item.QueryOperator, placeHolderName));
                }

                expando[placeHolderName] = item.PropertyValue;
            }

            return new QueryResult(builder.ToString().TrimEnd(), expando);
        }

        /// <summary>
        /// Get columns.
        /// </summary>
        /// <param name="type">Item of type T</param>
        /// <returns>Array of string with column names</returns>
        public static string[] GetColumns(Type type)
        {
            ////var props = type.GetFilteredProperties();
            PropertyInfo[] props = type.GetProperties();
            var columns = props.Select(x => x.Name).Where(x => x != "Id");
            return columns.ToArray();
        }

        /// <summary>
        /// Walks the tree
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="linkingType">Linkage type</param>
        /// <param name="queryProperties">Query properties</param>
        private static void WalkTree(System.Linq.Expressions.Expression body, ExpressionType linkingType, ref List<QueryParameter> queryProperties)
        {
            if (body is BinaryExpression)
            {
                WalkTree(body as BinaryExpression, linkingType, ref queryProperties);
            }
            else if (body is MethodCallExpression)
            {
                WalkTree(body as MethodCallExpression, linkingType, ref queryProperties);
            }
        }

        /// <summary>
        /// Walks the tree.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="linkingType">Type of the linking.</param>
        /// <param name="queryProperties">The query properties.</param>
        private static void WalkTree(BinaryExpression body, ExpressionType linkingType, ref List<QueryParameter> queryProperties)
        {
            if (body.NodeType != ExpressionType.AndAlso && body.NodeType != ExpressionType.OrElse)
            {
                var propertyName = GetPropertyName(body);
                dynamic propertyValue = GetConstant(body.Right);
                string opr = GetOperator(body.NodeType, propertyValue);
                var link = GetOperator(linkingType);
                object value = null;

                if (body.Right.Type == typeof(DateTime?) || body.Right.Type == typeof(DateTime?))
                {
                    value = Convert.ToDateTime(propertyValue.ToString()).ToString("yyyy-MM-dd hh:mm:ss");
                }
                else
                {
                    value = propertyValue.Value;
                }

                queryProperties.Add(new QueryParameter(link, propertyName, value, opr));
            }
            else
            {
                WalkTree(body.Left, body.NodeType, ref queryProperties);
                WalkTree(body.Right, body.NodeType, ref queryProperties);
            }
        }

        /// <summary>
        /// Walks the tree
        /// </summary>
        /// <param name="body">the body</param>
        /// <param name="linkingType">Type of the linkage</param>
        /// <param name="queryProperties">Query properties</param>
        private static void WalkTree(MethodCallExpression body, ExpressionType linkingType, ref List<QueryParameter> queryProperties)
        {
            switch (body.Method.Name)
            {
                case "Contains":
                    WalkContainsMethod(body, linkingType, ref queryProperties);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Walk contain method
        /// </summary>
        /// <param name="body">the body</param>
        /// <param name="linkingType">Type of the linkage</param>
        /// <param name="queryProperties">Query properties</param>
        private static void WalkContainsMethod(MethodCallExpression body, ExpressionType linkingType, ref List<QueryParameter> queryProperties)
        {
            if (body.Arguments.Count == 1) 
            {
                var exp = body.Object as MemberExpression;
                var propertyName = GetPropertyName(exp);
                dynamic propertyValue = GetConstantForContains(body.Arguments[0]);
                var opr = "LIKE";
                var link = GetOperator(linkingType);
                queryProperties.Add(new QueryParameter(link, propertyName, propertyValue.Value, opr));
            }
            else if (body.Arguments.Count == 2)
            {
                var me2 = body.Arguments[1] as MemberExpression;
                var propertyName = GetPropertyName(me2);
                dynamic propertyValue = GetConstant(body.Arguments[0]);
                var opr = "IN";
                var link = GetOperator(linkingType);
                queryProperties.Add(new QueryParameter(link, propertyName, propertyValue.Value, opr));
            }
        }

        /// <summary>
        /// Gets property name
        /// </summary>
        /// <param name="exp">The expression</param>
        /// <returns>Property name</returns>
        private static string GetPropertyName(MemberExpression exp)
        {
            if (exp.Member.Name == "Value")
            {
                return GetPropertyName(exp.Expression as MemberExpression);
            }

            return exp.Member.Name;
        }

        /// <summary>
        /// Gets constant
        /// </summary>
        /// <param name="exp">The expression</param>
        /// <returns>Constant expression</returns>
        private static ConstantExpression GetConstant(System.Linq.Expressions.Expression exp)
        {
            if (exp is ConstantExpression)
            {
                return exp as ConstantExpression;
            }

            if (exp is MemberExpression)
            {
                if (exp.Type == typeof(string))
                {
                    return System.Linq.Expressions.Expression.Constant(System.Linq.Expressions.Expression.Lambda<Func<string>>(exp).Compile().DynamicInvoke());
                }
                else if (exp.Type == typeof(Guid))
                {
                    return System.Linq.Expressions.Expression.Constant(System.Linq.Expressions.Expression.Lambda<Func<Guid>>(exp).Compile().DynamicInvoke());
                }
                else if (exp.Type == typeof(bool))
                {
                    return System.Linq.Expressions.Expression.Constant(System.Linq.Expressions.Expression.Lambda<Func<bool>>(exp).Compile().DynamicInvoke());
                }
                else if (exp.Type == typeof(Guid?))
                {
                    return System.Linq.Expressions.Expression.Constant(System.Linq.Expressions.Expression.Lambda<Func<Guid?>>(exp).Compile().DynamicInvoke());
                }
                else if (exp.Type == typeof(DateTime))
                {
                    return System.Linq.Expressions.Expression.Constant(System.Linq.Expressions.Expression.Lambda<Func<DateTime>>(exp).Compile().DynamicInvoke());
                }
                else if (exp.Type == typeof(int))
                {
                    return System.Linq.Expressions.Expression.Constant(System.Linq.Expressions.Expression.Lambda<Func<int>>(exp).Compile().DynamicInvoke());
                }

                ////else if (exp.Type == typeof(object))

                return System.Linq.Expressions.Expression.Constant(System.Linq.Expressions.Expression.Lambda<Func<object>>(exp).Compile().DynamicInvoke());
            }

            if (exp is UnaryExpression)
            {
                UnaryExpression ue = exp as UnaryExpression;
                if (ue.IsLiftedToNull)
                {
                    return GetConstant(ue.Operand);
                }
            }

            if (exp is BinaryExpression)
            {
            }

            return null;
        }

        /// <summary>
        /// Gets constants for contains
        /// </summary>
        /// <param name="exp">The expression</param>
        /// <returns>Constant expression</returns>
        private static ConstantExpression GetConstantForContains(System.Linq.Expressions.Expression exp)
        {
            if (exp is ConstantExpression)
            {
                return System.Linq.Expressions.Expression.Constant("%" + (exp as ConstantExpression).Value + "%");
            }

            if (exp is MemberExpression)
            {
                return System.Linq.Expressions.Expression.Constant("%" + System.Linq.Expressions.Expression.Lambda<Func<object>>(exp).Compile().DynamicInvoke() + "%");
            }

            return null;
        }

        /// <summary>
        ///     Gets the name of the property.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <returns>The property name for the property expression.</returns>
        private static string GetPropertyName(BinaryExpression body)
        {
            var propertyName = body.Left.ToString().Split('.')[1];

            if (body.Left.NodeType == ExpressionType.Convert)
            {
                propertyName = propertyName.Replace(")", string.Empty);
            }

            return propertyName;
        }

        /// <summary>
        ///     Gets the operator.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///     The expression types SQL server equivalent operator.
        /// </returns>
        private static string GetOperator(ExpressionType type)
        {
            switch (type)
            {
                case ExpressionType.Equal:
                    return "=";

                case ExpressionType.NotEqual:
                    return "!=";

                case ExpressionType.LessThan:
                    return "<";

                case ExpressionType.GreaterThan:
                    return ">";

                case ExpressionType.LessThanOrEqual:
                    return "<=";

                case ExpressionType.GreaterThanOrEqual:
                    return ">=";

                case ExpressionType.AndAlso:
                case ExpressionType.And:
                    return "AND";

                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    return "OR";

                case ExpressionType.Default:
                    return string.Empty;

                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets operator
        /// </summary>
        /// <param name="type">Expression type</param>
        /// <param name="rightOperand">Constant expression</param>
        /// <returns>String operator</returns>
        private static string GetOperator(ExpressionType type, ConstantExpression rightOperand)
        {
            switch (type)
            {
                case ExpressionType.Equal:
                    return rightOperand.Value == null ? "is null" : "=";

                case ExpressionType.NotEqual:
                    return rightOperand.Value == null ? "is not null" : "!=";

                case ExpressionType.LessThan:
                    return "<";

                case ExpressionType.GreaterThan:
                    return ">";

                case ExpressionType.LessThanOrEqual:
                    return "<=";

                case ExpressionType.GreaterThanOrEqual:
                    return ">=";

                case ExpressionType.AndAlso:
                case ExpressionType.And:
                    return "AND";

                case ExpressionType.Or:
                case ExpressionType.OrElse:
                    return "OR";

                case ExpressionType.Default:
                    return string.Empty;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}