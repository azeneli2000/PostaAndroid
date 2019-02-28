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

namespace FotoCel
{
   public class TempReportOrder
    {
        public static int msg { get; set; }
        public static Int64 idOrder { get; set; }


        public static string adresaMarresi { get; set; }

        //************************PICKUP

        public static Boolean pickUp { get; set; }
        public static Boolean pareKlienti { get; set; }

        public static Int64? DriverIdPickUp { get; set; }

        public static DateTime? OraPickUp { get; set; }

        //************************KTHYER
        public static Boolean KthyerMag { get; set; }

        public static Int64? IdMagazina { get; set; }

        public static Int64? DriverIdKthyerMag { get; set; }

        public static DateTime? OraKthyerMag { get; set; }

        //************************DOREZUAR

        public static Boolean Dorzuar { get; set; }


        public static Int64? DriverIdDorezimi { get; set; }

        public static DateTime? OraDorezimi { get; set; }


        //************************TE DHENAT E DERGESES

        public static string Paguan { get; set; }
        public static Int64 IdKlienti { get; set; }
        public static Int64 IdLloji { get; set; }
        public static Int64 IdZona { get; set; }
        public static decimal Cmimi { get; set; }
        public static string Valua { get; set; }
        public static DateTime DataOraOrder { get; set; }
        public static decimal Pesha { get; set; }
        public static string Shenime { get; set; }
        public static string Telefon { get; set; }
        public static string ZonaEmertimi { get; set; }
        public static string LlojiEmertimi { get; set; }
        public static byte[] BarcodeImage { get; set; }
        public static string Barcode { get; set; }
        public static string ImageUrl { get; set; }
        public static string EmriMarresi { get; set; }
        public static string EmriKlienti { get; set; }
        public static string EmriShoferi { get; set; }
        public static string MbiemriShoferi { get; set; }
        public static decimal Vlera { get; set; }
    }
}