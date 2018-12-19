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
	public partial class employeeLogin : ContentPage
	{
		public employeeLogin ()
		{
			InitializeComponent ();
		}
        // Login button clicked Functionality
        private void empLoginBtn_Clicked(object sender, EventArgs e)
        {
            // empty entries validation
            bool isUserEmpty, isPwdEmpty;
            isUserEmpty = String.IsNullOrEmpty(empEmailInput.Text);
            isPwdEmpty = String.IsNullOrEmpty(empPasswordInput.Text);
            if (isUserEmpty || isPwdEmpty)
            {
                DisplayAlert("Error", "Email or Password cannot be empty", "Try Again");
            }
            else
            {
                Navigation.PushAsync(new employeeDashboard());
            } // end if(isUserEmpty || isPwdEmpty)
        }
    }
    }