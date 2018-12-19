using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Job_Scheduler
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        // Login as manager button navigates to manager login page
        private void mngrLoginBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new managerLoginCode());
        }
        // Login as employee button navigates to employee login page
        private void empLoginBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new employeeLogin());
        }
    }
}
