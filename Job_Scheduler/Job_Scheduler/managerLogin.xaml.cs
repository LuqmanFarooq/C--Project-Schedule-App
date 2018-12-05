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
	public partial class managerLogin : ContentPage
	{
		public managerLogin ()
		{
			InitializeComponent ();
		}

        private void mngrLoginBtn_Clicked(object sender, EventArgs e)
        {
            bool isUserEmpty, isPwdEmpty;
            isUserEmpty = String.IsNullOrEmpty(mngrEmailInput.Text);
            isPwdEmpty = String.IsNullOrEmpty(mngrPasswordInput.Text);

            if (isUserEmpty || isPwdEmpty)
            {
                DisplayAlert("Error", "Email or Password cannot be empty", "Try Again");
            }
            else
            {
                // check user/pwd hash keys etc
                // navigate to new page
                // use navigation service to go to ZodiacPage
                Navigation.PushAsync(new managerDashboard());
            } // end if(isUserEmpty || isPwdEmpty)
        }
    }
}