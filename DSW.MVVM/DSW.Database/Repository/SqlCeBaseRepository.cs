using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using ErikEJ.SqlCe;
using System.Linq.Expressions;
using DSW.Core.Utility.Services;
using DSW.Core.Utility.DapperLite;

namespace DSW.Database.Repository
{
    public interface ISqlCeBaseRepository<TDb> where TDb : class
    {
        TDb Get(Expression<Func<TDb, object>> property, object data);
        TDb Get(object data, Dictionary<Expression<Func<TDb, object>>, string> properties);
        IEnumerable<TDb> Gets(Expression<Func<TDb, object>> property, object data);
        IEnumerable<TDb> Gets(object data, Dictionary<Expression<Func<TDb, object>>, string> properties);
        IEnumerable<TDb> Gets(Dictionary<string, object> data, string operatorConcat, Dictionary<Expression<Func<TDb, object>>, string> properties);
        IEnumerable<TDb> Gets(SqlCePredicateList<TDb> predicates);
        IEnumerable<TDb> GetAll();
        void BulkInsert(List<TDb> values);
        void SingleInsert(SqlCeTransaction tran, TDb value);
        void SingleUpdate(SqlCeTransaction tran, Expression<Func<TDb, object>> primaryKey, TDb value);
        void SingleInsertTransaction(TDb value);
        void SingleInsertTransaction(Expression<Func<TDb, object>> primaryKeyProperty, TDb value);
        void SingleUpdateTransaction(Expression<Func<TDb, object>> primaryKeyProperty, TDb value);
        void DeleteAll();
        void Delete(Expression<Func<TDb, object>> property, object data, SqlCeTransaction tran);
        bool HaveAnyData();
        void DeleteAll(SqlCeTransaction tran, Dictionary<string, object> data, string operatorConcat, Dictionary<Expression<Func<TDb, object>>, string> properties);
        void DeleteAll(SqlCeTransaction tran, SqlCePredicateList<TDb> predicates);
    }

    public class SqlCeBaseRepository<TDb> where TDb : class
    {
        public SqlCeDatabase Database;


        private string GetTableName()
        {
            return typeof(TDb).Name;
        }

        public SqlCeBaseRepository(SqlCeDatabase database)
        {
            Database = database;
        }

        public virtual IEnumerable<TDb> GetAll()
        {
            return Database.All<TDb>();
        }

        public virtual IEnumerable<TDb> Gets(Expression<Func<TDb, object>> property, object data)
        {
            return Database.All<TDb>(property, data);
        }

        public virtual IEnumerable<TDb> Gets(object data, Dictionary<Expression<Func<TDb, object>>, string> properties)
        {
            return Database.All<TDb>(data, properties);
        }

        public virtual IEnumerable<TDb> Gets(Dictionary<string, object> data, string operatorConcat,
        Dictionary<Expression<Func<TDb, object>>, string> properties)
        {
            return Database.AllDictionary<TDb>(data, operatorConcat, properties);
        }

        public virtual IEnumerable<TDb> Gets(SqlCePredicateList<TDb> predicates)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            Dictionary<Expression<Func<TDb, object>>, string> properties = new Dictionary<Expression<Func<TDb, object>>, string>();
            string operatorConcat = predicates.OperatorConcat;

            int idx = 0;
            foreach (var item in predicates.Predicates)
            {
                properties.Add(item.Property, item.Operator);
                data.Add(string.Format("param{0}", idx), item.Data);
                idx++;
            }

            return Database.AllDictionary<TDb>(data, operatorConcat, properties);
        }

        public virtual TDb Get(Expression<Func<TDb, object>> property, object data)
        {
            return Database.Get<TDb>(property, data);
        }

        public virtual TDb Get(object data, Dictionary<Expression<Func<TDb, object>>, string> properties)
        {
            return Database.Get<TDb>(data, properties);
        }

        public virtual void BulkInsert(List<TDb> values)
        {
            SqlCeConnection conn = Database.GetConnection();
            var getDestinationTable = GetTableName();
            var sqlBulk = new SqlCeBulkCopy(conn);
            sqlBulk.DestinationTableName = getDestinationTable;
            var test = values.ToDataTable();
            sqlBulk.WriteToServer(values.ToDataTable());
        }

        public virtual void SingleInsert(SqlCeTransaction tran, TDb value)
        {
            try
            {
                string tableName = Database.GetTableName(value);
                SqlCeConnection conn = Database.GetConnection();
                conn.Insert(tran, tableName, value);
            }
            catch (Exception e)
            {
                Database.ExceptionHandler(e);
                if (Database.m_throwExceptions) throw;
            }
        }

        public virtual void SingleUpdate(SqlCeTransaction tran, Expression<Func<TDb, object>> primaryKeyProperty, TDb value)
        {
            try
            {
                string tableName = Database.GetTableName(value);
                var primaryKey = primaryKeyProperty.GetNameProperty();
                SqlCeConnection conn = Database.GetConnection();
                conn.Update(tran, tableName, primaryKey, value);
            }
            catch (Exception e)
            {
                Database.ExceptionHandler(e);
                if (Database.m_throwExceptions) throw;
            }
        }

        public virtual void SingleInsertTransaction(TDb value)
        {
            Database.Insert(value);
        }

        public virtual void SingleInsertTransaction(Expression<Func<TDb, object>> primaryKeyProperty, TDb value)
        {
            var primaryKey = primaryKeyProperty.GetNameProperty();
            Database.Insert(primaryKey, value);
        }

        public virtual void SingleUpdateTransaction(Expression<Func<TDb, object>> primaryKeyProperty, TDb value)
        {
            var primaryKey = primaryKeyProperty.GetNameProperty();
            Database.Update(primaryKey, value);
        }

        public virtual bool HaveAnyData()
        {
            return Database.HaveAnyData<TDb>() == 0 ? false : true;
        }

        public virtual void DeleteAll()
        {
            Database.DeleteAll<TDb>();
        }

        public virtual void Delete(Expression<Func<TDb, object>> property, object data, SqlCeTransaction tran)
        {
            Database.Delete<TDb>(property, data, tran);
        }


        public virtual void DeleteAll(SqlCeTransaction tran,
        Dictionary<string, object> data, string operatorConcat,
        Dictionary<Expression<Func<TDb, object>>, string> properties)
        {
            Database.DeleteAllDictionary<TDb>(tran, data, operatorConcat, properties);
        }

        public virtual void DeleteAll(SqlCeTransaction tran,
            SqlCePredicateList<TDb> predicates)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            Dictionary<Expression<Func<TDb, object>>, string> properties = new Dictionary<Expression<Func<TDb, object>>, string>();
            string operatorConcat = predicates.OperatorConcat;

            int idx = 0;
            foreach (var item in predicates.Predicates)
            {
                properties.Add(item.Property, item.Operator);
                data.Add(string.Format("param{0}", idx), item.Data);
                idx++;
            }

            Database.DeleteAllDictionary<TDb>(tran, data, operatorConcat, properties);
        }
    }
}
