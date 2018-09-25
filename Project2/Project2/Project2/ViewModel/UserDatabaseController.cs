using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using Project2.Model;


namespace Project2.ViewModel
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;
        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Login>();
        }
        public Login GetUser()
        {
            lock (locker)
            {
                if(database.Table<Login>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Login>().First();
                }
            }
        }

        public int SaveUser(Login user)
        {
            lock (locker)
            {
                if(user.Id !=0)
                {
                    database.Update(user);
                    return user.Id;

                }
                else
                {
                    return database.Insert(user);
                }
            }
        }
        public int DeleteUser(int id)
        {
            lock (locker)
            {
                return database.Delete<Login>(id);
            }
        }
    }
}
