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

        private void mngrLoginBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new managerLoginCode());
        }

        private void empLoginBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new employeeLogin());
        }
    }
}
