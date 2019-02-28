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
using AndroidHUD;
using FotoCel.Resources;
using System.Threading.Tasks;

namespace FotoCel
{
    [Activity(Label = "Pickup")]
    public class Pickup : Activity
    {
        List<Order> orders = new List<Order>();
        ListView lv_orders;
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PickupReport);

           
             lv_orders = FindViewById<ListView>(Resource.Id.listView1);
             lv_orders.ItemClick += Lv_orders_ItemClick;
            TextView pickupNr = FindViewById<TextView>(Resource.Id.textView1);
            List<string> klienti = new List<string>();
            AndHUD.Shared.Show(this, "Prisni...", 50, MaskType.Clear);
            var caller4 = new RestSharpCaller("http://webapisignalr20180319052628.azurewebsites.net/api/Pickup/?driverId=" + Settings.GeneralSettingsPass+ "&data=" + DataZgjedhur.data);
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
            pickupNr.Text = "Pickup : " + orders.Count().ToString();
            var adapter = new CustomAdapter(this, orders);
            lv_orders.Adapter = adapter;
            AndHUD.Shared.Dismiss();
        }

        private void Lv_orders_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            bool conn = Internet.internetConnectionCheck(this);
            if (!conn)
            {
                AndHUD.Shared.ShowErrorWithStatus(this, "Nuk jeni te lidhur me internet !", MaskType.Clear, TimeSpan.FromSeconds(2));
                return;
            }

            TempReportOrder.idOrder = orders[e.Position].idOrder;
            TempReportOrder.EmriMarresi = orders[e.Position].EmriMarresi.ToString();
            TempReportOrder.Telefon = orders[e.Position].Telefon.ToString();
            TempReportOrder.adresaMarresi = orders[e.Position].adresaMarresi.ToString();
            if (orders[e.Position].Shenime != null)
                TempReportOrder.Shenime = orders[e.Position].Shenime.ToString();
            else
                TempReportOrder.Shenime = "";
            TempReportOrder.Pesha = orders[e.Position].Pesha;
            TempReportOrder.Cmimi = orders[e.Position].Cmimi;

            TempReportOrder.Vlera = Convert.ToDecimal(orders[e.Position].Vlera.ToString());

            TempReportOrder.EmriKlienti = orders[e.Position].EmriKlienti.ToString();
            TempReportOrder.pickUp = orders[e.Position].pickUp;
            TempReportOrder.Barcode = orders[e.Position].Barcode;
            TempReportOrder.msg = 0;
            TempReportOrder.pareKlienti = orders[e.Position].PareKlienti;
            TempReportOrder.Vlera = orders[e.Position].Vlera;
            TempReportOrder.Cmimi = orders[e.Position].Cmimi;
            var intent = new Intent(this, typeof(OrRepActivity));
            StartActivity(intent);
        }
    }
}