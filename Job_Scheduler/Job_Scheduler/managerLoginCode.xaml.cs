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
        // precoded code for testing ------------------------------------------------------------
        /*string preCodedCode ="6689";
        bool emptUserCode;
        string userCode;*/
        //---------------------------------------------------------------------------------------
        public managerLoginCode ()
		{
			InitializeComponent ();
		}

        private void sendCodeBtn_Clicked(object sender, EventArgs e)
        {
            // for precoded code testing

            //--------------------------------------------------------------------------------------
            /*emptUserCode = String.IsNullOrEmpty(codeInput.Text);
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
                DisplayAlert("Error", "Wrong Code", "Try again");*/
            //--------------------------------------------------------------------------------------
            // empty entries validation
            bool isCodeEmpty;
            isCodeEmpty = String.IsNullOrEmpty(codeInput.Text);
            if (isCodeEmpty)
            {
                DisplayAlert("Error", "Cannot be empty", "Try again");
            }
            else
            {
                // use navigation service to go to manager Login page
                Navigation.PushAsync(new managerLogin());
            } // end if(isCodeEmpty)
        }
    }
}