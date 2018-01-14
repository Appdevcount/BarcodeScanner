using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace FormsSample
{
    public class HomePage : ContentPage
    {
        ZXingScannerPage scanPage;
        Button buttonScanDefaultOverlay;
   
        public HomePage () : base ()
        {
            buttonScanDefaultOverlay = new Button {
                Text = "Scan Barcode",
                AutomationId = "scanWithDefaultOverlay",
            };

            //setup options
            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = false,
                UseFrontCameraIfAvailable = false,
                TryHarder = true,
                //PossibleFormats = new List<ZXing.BarcodeFormat>
                //{
                //    ZXing.BarcodeFormat.EAN_8,
                //    ZXing.BarcodeFormat.EAN_13
                //}
            };

            buttonScanDefaultOverlay.Clicked += async delegate {
                scanPage = new ZXingScannerPage(options) {
                    DefaultOverlayTopText = "Align the barcode within the frame",
                    DefaultOverlayBottomText = "Scan the Barcode",
                    DefaultOverlayShowFlashButton = true
                };
                scanPage.OnScanResult += (result) => {
                    scanPage.IsScanning = false;

                    ZXing.BarcodeFormat barcodeFormat = result.BarcodeFormat;
                    string type = barcodeFormat.ToString();
                    Device.BeginInvokeOnMainThread(() => {
                        Navigation.PopAsync();
                        DisplayAlert("The Barcode type is : " + type, "The text is : " + result.Text, "OK");

                    });
                };

                await Navigation.PushAsync (scanPage);
            };

 
            var stack = new StackLayout ();
            stack.Children.Add (buttonScanDefaultOverlay);
           
            Content = stack;
        }
    }
}
