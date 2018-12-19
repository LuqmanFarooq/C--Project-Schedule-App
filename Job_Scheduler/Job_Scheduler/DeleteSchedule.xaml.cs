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
        // sqlite connection varaible
        public SQLiteConnection conn;
        public DeleteSchedule ()
		{
            InitializeComponent();
            // search bar initialization
            InitSearchBar();
            // getting database connection using platform specific interface
            conn = DependencyService.Get<ISQLite>().GetConnection();
            // creating table in the database
            conn.CreateTable<Add_Schedule>();
            // getting data from database
            var data = (from add in conn.Table<Add_Schedule>() select add);
            delDatalist.ItemsSource = data;
        }
        // searchbar functionality
        public void InitSearchBar()
        {
            dataSearch.TextChanged += (s, e) => FilterItem(dataSearch.Text);
            dataSearch.SearchButtonPressed += (s, e) => FilterItem(dataSearch.Text);
        }
        // applying filters
        public void FilterItem(string filter)
        {
            var data = (from add in conn.Table<Add_Schedule>() select add);
            delDatalist.BeginRefresh();
            if (string.IsNullOrWhiteSpace(filter))
            {
                delDatalist.ItemsSource = data;
            }
            else
            {
                delDatalist.ItemsSource = data.Where(x => x.name.ToLower().Contains(filter.ToLower()));
            }
            delDatalist.EndRefresh();
        }
        // when delete button is clicked
        private void delBtn_Clicked(object sender, EventArgs e)
        {
            // checking if user entry for id is empty
            bool isIdEmpty;
            isIdEmpty = String.IsNullOrEmpty(delId.Text);
            if (isIdEmpty)
            {
                DisplayAlert("Error", "ID cannot be empty", "Try Again");
            }// outer if
            else
            {
                // if not empty then checking if user has enter a valid id in num or enter something else
                int num = -1;
                if (!int.TryParse(delId.Text, out num))
                {
                    CrossToastPopUp.Current.ShowToastMessage("enter valid id");
                }// inner if
                else
                {
                    // if valid id is entered
                    // convert string from text box to number
                    var entId = Convert.ToInt32(delId.Text);
                    // deleting record from database that matches the user entered id
                    conn.Table<Add_Schedule>().Delete(x => x.id == entId);
                    // message if deleted
                    CrossToastPopUp.Current.ShowToastMessage("Record Deleted Successfully");

                    // ---------------------refreshing the page------------------------------------------

                    InitializeComponent();
                    // getting database connection using platform specific interface
                    conn = DependencyService.Get<ISQLite>().GetConnection();
                    // creating table in the database
                    conn.CreateTable<Add_Schedule>();
                    // getting data from database
                    var data = (from add in conn.Table<Add_Schedule>() select add);
                    delDatalist.ItemsSource = data;

                    // ---------------------refreshing the page------------------------------------------
                }// inner else
            }// outer else
        }
    }
}