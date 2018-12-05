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

        private void empLoginBtn_Clicked(object sender, EventArgs e)
        {
            bool isUserEmpty, isPwdEmpty;
            isUserEmpty = String.IsNullOrEmpty(empEmailInput.Text);
            isPwdEmpty = String.IsNullOrEmpty(empPasswordInput.Text);
            
            if (isUserEmpty || isPwdEmpty)
            {
                DisplayAlert("Error", "Email or Password cannot be empty", "Try Again");
            }
            else
            {
                // check user/pwd hash keys etc
                // navigate to new page
                Navigation.PushAsync(new employeeDashboard());
            } // end if(isUserEmpty || isPwdEmpty)
        }
    }
    }