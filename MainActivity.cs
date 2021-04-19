using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;
using System;

namespace ComunicationBetweenActivities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button _tlacitko1;
        private const int REQUEST_CODE_SECOND_ACTIVITY = 1;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
            SetContentView(Resource.Layout.activity_main);
            SetupReferences();
            SubScribeEventHandlers();
            _tlacitko1.Text = "Text changed from main activity";
        }

        private void SubScribeEventHandlers()
        {
            _tlacitko1.Click += _tlacitko1_Click;
            
        }

        private void SetupReferences()
        {
            _tlacitko1 = FindViewById<Button>(Resource.Id.tlacitko1);
        }

        private void _tlacitko1_Click(object sender, System.EventArgs e)
        {
          
            StartSecondActivity();
        }

        private void StartSecondActivity()
        {
            var intent = new Intent(this, typeof(SecondActivity));
            //pridam intentu pod nakym klicem zpravu

            intent.PutExtra(Constants.myKey, "This is message from first activity");

            // StartActivity(intent);  //mam intent kterym soupustim druhou aktivitu //to bylo jen spusteni druhe aktivity
            StartActivityForResult(intent, REQUEST_CODE_SECOND_ACTIVITY); // ted chci aby se spustila druha aktivita, ale taky cekam naky result
            //tahle metoda spusti intent, druhou aktivitu a ocekava result ... coz uz jdeme do dalsiho lifecycle, ne do OnCreate ale do OnActivityResult 
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        // vraci se nam naky rquestCode a resultCode
        
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode != REQUEST_CODE_SECOND_ACTIVITY || resultCode != Result.Ok) return;
            // zjistujeme jestli to prislo z te aktivity z ktere chceme a jestli je Result OK - jestli ne tak vyskoc .. konec
            // data je stejny typ objektu jak intent tedy Intent
            var messageFromSecondActivity = data.GetStringExtra(Constants.myKey);
            _tlacitko1.Text = messageFromSecondActivity;

        }

    }
}