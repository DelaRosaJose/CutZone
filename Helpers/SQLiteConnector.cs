using CutZone.Models;
using SQLite;

namespace CutZone.Helpers
{
    public class SQLiteConnector
    {
        public SQLiteConnector()
        {
            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Main.db");

            var db = new SQLiteAsyncConnection(databasePath);

            db.CreateTableAsync<User>();

            
        }
    }
}
