using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbCloneApp.Properties;
using System.IO;

namespace DbCloneApp.Repository
{
    class RepositoryImpl : IRepository
    {
        private readonly string connectionString;

        public RepositoryImpl()
        {
            this.connectionString = Resources.connectionString;
        }

        public void BackupDB(string dbName, string path)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string.Format(Resources.BackupDBQuery, dbName, path).Split("GO").ToList().ForEach(c =>
                {
                    using (var command = new SqlCommand(c, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                });
            }
        }

        public void CreateDb(string dbName, string tableName)
        {

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string.Format(Resources.CreateDBQuery, dbName, tableName).Split("GO").ToList().ForEach(c =>
                {
                    using (var command = new SqlCommand(c, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                });
            }
        }

        public void CloneDb(string fromDbName, string toDbName)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string.Format(Resources.CloneDbQuery, fromDbName, toDbName).Split("GO").ToList().ForEach(c =>
                {
                    using (var command = new SqlCommand(c, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                });
            }
        }
    }
}
