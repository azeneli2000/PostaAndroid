using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using FotoCel;
using System.Collections.Generic;
using AndroidHUD;
using System;
using FotoCel.Resources;
using System.Threading.Tasks;

namespace FotoCel
{
    [Activity(Label = "AdexShoferi", MainLauncher = true)]
    public class MainActivity : Activity
    {

       
        public  List<Order> orders = new List<Order>();
        ListView lv_orders; 
        protected override  void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            
            SetContentView(Resource.Layout.Main);
            
            var sett = FindViewById<Button>(Resource.Id.settings);
            sett.Click += Sett_Click;

            lv_orders = FindViewById<ListView>(Resource.Id.listView1);
            lv_orders.ItemClick += lv_orders_ItemClick;
          

            var refresh = FindViewById<Button>(Resource.Id.refresh);
            refresh.Click += Refresh_Click;
            var s = Settings.GeneralSettings;
            var s1 = Settings.GeneralSettingsPass;
            var s2 = Settings.GeneralSettingsEmri;
            var s3 = Settings.GeneralSettingsDetyrimi;
            //nqs nuk ka perdorues te regjistruar kalo te ndihma
            if (Settings.GeneralSettings == "")
            {
                var intent = new Intent(this, typeof(Login));
                StartActivity(intent);
                Finish();
            }
            else
            {
                mbush();               
            }
        }
        private async void mbush()
        {
            bool conn = Internet.internetConnectionCheck(this);
            if (!conn)
            {
                AndHUD.Shared.ShowErrorWithStatus(this, "Nuk jeni te lidhur me internet !", MaskType.Clear, TimeSpan.FromSeconds(2));
                return;
            }

            List<string> klienti = new List<string>();
            AndHUD.Shared.Show(this, "Prisni...", 50, MaskType.Clear);
            var caller4 = new RestSharpCaller("http://webapisignalr20180319052628.azurewebsites.net/api/Values/?idShoferi=" + Settings.GeneralSettingsPass);
            Task<List<Order>> task1 = new Task<List<Order>>(caller4.GetOrders);
            //lista e dergesave te shoferit
            List<Order> or_list = new List<Order>();
            task1.Start();
            or_list = await task1;
            int i = 0; int j = 0; // i indeksi i listview j indeksi i
            int p;
            orders.Clear();
            klienti.Clear();
            foreach (Order o in or_list)

            {

                klienti.Add(o.EmriMarresi);
                //amza.Add(nx.nr_amza);
                i++;
                orders.Add(o);
            }
            var adapter = new CustomAdapter(this, orders);
            lv_orders.Adapter = adapter;
            AndHUD.Shared.Dismiss();
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            //mbush listview nga fillimi
            mbush();
        }

       

        private void Sett_Click(object sender, EventArgs e)
        {
            bool conn = Internet.internetConnectionCheck(this);
            if (!conn)
            {
                AndHUD.Shared.ShowErrorWithStatus(this, "Nuk jeni te lidhur me internet !", MaskType.Clear, TimeSpan.FromSeconds(2));
                return;
            }
            var intent = new Intent(this, typeof(BarScanner));
            StartActivity(intent);
        }

        private void lv_orders_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            bool conn = Internet.internetConnectionCheck(this);
            if (!conn)
            {
                AndHUD.Shared.ShowErrorWithStatus(this, "Nuk jeni te lidhur me internet !", MaskType.Clear, TimeSpan.FromSeconds(2));
                return;
            }
            
            tempOrder.idOrder = orders[e.Position].idOrder;
            tempOrder.EmriMarresi = orders[e.Position].EmriMarresi.ToString();
            tempOrder.Telefon = orders[e.Position].Telefon.ToString();
            tempOrder.adresaMarresi = orders[e.Position].adresaMarresi.ToString();
            if (orders[e.Position].Shenime != null)
                tempOrder.Shenime = orders[e.Position].Shenime.ToString();
            else
                tempOrder.Shenime = "";
            tempOrder.Pesha =  orders[e.Position].Pesha;
            tempOrder.Cmimi = orders[e.Position].Cmimi;

            tempOrder.Vlera = Convert.ToDecimal( orders[e.Position].Vlera.ToString());

            tempOrder.EmriKlienti = orders[e.Position].EmriKlienti.ToString();
            tempOrder.pickUp = orders[e.Position].pickUp;
            tempOrder.Barcode = orders[e.Position].Barcode;
            tempOrder.msg = 0;
            tempOrder.pareKlienti = orders[e.Position].PareKlienti;
            var intent = new Intent(this, typeof(OrderDetaje));
            StartActivity(intent);
         
        }
    }
        }


    
