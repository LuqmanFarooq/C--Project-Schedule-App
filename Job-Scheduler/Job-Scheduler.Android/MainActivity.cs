using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase;
using Firebase.Auth;

namespace Job_Scheduler.Droid
{
    [Activity(Label = "Job_Scheduler", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        Button btnlogin;
        EditText input_email, input_password;
        TextView btnSignUp, btnForgotPassword;
        RelativeLayout main;

        public static FirebaseApp jobScheduler;
        FirebaseAuth auth;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);
            // initialise firebase
            InitFirebaseAuth();

            // view
            btnlogin = FindViewById<Button>(Resource.Id.login_btn_login);
            input_email = FindViewById<EditText>(Resource.Id.login_email);
            input_password = FindViewById<EditText>(Resource.Id.login_password);
            btnSignUp = FindViewById<TextView>(Resource.Id.login_btn_sign_up);
            btnForgotPassword = FindViewById<TextView>(Resource.Id.login_btn_forgot_password);

        }

        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
           .SetApplicationId("1:475218936925:android:6fa80ae367c1bd5a")
           .SetApiKey("AIzaSyD0nxjUglD9RJSvg0GH3_cIwN5JG3dlJaA")
           .Build();

            if (jobScheduler == null)
                jobScheduler = FirebaseApp.InitializeApp(this, options);
            auth = FirebaseAuth.GetInstance(jobScheduler);
        }
    }
}