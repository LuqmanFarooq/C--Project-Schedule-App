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

        private void createBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new createSchedule());
        }

        private void ShowBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DataList());
        }
    }
}