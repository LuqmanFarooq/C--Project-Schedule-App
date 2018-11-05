using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase;
using Firebase.Auth;
using Android.Gms.Tasks;
using Android.Support.Design.Widget;

namespace Job_Scheduler.Droid
{
    [Activity(Label = "MainActivity", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, View.IOnClickListener
    {
        Button manager_Login;
        Button emp_login;
        RelativeLayout activity_main;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.main);

            //view
            manager_Login = FindViewById<Button>(Resource.Id.manager_login_btn);
            emp_login = FindViewById<Button>(Resource.Id.employee_login_btn);
            activity_main = FindViewById<RelativeLayout>(Resource.Id.activity_main);

            manager_Login.SetOnClickListener(this);
            emp_login.SetOnClickListener(this);

        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.manager_login_btn)
            {
                StartActivity(new Android.Content.Intent(this, typeof(ManagerLoginCode)));
                Finish();
            }
            else if (v.Id == Resource.Id.employee_login_btn)
            {
                StartActivity(new Android.Content.Intent(this, typeof(MainLoginPage)));
                Finish();
            }
        }
    }
}