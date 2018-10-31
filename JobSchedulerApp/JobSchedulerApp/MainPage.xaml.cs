using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JobSchedulerApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            bool isUserEmpty, isPwdEmpty;
            isUserEmpty = String.IsNullOrEmpty(entUser.Text);
            isPwdEmpty = String.IsNullOrEmpty(entPassword.Text);

            if (isUserEmpty || isPwdEmpty)
            {
                // message to user not to be awkward
            }
            else
            {
                msg.Text = "you have successfully logged in";
                // check user/pwd hash keys etc
                // navigate to new page
                // use navigation service to go to ZodiacPage
                //Navigation.PushAsync(new ZodiacSigns());
            } // end if(isUserEmpty || isPwdEmpty)


        } //end login clicked

    } // end partial class
}
