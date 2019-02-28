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
using Android.Text.Util;
using Android.Text;
using Android.Text.Style;
using Android.Graphics;
using System.Threading.Tasks;
using AndroidHUD;
using ZXing.Mobile;
using Android.Views.InputMethods;

namespace FotoCel
{
    [Activity(Label = "OrderDetaje")]
    public class OrderDetaje : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OrderDetaje);
            if(tempOrder.msg == 1)
            AndHUD.Shared.ShowErrorWithStatus(this, "Barkodi nuk i perket dergeses se zgjedhur ", MaskType.Clear, TimeSpan.FromSeconds(2));

            var  id_order = FindViewById<TextView>(Resource.Id.textView1);
            id_order.Text = "NUMRI : " + tempOrder.idOrder.ToString();
            var span0 = new SpannableStringBuilder("NUMRI :   " + tempOrder.idOrder.ToString());
            span0.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 7, 0);
            span0.SetSpan(new UnderlineSpan(), 0, 7, 0);
            id_order.SetText(span0, TextView.BufferType.Spannable);

            var emri_Derguesi = FindViewById<TextView>(Resource.Id.textView2);           
            emri_Derguesi.Text = "EMRI DERGUESI : " + tempOrder.EmriKlienti.ToString();
            var span = new SpannableStringBuilder("EMRI DERGUESI :   "+ tempOrder.EmriKlienti.ToString());
            span.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 15, 0);
            span.SetSpan(new UnderlineSpan(), 0, 15, 0);
            emri_Derguesi.SetText(span, TextView.BufferType.Spannable);

            var emri_marresi = FindViewById<TextView>(Resource.Id.textView3);
            emri_marresi.Text = "EMRI MARRESI : "  + tempOrder.EmriMarresi.ToString();
            var span1 = new SpannableStringBuilder("EMRI MARRESI :   " + tempOrder.EmriMarresi.ToString());
            span1.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 14, 0);
            span1.SetSpan(new UnderlineSpan(), 0, 14, 0);
            emri_marresi.SetText(span1, TextView.BufferType.Spannable);



            var adresa_marresi = FindViewById<TextView>(Resource.Id.textView4);
            var span2 = new SpannableStringBuilder("ADRESA MARRESI   : " + tempOrder.adresaMarresi.ToString());
            span2.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 16, 0);
            span2.SetSpan(new UnderlineSpan(), 0, 16, 0);
            adresa_marresi.SetText(span2, TextView.BufferType.Spannable);


            //adresa_marresi.Text = "ADRESA MARRESI : " + tempOrder.adresaMarresi.ToString();  
            
            
                             
            var tel = FindViewById<TextView>(Resource.Id.textView5);
            tel.Text = "TELEFON : " + tempOrder.Telefon.ToString();
            var span3 = new SpannableStringBuilder("TELEFON :   " + tempOrder.Telefon.ToString());
            span3.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 9, 0);
            span3.SetSpan(new UnderlineSpan(), 0, 9, 0);
            tel.SetText(span3, TextView.BufferType.Spannable);

            var shenime = FindViewById<TextView>(Resource.Id.textView6);
            shenime.Text = "PERSHKRIMI : " +  tempOrder.Shenime.ToString();
            var span4 = new SpannableStringBuilder("PERSHKRIMI :   " + tempOrder.Shenime.ToString());
            span4.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 12, 0);
            span4.SetSpan(new UnderlineSpan(),0,12,0);
            shenime.SetText(span4, TextView.BufferType.Spannable);



            var pesha = FindViewById<TextView>(Resource.Id.textView7);
            pesha.Text = "PESHA : " + tempOrder.Pesha.ToString() + " KG";            
            var span5 = new SpannableStringBuilder("PESHA   : " + tempOrder.Pesha.ToString() + " KG");
            span5.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 7, 0);
            span5.SetSpan(new UnderlineSpan(), 0, 7, 0);
            pesha.SetText(span5, TextView.BufferType.Spannable);
            
            var konfirmo = FindViewById<Button>(Resource.Id.button4);
            var scan = FindViewById<ImageButton>(Resource.Id.imageButton1);
            var fut = FindViewById<Button>(Resource.Id.buttonBarcode);
            var barcd = FindViewById<EditText>(Resource.Id.barEdit);
            konfirmo.Click += Konfirmo_Click;
            fut.Click += Fut_Click;
            scan.Click += Scan_Click;
            scan.Touch += Scan_Touch;


            if (tempOrder.pareKlienti==true)
            {
                konfirmo.Visibility = ViewStates.Invisible;
                scan.Visibility = ViewStates.Visible;
                barcd.Visibility = ViewStates.Visible;
                fut.Visibility = ViewStates.Visible;

            }

            else
            {
                konfirmo.Visibility = ViewStates.Visible;
                scan.Visibility = ViewStates.Invisible;
                barcd.Visibility = ViewStates.Invisible;
                fut.Visibility = ViewStates.Invisible;
            }
        
        }

        private async void Fut_Click(object sender, EventArgs e)
        {
            var barcode = FindViewById<EditText>(Resource.Id.barEdit);
            if (tempOrder.pickUp == true)
            {
                if (barcode.Text == tempOrder.Barcode)
                {
                    AndHUD.Shared.Show(this, "Prisni...", 50, MaskType.Clear);
                    var caller = new RestSharpCaller("http://webapisignalr20180319052628.azurewebsites.net/api/Dorzo/?ord=" + tempOrder.idOrder + "&driverId=" + Settings.GeneralSettingsPass + "&cmimiPosta=" + tempOrder.Cmimi + "&vleraPorosia=" + tempOrder.Vlera + "&idKlienti=" + tempOrder.IdKlienti);
                    Task task1 = new Task(caller.UpdatePickup);
                    task1.Start();
                    // caller.UpdatePickup();
                    await task1;
                    AndHUD.Shared.Dismiss();
                    var intent1 = new Intent(this, typeof(MainActivity));
                    intent1.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);
                    StartActivity(intent1);
                    Finish();
                }
                else
                {
                    barcode.Text = "";
                }
            }
            else
            {
                if (barcode.Text == tempOrder.Barcode)
                {
                    AndHUD.Shared.Show(this, "Prisni...", 50, MaskType.Clear);
                    var caller = new RestSharpCaller("http://webapisignalr20180319052628.azurewebsites.net/api/Values/?ord=" + tempOrder.idOrder + "&driverId=" + Settings.GeneralSettingsPass);

                    Task task1 = new Task(caller.UpdatePickup);
                    task1.Start();
                    await task1;
                    // caller.UpdatePickup();
                    AndHUD.Shared.Dismiss();
                    var intent1 = new Intent(this, typeof(MainActivity));
                    intent1.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);

                    StartActivity(intent1);
                    Finish();
                }
                else
                {
                    barcode.Text = "";
                }
            }

        }

        private void Scan_Touch(object sender, View.TouchEventArgs e)
        {
 
            ImageButton sc = FindViewById<ImageButton>(Resource.Id.imageButton1);
            if (e.Event.Action == MotionEventActions.Down)
            {
                sc.SetImageResource(Resource.Drawable.barcode5);
            }
            else if (e.Event.Action == MotionEventActions.Up)
            {
                sc.SetImageResource(Resource.Drawable.barcode4);
            }
            e.Handled = false;
        
         }

        private async void Scan_Click(object sender, EventArgs e)
        {
           
            var id_order = FindViewById<TextView>(Resource.Id.textView1);
            if (tempOrder.pickUp== true)
            {

                MobileBarcodeScanner.Initialize(Application);
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();
                if (result != null)
                {
                   
                    Vibrator vibrator = (Vibrator)GetSystemService(Context.VibratorService);
                    vibrator.Vibrate(250);
                    if (result.Text == tempOrder.Barcode)
                    {
                        //update i pickup ose deliver
                       
                        AndHUD.Shared.Show(this, "Prisni...", 50, MaskType.Clear);
                        var caller = new RestSharpCaller("http://webapisignalr20180319052628.azurewebsites.net/api/Dorzo/?ord=" + tempOrder.idOrder + "&driverId=" + Settings.GeneralSettingsPass + "&cmimiPosta=" + tempOrder.Cmimi + "&vleraPorosia=" + tempOrder.Vlera + "&idKlienti=" + tempOrder.IdKlienti);

                        Task task1 = new Task(caller.UpdatePickup);
                        task1.Start();
                        // caller.UpdatePickup();
                        await task1;
                        AndHUD.Shared.Dismiss();
                        var intent1 = new Intent(this, typeof(MainActivity));
                        intent1.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);
                        StartActivity(intent1);
                        Finish();
                    }

                    else
                    {
                        tempOrder.msg = 1;
                       
                    }
                }             

            }

           else
            {
                //rasti qe eshte nuk eshte bere pickup
                MobileBarcodeScanner.Initialize(Application);
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();
                if (result != null)
                {

                    Vibrator vibrator = (Vibrator)GetSystemService(Context.VibratorService);
                    vibrator.Vibrate(250);
                    if (result.Text == tempOrder.Barcode)
                    {
                        //update i pickup ose deliver
                        AndHUD.Shared.Show(this, "Prisni...", 50, MaskType.Clear);
                        var caller = new RestSharpCaller("http://webapisignalr20180319052628.azurewebsites.net/api/Values/?ord=" + tempOrder.idOrder + "&driverId=" + Settings.GeneralSettingsPass);

                        Task task1 = new Task(caller.UpdatePickup);
                        task1.Start();
                        await task1;
                        // caller.UpdatePickup();
                        AndHUD.Shared.Dismiss();



                        var intent1 = new Intent(this, typeof(MainActivity));
                        intent1.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);
                        StartActivity(intent1);
                        Finish();
                    }

                    else
                    {
                        tempOrder.msg = 1;
                       
                    }
                }


            }

        }

        private async void  Konfirmo_Click(object sender, EventArgs e)
        {
            var caller5 = new RestSharpCaller("http://webapisignalr20180319052628.azurewebsites.net/api/Pare/?ord=" + tempOrder.idOrder + "&driverId=" + Settings.GeneralSettingsPass);
            Task task2 = new Task(caller5.UpdatePickup);
            task2.Start();
            await task2;
            var intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);
            StartActivity(intent);
        }

    
    }
}