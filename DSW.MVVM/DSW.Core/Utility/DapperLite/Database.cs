using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Linq.Expressions;
using DSW.Core.Utility.Services;

namespace DSW.Core.Utility.DapperLite
{
    public delegate void DapperLiteException(Exception e);

    /// <summary>
    /// A container for a database. Assumes all tables have an Id column named Id.
    /// </summary>
    /// <typeparam name="TId">The .NET equivalent type of the Id column (typically int or Guid).</typeparam>
    public abstract class Database
    {
        private readonly IDbConnection m_connection;
        private Dictionary<string, string> m_tableNameMap;
        private readonly DapperLiteException m_exceptionHandler;
        public readonly bool m_throwExceptions;

   
        protected Database(IDbConnection connection)
        {
            if (connection == null) throw new ArgumentException("Connection cannot be null");

            m_connection = connection;
            m_throwExceptions = true;
        }

        /// <summary>
        /// Provides advanced configuration for the behaviour of the class when Exceptions are encountered.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="exceptionHandler">Deletegate which will receive any caught Exception objects.</param>
        /// <param name="throwExceptions">Indicate whether a caught exception should be re-thrown.</param>
        protected Database(IDbConnection connection, DapperLiteException exceptionHandler, bool throwExceptions)
        {
            if (connection == null) throw new ArgumentException("Connection cannot be null");

            m_connection = connection;
            m_exceptionHandler = exceptionHandler;
            m_throwExceptions = throwExceptions;
        }

        /// <summary>
        /// This method must be called to initialize the table name map, used to map type names to table names.
        /// </summary>
        public void Init()
        {
            m_tableNameMap = GetTableNameMap();
        }

        /// <summary>
        /// Wrapper method for the delegate so we don't throw an exception if the delegate is null.
        /// </summary>
        public void ExceptionHandler(Exception e)
        {
            if (m_exceptionHandler != null) m_exceptionHandler(e);
        }

        protected IDbConnection GetConnection()
        {
            if (m_connection.State != ConnectionState.Open)
            {
                m_connection.Open();
            }

            return m_connection;
        }

        private static string Pluralize(string s)
        {
            char lastchar = s[s.Length - 1];

            if (lastchar == 'y')
            {
                return s.Remove(s.Length - 1, 1) + "ies";
            }

            if (lastchar == 's')
            {
                return s;
            }

            return s + "s";
        }

        /// <summary>
        /// This abstract method must be implemented by deriving types as
        /// the implementation is specific to the SQL vendor (and possibly version).
        /// </summary>
        protected abstract Dictionary<string, string> GetTableNameMap();

        /// <summary>
        /// First checks if there is an exact match between type name and table name.
        /// Then checks if there is a match between the pluralized type name and table name.
        /// </summary>
        private string GetTableName(MemberInfo type)
        {
            string tableName;
            string typeName = type.Name;

            // First see if the type name exactly matches a table name.
            if (m_tableNameMap.TryGetValue(typeName, out tableName))
            {
                return tableName;
            }

            // Then check if when the type name is pluralized, it matches a table name.
            if (m_tableNameMap.TryGetValue(Pluralize(typeName), out tableName))
            {
                return tableName;
            }

            throw new Exception(string.Format("Cannot match the type name {0} to any table", typeName));
        }

        public string GetTableName(object obj)
        {
            return GetTableName(obj.GetType());
        }

