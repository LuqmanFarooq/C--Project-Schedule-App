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
	public partial class employeeDashboard : ContentPage
	{
		public employeeDashboard ()
		{
			InitializeComponent ();
		}
        // show schedule button click event
        private void ShowBtn_Clicked(object sender, EventArgs e)
        {
            // navigates to datalist page which shows all the records in a list view
            Navigation.PushAsync(new DataList());
        }
    }
}