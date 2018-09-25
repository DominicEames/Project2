using Project2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Project2.Model
{
        class SQLite_Android : ISQLite
        {
            public SQLite_Android() { }
            public SQLite.SQLiteConnection GetConnection()
            {
                var sqliteFileName = "TestDB.db3";
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var path = Path.Combine(documentsPath, sqliteFileName);
                var conn = new SQLite.SQLiteConnection(path);

                return conn;
            }
        }
    
}
