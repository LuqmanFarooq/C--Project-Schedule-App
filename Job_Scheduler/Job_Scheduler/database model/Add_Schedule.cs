using System;
using System.Collections.Generic;
using System.Text;

namespace Job_Scheduler.database_model
{
   public class Add_Schedule
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public DateTimeKind timeFrom { get; set; }
        public DateTimeKind timeTo { get; set; }
       
        

    }
}
