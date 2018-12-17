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
        public SQLiteConnection conn;
        public Add_Schedule add_Schedule;
        
        public createSchedule ()
		{
			InitializeComponent ();
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Add_Schedule>();
		}
        private void addScheduleBtn_Clicked(object sender, EventArgs e)
        {
            add_Schedule = new Add_Schedule();
            add_Schedule.name = empNameBox.Text;
            add_Schedule.date = selectDate.Date.ToShortDateString();    
            add_Schedule.timeFrom = string.Format("{0:D2}:{1:D2}", selectFromTime.Time.Hours, selectFromTime.Time.Minutes);
            add_Schedule.timeTo = string.Format("{0:D2}:{1:D2}", selectToTime.Time.Hours, selectToTime.Time.Minutes);
            conn.Insert(add_Schedule);
            empNameBox.Text = "";

        }
        

    }
}