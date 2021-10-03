namespace DbCloneApp
{
    public interface IRepository
    {
        public void BackupDB(string dbName, string path);
        public void CreateDb(string dbName, string tableName);
        public void CloneDb(string fromDbName, string toDbName);
    }
}
