using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComunicationBetweenActivities
{
    [Activity(Label = "Activity1")]
    public class SecondActivity : Activity
    {
        private TextView _textovePole1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.second_activity);

            // Create your application here
            SetupReferences();
            SubScribeEventHandlers();

            var message = Intent.GetStringExtra(Constants.myKey);
            _textovePole1.Text = message;

        }


        private void SetupReferences()
        {
            _textovePole1 = FindViewById<TextView>(Resource.Id.textView1id); 
           
        }
        private void SubScribeEventHandlers()
        {
            _textovePole1.Click += _textovePole1_Click;
        }

        private void _textovePole1_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.PutExtra(Constants.myKey, "message from second activity");
            SetResult(Result.Ok, intent);
            Finish();
            //finish zabije tuto aktivitu
        }
    }
}