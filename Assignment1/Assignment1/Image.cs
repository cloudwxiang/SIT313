using System;

using Android.App;
using Android.Widget;
using Android.OS;

namespace Assignment1
{
    [Activity(Label = "ImageView")]
    public class Image : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Imageview);

            ImageView img = FindViewById<ImageView>(Resource.Id.imageview1);
            var imageSwitch = false;
            img.Click += delegate
            {
                if (imageSwitch)
                {
                    img.SetImageResource(Resource.Drawable.one);
                    imageSwitch = false;
                }
                else{
                    img.SetImageResource(Resource.Drawable.two);
                    imageSwitch = true;
                }
            };

            Button Return = FindViewById<Button>(Resource.Id.Return);
            Return.Click += delegate
                {
                StartActivity(typeof(SelectActivity));
                };

            }
        }
    }