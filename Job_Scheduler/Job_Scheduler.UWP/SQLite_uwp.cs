using Job_Scheduler.UWP;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLite_uwp))]
namespace Job_Scheduler.UWP
{
    //sqlite uwp platform specific code
    public class SQLite_uwp : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "mydatabase.sqlite";
            var dbPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var path = Path.Combine(dbPath, dbName);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}
