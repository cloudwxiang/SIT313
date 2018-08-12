
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

namespace Assignment1
{
    [Activity(Label = "SelectActivity")]
    public class SelectActivity : Activity
    {
        Button Imageswitch;
        Button Listwatch;
        Button Logout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SelectLayout);
            // Create your application here
            Imageswitch = FindViewById<Button>(Resource.Id.Imageswitch);
            Listwatch = FindViewById<Button>(Resource.Id.Listwatch);
            Logout = FindViewById<Button>(Resource.Id.logout);
            Imageswitch.Click += Imageswitch_Click;
            Listwatch.Click += Listwatch_Click;
            Logout.Click += Logout_Click;


        }

        private void Imageswitch_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Image));
        }

        private void Listwatch_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ListActivity));
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}
