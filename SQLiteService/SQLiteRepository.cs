using SQLite;
using System.Linq.Expressions;

namespace SQLiteService
{
    // All the code in this file is included in all platforms.
    public class SQLiteRepository
    {
        private static SQLiteConnection databaseMain;

        public SQLiteRepository(Type[] tableTypes)
        {
            //foreach (Type tableType in tableTypes)
            //    ConnMain.CreateTable(tableType);
            ConnMain.CreateTables(CreateFlags.None, tableTypes);
        }

        public static SQLiteConnection ConnMain
        {
            get
            {
                if (databaseMain == default)
                    ConnRestartMain();
                return databaseMain;
            }
        }

        private static void ConnRestartMain() => databaseMain = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Main.db"), storeDateTimeAsTicks: false);


        public void UpdateProperties<T, J>(T SetResult, J Model)
        {
            foreach (var property in SetResult.GetType().GetProperties())
            {
                var value = property.GetValue(SetResult, null);
                property.SetValue(Model, value);
            }
        }

        public TableQuery<T> GetTableAll<T>() where T : new() => ConnMain.Table<T>();
        public TableQuery<T> GetList<T>(Expression<Func<T, bool>> predExpr) where T : new() => ConnMain.Table<T>().Where(predExpr);
        public T GetById<T>(object pk) where T : new() => ConnMain.Find<T>(pk);
        public T GetFirsOrDefault<T>(Expression<Func<T, bool>> predExpr) where T : new() => ConnMain.Table<T>().FirstOrDefault(predExpr);
        public int Delete<T>(Expression<Func<T, bool>> predExpr) where T : new() => ConnMain.Table<T>().Delete(predExpr);
        public int Delete<T>() where T : new() => ConnMain.Table<T>().Delete(x => true);
        public bool Any<T>(Expression<Func<T, bool>> predExpr) where T : new() => ConnMain.Table<T>().Take(1).Count(predExpr) > 0;
        public bool Any<T>() where T : new() => ConnMain.Table<T>().Take(1).Count() > 0;
        public int Count <T>() where T : new() => ConnMain.Table<T>().Count();
        public int Count<T>(Expression<Func<T, bool>> predExpr) where T : new() => ConnMain.Table<T>().Count(predExpr);

        public static int SaveItem<T>(T entity) where T : new() => ConnMain.InsertOrReplace(entity, typeof(T));
        public int InsertAll<T>(IEnumerable<T> l) where T : new() => ConnMain.InsertAll(l, typeof(T));

        public T CreateNotExists<T>(Expression<Func<T, bool>> predExpr, Func<T> entity) where T : new()
        {
            T objInDatabase = GetFirsOrDefault<T>(predExpr);
            if (objInDatabase == null)
            {
                var obj = entity();
                ConnMain.InsertOrReplace(obj, typeof(T));
                return obj;
            }
            else
                return objInDatabase;
        }

        public void Dispose()
        {
            ConnMain.Dispose();
        }

    }

}