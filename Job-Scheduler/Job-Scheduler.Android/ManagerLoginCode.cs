using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace Job_Scheduler.Droid
{
    [Activity(Label = "ManagerLoginCode", Theme = "@style/MainTheme")]
    public class ManagerLoginCode : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, View.IOnClickListener
    {
        EditText managerCode;
        Button sendCode;
        
        RelativeLayout activity_manger_Login_code;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ManagerLoginCode);
            //view
            managerCode = FindViewById<EditText>(Resource.Id.input_code);
            sendCode = FindViewById<Button>(Resource.Id.enter_code_btn);
            activity_manger_Login_code = FindViewById<RelativeLayout>(Resource.Id.activity_manger_Login_code);
            managerCode.SetOnClickListener(this);
            sendCode.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            string preCodedCode = "6689";
            if (v.Id == Resource.Id.enter_code_btn)
            {
                if(managerCode.Text.Equals(preCodedCode))
                {
                    StartActivity(new Android.Content.Intent(this, typeof(MainLoginPage)));
                    Finish();
                }
                else
                {
                    Snackbar snackBar = Snackbar.Make(activity_manger_Login_code, "Wrong code! ", Snackbar.LengthShort);
                    snackBar.Show();
                }
            }
            
        }
    }
}