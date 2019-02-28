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

namespace FotoCel.Resources
{
    class CustomAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Order> orders;
        public CustomAdapter(Activity activity, List<Order> or)
        {
            this.activity = activity;
            this.orders = or;
        }



        public override int Count
        {
            get
            {
                return orders.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return Convert.ToInt64(orders[position].idOrder);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.listviewLayout, parent, false);
            var klientiText = view.FindViewById<TextView>(Resource.Id.text1);
            var adresaMarresi = view.FindViewById<TextView>(Resource.Id.text2);
            klientiText.Text ="P  : "  + orders[position].EmriKlienti;
            adresaMarresi.Text = "D  : " + orders[position].adresaMarresi;
            if (orders[position].pickUp ==true )
            {
                klientiText.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ef4444"));
                adresaMarresi.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ef4444"));

            }
            if(orders[position].PareKlienti == true && orders[position].pickUp == false)
            {
                klientiText.SetBackgroundColor(Android.Graphics.Color.ParseColor("#006400"));
                adresaMarresi.SetBackgroundColor(Android.Graphics.Color.ParseColor("#006400"));

            }

            return view;
        }
    }
}