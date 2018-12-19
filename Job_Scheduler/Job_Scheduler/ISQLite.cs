using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job_Scheduler
{
    // interface to get connection
    public interface ISQLite
    {
        SQLiteConnection GetConnection();   
    }
}