        /// <summary>
        /// A wrapper that uses the internally cached connection.
        /// </summary>
        public int Execute(string sql, object param, IDbTransaction transaction)
        {
            try
            {
                return GetConnection().Execute(sql, param, transaction);
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return -1;
        }

        /// <summary>
        /// A wrapper that uses the internally cached connection.
        /// </summary>
        public int Execute(string sql)
        {
            return Execute(sql, null, null);
        }

        /// <summary>
        /// A wrapper that uses the internally cached connection.
        /// </summary>
        public IEnumerable<T> Query<T>(string sql, object param)
        {
            try
            {
                return GetConnection().Query<T>(sql, param);
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return new List<T>();
        }

        /// <summary>
        /// A wrapper that uses the internally cached connection.
        /// </summary>
        public IEnumerable<T> Query<T>(string sql)
        {
            return Query<T>(sql, null);
        }

        /// <summary>
        /// Gets a single instance of a type by specifying the row Id.
        /// </summary>
        /// <returns>A specific instance of the specified type, or the default value for the type.</returns>
        //public T Get<T>(Expression<Func<T, object>> property,  object data)
        //{
        //    try
        //    {
        //        string propertyName = property.GetNameProperty();
        //        string tableName = GetTableName(typeof(T));
        //        return GetConnection().Query<T>("SELECT * FROM " + tableName + " WHERE "+propertyName+" = @id", new { id = data }).FirstOrDefault();
        //    }
        //    catch (Exception e)
        //    {
        //        ExceptionHandler(e);
        //        if (m_throwExceptions) throw;
        //    }

        //    return default(T);
        //}

        /// <summary>
        /// Gets a single instance of a type. Filters by a single column.
        /// </summary>
        /// <param name="columnName">Used to generate a WHERE clause.</param>
        /// <param name="data">Input parameter for the WHERE clause.</param>
        /// <returns>A specific instance of the specified type, or the default value for the type.</returns>
        public T Get<T>(Expression<Func<T, object>> property, object data)
        {
            try
            {
                return All<T>(property, data).FirstOrDefault();
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return default(T);
        }

        public T Get<T>(object data, Dictionary<Expression<Func<T, object>>, string> properties)
        {
            try
            {
                return All<T>(data,properties).FirstOrDefault();
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return default(T);
        }

        /// <summary>
        /// Gets all records in the table matching the supplied type after applying the supplied filter
        /// in a WHERE clause.
        /// </summary>
        /// <param name="columnName">Used to generate a WHERE clause.</param>
        /// <param name="data">Input parameter for the WHERE clause.</param>
        /// <returns>All records in the table matching the supplied type.</returns>
        public IEnumerable<T> All<T>(Expression<Func<T, object>> property, object data)
        {
            try
            {
                string tableName = GetTableName(typeof(T));
                string propertyName = property.GetNameProperty();
                string sql = String.Format("SELECT * FROM [{0}] WHERE {1} = @param", tableName, propertyName);
                return GetConnection().Query<T>(sql, new { param = data });
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return new List<T>();
        }


        public IEnumerable<T> All<T>(object data, Dictionary<Expression<Func<T, object>>, string> properties)
        {
            try
            {
                string tableName = GetTableName(typeof(T));


                int index = 0;
                string sqlWhere = string.Empty;
                foreach (var property in properties)
                {
                    if (index != properties.Count - 1)
                    {
                        sqlWhere = sqlWhere + string.Format("{0} {1} @param{2} AND ", property.Key.GetNameProperty(), property.Value, index);
                    }else{
                        sqlWhere = sqlWhere + string.Format("{0} {1} @param{2}", property.Key.GetNameProperty(), property.Value, index);
                    }

                    index++;
                }


                string sql = String.Format("SELECT * FROM [{0}] WHERE {1}", tableName, sqlWhere);
                return GetConnection().Query<T>(sql, data );
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return new List<T>();
        }


        public IEnumerable<T> AllDictionary<T>(Dictionary<string,object> data, 
        string operatorConcat,    
        Dictionary<Expression<Func<T, object>>, string> properties)
        {
            try
            {
                string tableName = GetTableName(typeof(T));


                int index = 0;
                string sqlWhere = string.Empty;
                foreach (var property in properties)
                {
                    if (index != properties.Count - 1)
                    {
                        sqlWhere = sqlWhere + string.Format("{0} {1} @param{2} "+operatorConcat+" ", property.Key.GetNameProperty(), property.Value, index);
                    }
                    else
                    {
                        sqlWhere = sqlWhere + string.Format("{0} {1} @param{2}", property.Key.GetNameProperty(), property.Value, index);
                    }

                    index++;
                }


                string sql = String.Format("SELECT * FROM [{0}] WHERE {1}", tableName, sqlWhere);
                return GetConnection().QueryDictionary<T>(sql, data);
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return new List<T>();
        }

        /// <summary>
        /// Gets all records in the table matching the supplied type.
        /// </summary>
        /// <returns>All records in the table matching the supplied type.</returns>
        public IEnumerable<T> All<T>()
        {
            try
            {
                string tableName = GetTableName(typeof(T));
                return GetConnection().Query<T>(string.Format("SELECT * FROM [{0}]", tableName));
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return new List<T>();
        }


        public int DeleteAll<T>()
        {
            try
            {
                string tableName = GetTableName(typeof(T));
                var result =  GetConnection().Execute(string.Format("DELETE FROM [{0}]",tableName));
                return result;
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return 0;
        }


        public int HaveAnyData<T>()
        {
            try
            {
                string tableName = GetTableName(typeof(T));
                return GetConnection().Query<int>(string.Format("SELECT Count(1) FROM [{0}]", tableName)).FirstOrDefault();
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return 0;
        }

        public int Delete<T>(Expression<Func<T, object>> property, object data, IDbTransaction transaction)
        {
            try
            {
                string tableName = GetTableName(typeof(T));
                string propertyName = property.GetNameProperty();
                var result = GetConnection().Execute(string.Format("DELETE FROM [{0}] WHERE {1} = @id", tableName, propertyName), new { id = data }, transaction);
                return result;
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return 0;
        }


        public int DeleteAllDictionary<T>(IDbTransaction transaction, 
        Dictionary<string, object> data,
        string operatorConcat,
        Dictionary<Expression<Func<T, object>>, string> properties)
        {
            try
            {
                string tableName = GetTableName(typeof(T));


                int index = 0;
                string sqlWhere = string.Empty;
                foreach (var property in properties)
                {
                    if (index != properties.Count - 1)
                    {
                        sqlWhere = sqlWhere + string.Format("{0} {1} @param{2} " + operatorConcat + " ", property.Key.GetNameProperty(), property.Value, index);
                    }
                    else
                    {
                        sqlWhere = sqlWhere + string.Format("{0} {1} @param{2}", property.Key.GetNameProperty(), property.Value, index);
                    }

                    index++;
                }


                string sql = String.Format("DELETE FROM [{0}] WHERE {1}", tableName, sqlWhere);
                var result = GetConnection().ExecuteDictionary(sql, data, transaction);
                return result;
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }

            return 0;
        }



        /// <summary>
        /// Inserts the supplied object into the database. Infers table name from type name.
        /// </summary>
        public virtual void Insert(object obj)
        {
            try
            {
                string tableName = GetTableName(obj);
                GetConnection().Insert(null, tableName, obj);
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }
        }

        /// <summary>
        /// Updates the supplied object. Infers table name from type name.
        /// </summary>
        public virtual void Update(string primaryKey, object obj)
        {
            try
            {
                string tableName = GetTableName(obj);
                GetConnection().Update(null, tableName, primaryKey, obj);
            }
            catch (Exception e)
            {
                ExceptionHandler(e);
                if (m_throwExceptions) throw;
            }
        }
    }
}
