using System;
using System.IO;
using SQLite;
using System.Linq;

using Android.App;
using Android.Widget;
using Android.OS;

namespace Assignment1
{
    [Activity(Label = "Assignment1", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText UserName;
        EditText TxtPassword;
        EditText TxtEmail;
        Button Login;
        Button Signup;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            UserName = FindViewById<EditText>(Resource.Id.UserName);
            TxtPassword = FindViewById<EditText>(Resource.Id.Password);
            TxtEmail = FindViewById<EditText>(Resource.Id.Email);
            Login = FindViewById<Button>(Resource.Id.Login);
            Signup = FindViewById<Button>(Resource.Id.Signup);

            Login.Click += Login_Click;
            Signup.Click += Signup_Click;

        }

        private void Signup_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SignUp));
        }

        private void Login_Click(object sender, EventArgs e)
        {
            try{
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"userinfo.db");
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<UserInfo>();
                var data1 = data.Where(x => x.Username == UserName.Text && x.PassWord == TxtPassword.Text && x.Emails == TxtEmail.Text).FirstOrDefault();
                if (data1 != null){
                    Toast.MakeText(this, "login Success", ToastLength.Short).Show();
                    StartActivity(typeof(SelectActivity));
                }else{
                    Toast.MakeText(this, "Invalid user name or password", ToastLength.Short).Show();
                }
            }catch (Exception ex){
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
        public string CreateDB(){
            var output = "";
            output += "Creating DataBase if it dosen't exists";
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "userinfo.db");
            var db = new SQLiteConnection(dpPath);
            output += "/n DataBase Created";
            return output;
        }
    }
}

