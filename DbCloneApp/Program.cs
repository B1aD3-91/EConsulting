using System;

using DbCloneApp.Repository;

namespace DbCloneApp
{
    class Program
    {
        private static readonly IRepository repo = new RepositoryImpl();
        static void Main(string[] args)
        {
            repo.CreateDb("TESTDB", "test_table");
            repo.CloneDb("TESTDB", "CLONEDTESTDB");
            Console.ReadKey();
        }
    }
}
