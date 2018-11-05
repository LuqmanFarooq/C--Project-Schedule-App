using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Firebase.Auth;
using static Android.Views.View;
using Android.Gms.Tasks;
using Android.Support.Design.Widget;

namespace Job_Scheduler.Droid
{
    [Activity(Label = "DashBoard", Theme = "@style/MainTheme")]
    public class DashBoard : AppCompatActivity, IOnClickListener
    {
        TextView txtWelcome;
        Button  btnLogout;
        RelativeLayout activity_dashboard;

        FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DashBoard);

            //Init Firebase
            auth = FirebaseAuth.GetInstance(MainLoginPage.jobScheduler);

            //View
            txtWelcome = FindViewById<TextView>(Resource.Id.dashboard_welcome);
            btnLogout = FindViewById<Button>(Resource.Id.dashboard_btn_logout);
            activity_dashboard = FindViewById<RelativeLayout>(Resource.Id.activity_dashboard);

            btnLogout.SetOnClickListener(this);

            //Check session
            if (auth.CurrentUser != null)
                txtWelcome.Text = "Welcome , " + auth.CurrentUser.Email;
        }

        public void OnClick(View v)
        {
           if (v.Id == Resource.Id.dashboard_btn_logout)
                LogoutUser();
        }

        private void LogoutUser()
        {
            auth.SignOut();
            if (auth.CurrentUser == null)
            {
                StartActivity(new Intent(this, typeof(MainActivity)));
                Finish();
            }
        }
    }
}