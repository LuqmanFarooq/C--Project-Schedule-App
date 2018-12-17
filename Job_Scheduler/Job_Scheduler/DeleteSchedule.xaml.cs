using System;
using SQLite;
using Job_Scheduler.database_model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Plugin.Toast;
namespace Job_Scheduler
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeleteSchedule : ContentPage
	{
        public SQLiteConnection conn;
        public DeleteSchedule ()
		{
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Add_Schedule>();
            var data = (from add in conn.Table<Add_Schedule>() select add);
            delDatalist.ItemsSource = data;
        }
        private void delBtn_Clicked(object sender, EventArgs e)
        {
            bool isIdEmpty;
            isIdEmpty = String.IsNullOrEmpty(delId.Text);
            if (isIdEmpty)
            {
                DisplayAlert("Error", "ID cannot be empty", "Try Again");
            }
            else
            {
                int num = -1;
                if (!int.TryParse(delId.Text, out num))
                {
                    CrossToastPopUp.Current.ShowToastMessage("enter valid id");
                }
                else
                {
                    var entId = Convert.ToInt32(delId.Text);
                    conn.Table<Add_Schedule>().Delete(x => x.id == entId);
                    CrossToastPopUp.Current.ShowToastMessage("Record Deleted Successfully");
                    Navigation.PushAsync(new DeleteSchedule());
                    CrossToastPopUp.Current.ShowToastMessage("enter valid id");
                }
            }
        }
    }
}