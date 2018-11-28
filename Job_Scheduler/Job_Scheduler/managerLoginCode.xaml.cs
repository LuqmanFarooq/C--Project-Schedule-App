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
	public partial class managerLoginCode : ContentPage
	{
        string preCodedCode ="6689";
        bool emptUserCode;
        string userCode;
    
        public managerLoginCode ()
		{
			InitializeComponent ();
		}

        private void sendCodeBtn_Clicked(object sender, EventArgs e)
        {
            emptUserCode = String.IsNullOrEmpty(codeInput.Text);
            userCode = codeInput.Text;
            if(emptUserCode)
            {
                DisplayAlert("Error", "Can not be empty", "Try again");
            }
            else if (userCode.Equals(preCodedCode))
            {
                Navigation.PushAsync(new managerLogin());
            }
            else
                DisplayAlert("Error", "Wrong Code", "Try again");
        }
    }
}