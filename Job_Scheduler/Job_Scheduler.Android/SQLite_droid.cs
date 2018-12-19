using Job_Scheduler.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLite_droid))]
namespace Job_Scheduler.Droid
{
    // sqlite android platform specific code 
    public class SQLite_droid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "mydatabase.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbPath, dbName);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}
