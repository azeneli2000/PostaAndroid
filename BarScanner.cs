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
using ZXing.Net.Mobile.Forms;
using ZXing.Mobile;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using AndroidHUD;
using FotoCel.Resources;

namespace FotoCel
{
    [Activity(Label = "BarScanner")]
   
    public class BarScanner : Activity
    {
        TextView _dateDisplay;
        Button _dateSelectButton;
        Button _pickUp;
        Button _deliver;
        Button _pare;
        Button _magazinuar;
        protected async override void OnCreate(Bundle savedInstanceState)
        {
           
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Barscan);
          
            _dateDisplay = FindViewById<TextView>(Resource.Id.date_display);
            _dateSelectButton = FindViewById<Button>(Resource.Id.date_select_button);
            _pickUp = FindViewById<Button>(Resource.Id.button2);
            _deliver = FindViewById<Button>(Resource.Id.button3);
            _pare = FindViewById<Button>(Resource.Id.button5);
            _magazinuar = FindViewById<Button>(Resource.Id.button4);

            _dateDisplay.Text = DateTime.Now.ToShortDateString();
            _dateSelectButton.Click += _dateSelectButton_Click;
            _pickUp.Click += _pickUp_Click;
            _deliver.Click += _deliver_Click;
            _pare.Click += _pare_Click;
            _magazinuar.Click += _magazinuar_Click;

            var caller6 = new RestSharpCaller("http://webapisignalr20180319052628.azurewebsites.net/api/Shoferi?shoferiUser=" + Settings.GeneralSettings.ToString() + "&shoferiPassword=" + Settings.GeneralSettingsPP.ToString());
            Task<List<Shoferi>> task3 = new Task<List<Shoferi>>(caller6.GetShoferi);
            task3.Start();
            List<Shoferi> sh = await task3;
            string det = sh[0].Detyrimi.ToString();
            var tv_User = FindViewById<TextView>(Resource.Id.detyrimitv);
            tv_User.Text = Settings.GeneralSettingsEmri + "       " + det + " LEK";
        }

        private void _magazinuar_Click(object sender, EventArgs e)
        {
            DataZgjedhur.data = _dateDisplay.Text;
            var intent = new Intent(this, typeof(MgazinuarActivity));
            //   intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);
            StartActivity(intent);
        }

        private void _pare_Click(object sender, EventArgs e)
        {
            DataZgjedhur.data = _dateDisplay.Text;
            var intent = new Intent(this, typeof(PareActivity));
            //   intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);
            StartActivity(intent);
        }

        private void _deliver_Click(object sender, EventArgs e)
        {
            DataZgjedhur.data = _dateDisplay.Text;
            var intent = new Intent(this, typeof(DorezuarActivity));
            //   intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);
            StartActivity(intent);
        }

        private  void _pickUp_Click(object sender, EventArgs e)
        {
            DataZgjedhur.data= _dateDisplay.Text;
            var intent = new Intent(this, typeof(Pickup));
         //   intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.ClearTask | ActivityFlags.NewTask);
            StartActivity(intent);

           
        }

        private void _dateSelectButton_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _dateDisplay.Text = time.ToShortDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}