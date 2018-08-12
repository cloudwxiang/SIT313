using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Widget;

namespace Assignment1
{
    [Activity(Label = "ListActivity")]
    public class ListActivity : Activity
    {
        private List<string> listItems;
        private ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListLayout);
            // Create your application here

            Button Return = FindViewById<Button>(Resource.Id.Return);
            Return.Click += delegate
            {
                StartActivity(typeof(SelectActivity));
            };

            listView = FindViewById<ListView>(Assignment1.Resource.Id.listView);

            listItems = new List<string>();
            listItems.Add("Sydney");
            listItems.Add("Melbourne");
            listItems.Add("Perth");
            listItems.Add("Adelaide");
            listItems.Add("Carens");

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, listItems);
            listView.Adapter = adapter;

            listView.ItemClick += listView_ItemClick;
        }

        void listView_ItemClick (object sender, AdapterView.ItemClickEventArgs e){
            if (listItems [e.Position] == "Sydney"){
                
            }
        }
    }
}
