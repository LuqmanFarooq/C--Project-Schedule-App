using Job_Scheduler.database_model;
using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Job_Scheduler
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class managerDashboard : ContentPage
	{
        public managerDashboard ()
		{
			InitializeComponent ();

		}
        // create schedule button clicked event take to new page with add schedule functionality
        private void createBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new createSchedule());
        }
        // show schedule button shows schedules
        private void ShowBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DataList());
        }
        // delete schedule button shows all schedules with id and provides functionality of deleting schedule by entrting id associated with it
        private void deleteBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeleteSchedule());
        }
    }
}