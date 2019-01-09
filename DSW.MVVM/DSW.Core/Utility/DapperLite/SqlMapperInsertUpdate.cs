using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DSW.Core.Utility.DapperLite
{
    public static partial class SqlMapper
    {
        /// <summary>
        /// Inspired by Dapper.Rainbow.
        /// </summary>
        public static void Insert(this IDbConnection connection, IDbTransaction transaction, string tableName, object param)
        {
            List<string> paramNames = GetParamNames(param).ToList();

            string cols = string.Join(",", paramNames.ToArray());
            string colsParams = string.Join(",", paramNames.Select(p => "@" + p).ToArray());
            string sql = "INSERT " + string.Format("[{0}]",tableName) + " (" + cols + ") VALUES (" + colsParams + ")";

            int result = connection.Execute(sql, param, transaction);

            if (result <= 0)
                throw new ApplicationException("Return value of INSERT should be greater than 0. An error has occurred with the INSERT.");
        }

        public static void Insert(this IDbConnection connection, IDbTransaction transaction, string tableName, string primaryKey, object param)
        {
            List<string> paramNames = GetParamNames(param).ToList();

            string cols = string.Join(",", paramNames.Where(n => n != primaryKey).ToArray());
            string colsParams = string.Join(",", paramNames.Where(n => n != primaryKey).Select(p => "@" + p).ToArray());
            string sql = "INSERT " + string.Format("[{0}]", tableName) + " (" + cols + ") VALUES (" + colsParams + ")";

            int result = connection.Execute(sql, param, transaction);

            if (result <= 0)
                throw new ApplicationException("Return value of INSERT should be greater than 0. An error has occurred with the INSERT.");
        }

        /// <summary>
        /// Inspired by Dapper.Rainbow.
        /// </summary>
        public static void Update(this IDbConnection connection, IDbTransaction transaction, string tableName, string primaryKey, object param)
        {
            List<string> paramNames = GetParamNames(param).ToList();

            StringBuilder builder = new StringBuilder();
            builder.Append("UPDATE ").Append(string.Format("[{0}]",tableName)).Append(" SET ");
            builder.AppendLine(string.Join(",", paramNames.Where(n => n != primaryKey).Select(p => p + "= @" + p).ToArray()));
            builder.Append(" WHERE "+primaryKey+" = @"+primaryKey);
            string sql = builder.ToString();

            int result = connection.Execute(sql, param, transaction);

            if (result <= 0)
                throw new ApplicationException("Return value of UPDATE should be greater than 0. An error has occurred with the INSERT.");
        }
    }
}
