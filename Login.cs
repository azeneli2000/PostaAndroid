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
using Gcm.Client;
using Android.Util;
using AndroidHUD;
using System.Threading.Tasks;

namespace FotoCel
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {

        private void RegisterWithGCM()
        {
           
            GcmClient.CheckDevice(this);
            GcmClient.CheckManifest(this);

            // Regjistron per notification
            Log.Info("Login", "Registering...");
            PushHandlerService.Context = this;

            GcmClient.Register(this, Constants.SenderID);

        }
        private Button hyrje;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            //kur klikohet hyr
            hyrje = FindViewById<Button>(Resource.Id.login);
            hyrje.Click += Hyrje_Click;
        }
              private async void Hyrje_Click(object sender, EventArgs e)
        {

            //ben verifikimin e username dhe pass
            //if (!Internet.internetConnectionCheck(this))
            //{
            //    AndHUD.Shared.ShowErrorWithStatus(this, "Nuk jeni te lidhur me internet !", MaskType.Clear, TimeSpan.FromSeconds(5));
            //    return;

            //}
            EditText em_perd = FindViewById<EditText>(Resource.Id.username);
            EditText pass = FindViewById<EditText>(Resource.Id.pass);


            //kontrollon nqs egziston useri
            var caller_user_check = new RestSharpCaller("http://webapisignalr20180319052628.azurewebsites.net/api/Shoferi?shoferiUser="+ em_perd.Text +"&shoferiPassword=" + pass.Text);
            AndHUD.Shared.Show(this, "Prisni...", 50, MaskType.Clear);
            Task<List<Shoferi>> task1 = new Task<List<Shoferi>>(caller_user_check.GetShoferi);
            task1.Start();
            List<Shoferi> perd = await task1;
            AndHUD.Shared.Dismiss();
            if (perd.Count == 0)
            {
                AndHUD.Shared.Dismiss();
                AndHUD.Shared.ShowErrorWithStatus(this, "Te dhenat nuk jane te sakta !", MaskType.Clear, TimeSpan.FromSeconds(2));

                em_perd.Text = "";
                pass.Text = "";

                return;
            }
          



            //ben regjistrimin per te marre notification
            PushHandlerService.perdoruesi = perd[0].IdShoferi.ToString();
            RegisterWithGCM();
            //shton te settings emrin e username 
            Settings.GeneralSettings = perd[0].User;
            Settings.GeneralSettingsPass = perd[0].IdShoferi.ToString();
            Settings.GeneralSettingsEmri = (perd[0].EmriShoferi.ToString() + "  "+ perd[0].MbiemriShoferi.ToString()).ToString();
            Settings.GeneralSettingsDetyrimi = perd[0].Detyrimi.ToString();
            Settings.GeneralSettingsPP = perd[0].Password.ToString();

        }
    }
}