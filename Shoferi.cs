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
  public  class Shoferi
    {
        public Int64 IdShoferi { get; set; }

        public string EmriShoferi { get; set; }
        public string MbiemriShoferi { get; set; }
        public string Aktiv { get; set; }

        public string User { get; set; }
        public string Password { get; set; }
        public decimal Detyrimi { get; set; }
    }
}