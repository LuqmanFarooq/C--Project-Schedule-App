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
        private SQLiteConnection conn;
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
            add_Schedule.date = selectDate.Date;
            add_Schedule.timeFrom = selectFromTime.Time;
            add_Schedule.timeTo = selectToTime.Time;
            conn.Insert(add_Schedule);
            empNameBox.Text = "";

        }

        private void showBtn_Clicked_1(object sender, EventArgs e)
        {
            var data = (from add in conn.Table<Add_Schedule>() select add);
            Datalist.ItemsSource = data;
        }
    }
}