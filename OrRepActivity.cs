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
using Android.Text;
using Android.Text.Style;
using Android.Graphics;

namespace FotoCel
{
    [Activity(Label = "OrRepActivity")]
    public class OrRepActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OrderdetajeRep);
            var id_order = FindViewById<TextView>(Resource.Id.textView1);
            id_order.Text = "NUMRI : " + TempReportOrder.idOrder.ToString();
            var span0 = new SpannableStringBuilder("NUMRI :   " + TempReportOrder.idOrder.ToString());
            span0.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 7, 0);
            span0.SetSpan(new UnderlineSpan(), 0, 7, 0);
            id_order.SetText(span0, TextView.BufferType.Spannable);

            var emri_Derguesi = FindViewById<TextView>(Resource.Id.textView2);
            emri_Derguesi.Text = "EMRI DERGUESI : " + TempReportOrder.EmriKlienti.ToString();
            var span = new SpannableStringBuilder("EMRI DERGUESI :   " + TempReportOrder.EmriKlienti.ToString());
            span.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 15, 0);
            span.SetSpan(new UnderlineSpan(), 0, 15, 0);
            emri_Derguesi.SetText(span, TextView.BufferType.Spannable);

            var emri_marresi = FindViewById<TextView>(Resource.Id.textView3);
            emri_marresi.Text = "EMRI MARRESI : " + TempReportOrder.EmriMarresi.ToString();
            var span1 = new SpannableStringBuilder("EMRI MARRESI :   " + TempReportOrder.EmriMarresi.ToString());
            span1.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 14, 0);
            span1.SetSpan(new UnderlineSpan(), 0, 14, 0);
            emri_marresi.SetText(span1, TextView.BufferType.Spannable);



            var adresa_marresi = FindViewById<TextView>(Resource.Id.textView4);
            var span2 = new SpannableStringBuilder("ADRESA MARRESI   : " + TempReportOrder.adresaMarresi.ToString());
            span2.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 16, 0);
            span2.SetSpan(new UnderlineSpan(), 0, 16, 0);
            adresa_marresi.SetText(span2, TextView.BufferType.Spannable);


            //adresa_marresi.Text = "ADRESA MARRESI : " + tempOrder.adresaMarresi.ToString();  



            var tel = FindViewById<TextView>(Resource.Id.textView5);
            tel.Text = "TELEFON : " + TempReportOrder.Telefon.ToString();
            var span3 = new SpannableStringBuilder("TELEFON :   " + TempReportOrder.Telefon.ToString());
            span3.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 9, 0);
            span3.SetSpan(new UnderlineSpan(), 0, 9, 0);
            tel.SetText(span3, TextView.BufferType.Spannable);

            var shenime = FindViewById<TextView>(Resource.Id.textView6);
            shenime.Text = "PERSHKRIMI : " + TempReportOrder.Shenime.ToString();
            var span4 = new SpannableStringBuilder("PERSHKRIMI :   " + TempReportOrder.Shenime.ToString());
            span4.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 12, 0);
            span4.SetSpan(new UnderlineSpan(), 0, 12, 0);
            shenime.SetText(span4, TextView.BufferType.Spannable);



            var pesha = FindViewById<TextView>(Resource.Id.textView7);
            pesha.Text = "PESHA : " + TempReportOrder.Pesha.ToString() + " KG";
            var span5 = new SpannableStringBuilder("PESHA   : " + TempReportOrder.Pesha.ToString() + " KG");
            span5.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 7, 0);
            span5.SetSpan(new UnderlineSpan(), 0, 7, 0);
            pesha.SetText(span5, TextView.BufferType.Spannable);

            var vlera = FindViewById<TextView>(Resource.Id.textView8);
            vlera.Text = "VLERA : " + TempReportOrder.Vlera.ToString();
            var span6 = new SpannableStringBuilder("VLERA   : " + TempReportOrder.Vlera.ToString());
            span6.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 7, 0);
            span6.SetSpan(new UnderlineSpan(), 0, 7, 0);
            vlera.SetText(span6, TextView.BufferType.Spannable);


            var cmimi = FindViewById<TextView>(Resource.Id.textView9);
            cmimi.Text = "CMIMI : " + TempReportOrder.Cmimi.ToString();
            var span7 = new SpannableStringBuilder("CMIMI   : " + TempReportOrder.Cmimi.ToString());
            span7.SetSpan(new ForegroundColorSpan(Color.ParseColor("#ffffff")), 0, 7, 0);
            span7.SetSpan(new UnderlineSpan(), 0, 7, 0);
            cmimi.SetText(span7, TextView.BufferType.Spannable);
        }
    }
}