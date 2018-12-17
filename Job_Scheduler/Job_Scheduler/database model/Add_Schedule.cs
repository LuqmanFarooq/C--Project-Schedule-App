using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Job_Scheduler.database_model
{
   public class Add_Schedule
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string fromLbl { get; set; }
        public String timeFrom { get; set; }
        public String timeTo { get; set; }
       
        

    }
}
