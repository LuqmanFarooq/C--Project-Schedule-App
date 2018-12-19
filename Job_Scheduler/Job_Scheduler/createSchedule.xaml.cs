using Job_Scheduler.database_model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Job_Scheduler
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class createSchedule : ContentPage
	{
        // sqlite connection varaible
        public SQLiteConnection conn;
        // database object
        public Add_Schedule add_Schedule;
        
        public createSchedule ()
		{
			InitializeComponent ();
            // getting database connection using platform specific interface
            conn = DependencyService.Get<ISQLite>().GetConnection();
            // creating table in the database
            conn.CreateTable<Add_Schedule>();
		}
        // when add button is clicked
        private void addScheduleBtn_Clicked(object sender, EventArgs e)
        {
            // new database object
            add_Schedule = new Add_Schedule();
            // binding data
            add_Schedule.name = empNameBox.Text;
            add_Schedule.date = selectDate.Date.ToShortDateString();   
            add_Schedule.timeFrom = string.Format("{0:D2}:{1:D2}", selectFromTime.Time.Hours, selectFromTime.Time.Minutes);
            add_Schedule.timeTo = string.Format("{0:D2}:{1:D2}", selectToTime.Time.Hours, selectToTime.Time.Minutes);
            // insert into add-schedule table.
            conn.Insert(add_Schedule);
            // reset the name box to empty after adding record
            empNameBox.Text = "";

        }
        

    }
}