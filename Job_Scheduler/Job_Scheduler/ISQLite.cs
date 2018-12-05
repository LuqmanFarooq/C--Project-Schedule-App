using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job_Scheduler
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();   
    }
}
