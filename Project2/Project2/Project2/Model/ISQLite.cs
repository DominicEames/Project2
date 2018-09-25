using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project2.Model
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
