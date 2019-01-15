using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using DSW.Core.Utility.DapperLite;
using DSW.Database.Repository;

namespace DSW.Database
{
    public interface IUnitOfWork : IDisposable
    {
        IAppSettingRepository AppSettingRepository { get; }
        IMstItemRepository MstItemRepository { get; }

        SqlCeDatabase Database { get; }
        SqlCeConnection SqlConnection { get; }
        SqlCeTransaction BeginTransaction();
        SqlCeTransaction GetTransaction();
        void EndTransaction();
        void Rollback();
        void DisposeTransaction();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private string sdfPath = ("Data Source=" + (System.IO.Path.GetDirectoryName(
                new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath)) +
                "\\AppDatabase.sdf;Persist Security Info=False;");

        public SqlCeDatabase Database { get; private set; }
        public SqlCeConnection SqlConnection { get; private set; }
        public SqlCeTransaction Transaction { get; private set; }

        public IAppSettingRepository AppSettingRepository { get; private set; }
        public IMstItemRepository MstItemRepository { get; private set; }

        public UnitOfWork() {
            SqlConnection = new SqlCeConnection(sdfPath);
            Database = new SqlCeDatabase(SqlConnection);
            Database.Init();

            AppSettingRepository = new AppSettingRepository(Database);
            MstItemRepository = new MstItemRepository(Database);
        }

        public SqlCeTransaction BeginTransaction()
        {
            Transaction = SqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);
            return Transaction;
        }

        public SqlCeTransaction GetTransaction()
        {
            if (this.Transaction == null)
            {
                return BeginTransaction();
            }
            return this.Transaction;
        }

        public void DisposeTransaction()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
                Transaction = null;
            }

        }

        public void EndTransaction()
        {
            Transaction.Commit();
            DisposeTransaction();
        }

        public void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                DisposeTransaction();
            }
        }

        #region IDisposable Members
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeTransaction();
                if (SqlConnection != null)
                {
                    SqlConnection.Dispose();
                    SqlConnection = null;
                }
            }
        }

        #endregion
    }
}
