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

        private void ShowBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DataList());
        }
    }
}