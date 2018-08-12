using System;
using System.IO;
using SQLite;

using Android.App;
using Android.OS;
using Android.Widget;


namespace Assignment1
{
    [Activity(Label = "SignUp")]
    public class SignUp : Activity
    {
        EditText UserName;
        EditText TxtPassword;
        EditText TxtEmail;
        Button Signup;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignUp);
            // Create your application here
            UserName = FindViewById<EditText>(Resource.Id.UserName);
            TxtPassword = FindViewById<EditText>(Resource.Id.Password);
            TxtEmail = FindViewById<EditText>(Resource.Id.Email);
            Signup = FindViewById<Button>(Resource.Id.Signup);

            Signup.Click += SignUp_Click;
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            try {
                string dppath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "userinfo.db");
                var db = new SQLiteConnection(dppath);
                db.CreateTable<UserInfo>();
                UserInfo userInfo = new UserInfo();
                userInfo.Username = UserName.Text;
                userInfo.PassWord = TxtPassword.Text;
                userInfo.Emails = TxtEmail.Text;
                db.Insert(userInfo);
                Toast.MakeText(this, "Sign Up Successfully!", ToastLength.Short).Show();
                StartActivity(typeof(SelectActivity));
            } catch (Exception ex){
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

    }
}
