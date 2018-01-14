using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FormsSample.Droid
{
    [Activity (Label = " Syncfusion Barcode Scanner", Icon = "@drawable/AppIcon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        App formsApp;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            global::Xamarin.Forms.Forms.Init (this, bundle);

            global::ZXing.Net.Mobile.Forms.Android.Platform.Init ();

            formsApp = new App ();
            LoadApplication (formsApp);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult (requestCode, permissions, grantResults);           
        }

      
    }
}

