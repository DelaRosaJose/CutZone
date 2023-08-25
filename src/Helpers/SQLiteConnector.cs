using CutZone.Models;
using SQLite;

namespace CutZone.Helpers
{
    public class SQLiteConnector
    {
        public static SQLiteAsyncConnection db;
        public SQLiteConnector()
        {
            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Main.db");

            db = new SQLiteAsyncConnection(databasePath);

            db.CreateTableAsync<User>();

            //db.InsertAsync(new User() {Name = "Jose", Password = "123" });
            
            
        }
    }
}
