﻿using System;
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
        private ObservableCollection<Add_Schedule> items = new ObservableCollection<Add_Schedule>();
        public SQLiteConnection conn;
        public DataList ()
		{
			InitializeComponent ();
            InitSearchBar();
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Add_Schedule>();
            var data = (from add in conn.Table<Add_Schedule>() select add);
            Datalist.ItemsSource = data;
        }
        
        public void InitSearchBar()
        {
            dataSearch.TextChanged += (s, e) => FilterItem(dataSearch.Text);
            dataSearch.SearchButtonPressed += (s, e) => FilterItem(dataSearch.Text);
        }
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
        public int DeleteDbItem(int id)
        {
            return this.conn.Delete<Add_Schedule>(Id);
        }
        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var dataModel = (Add_Schedule)item.CommandParameter;
            this.items.Remove(dataModel);
            DeleteDbItem(dataModel.id);
        }
    }
}