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
    [Activity(Label = "Job_Scheduler", Icon = "@mipmap/icon", Theme = "@style/MainTheme",  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainLoginPage : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, View.IOnClickListener, IOnCompleteListener
    {
        Button btnlogin;
        EditText input_email, input_password;
        TextView btnSignUp, btnForgotPassword;
        RelativeLayout activity_main_login_page;

        public static FirebaseApp jobScheduler;
        FirebaseAuth auth;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainLoginPage);
            // initialise firebase
            InitFirebaseAuth();

            // view
            btnlogin = FindViewById<Button>(Resource.Id.login_btn_login);
            input_email = FindViewById<EditText>(Resource.Id.login_email);
            input_password = FindViewById<EditText>(Resource.Id.login_password);
            btnSignUp = FindViewById<TextView>(Resource.Id.login_btn_sign_up);
            btnForgotPassword = FindViewById<TextView>(Resource.Id.login_btn_forgot_password);
            activity_main_login_page = FindViewById<RelativeLayout>(Resource.Id.activity_main_login_page);

            btnSignUp.SetOnClickListener(this);
            btnlogin.SetOnClickListener(this);
            btnForgotPassword.SetOnClickListener(this);


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

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.login_btn_forgot_password)
            {
                StartActivity(new Android.Content.Intent(this, typeof(ForgotPassword)));
                Finish();
            }
            else if (v.Id == Resource.Id.login_btn_sign_up)
            {
                StartActivity(new Android.Content.Intent(this, typeof(SignUp)));
                Finish();
            }
            else if (v.Id == Resource.Id.login_btn_login)
            {
                LoginUser(input_email.Text, input_password.Text);
            }
        }

        private void LoginUser(string email, string password)
        {
            auth.SignInWithEmailAndPassword(email, password).AddOnCompleteListener(this);
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                StartActivity(new Android.Content.Intent(this, typeof(DashBoard)));
                Finish();
            }
            else
            {
                Snackbar snackBar = Snackbar.Make(activity_main_login_page, "Login Failed ", Snackbar.LengthShort);
                snackBar.Show();
            }
        }
    }
}