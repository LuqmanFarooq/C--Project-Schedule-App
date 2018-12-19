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

namespace Job_Scheduler
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DataList : ContentPage
	{
        // sqlite variable
        public SQLiteConnection conn;
        
        public DataList ()
		{
			InitializeComponent ();
            // search bar initialization
            InitSearchBar();
            // getting connection according to platform using interface
            conn = DependencyService.Get<ISQLite>().GetConnection();
            // creating table in the database
            conn.CreateTable<Add_Schedule>();
            var data = (from add in conn.Table<Add_Schedule>() select add);
            Datalist.ItemsSource = data;
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
            Datalist.BeginRefresh();
            if(string.IsNullOrWhiteSpace(filter))
            {
                Datalist.ItemsSource = data;
            }
            else
            {
                Datalist.ItemsSource = data.Where(x => x.name.ToLower().Contains(filter.ToLower()));
            }
            Datalist.EndRefresh();
        }
    }
}