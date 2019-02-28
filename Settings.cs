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
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace FotoCel
{
 public   class Settings
    {

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "andi";
        private static readonly string SettingsDefault = string.Empty;

        private const string SettingsKeyPass = "andi1";
        private static readonly string SettingsDefaultPass = string.Empty;
        #endregion
        private const string SettingsKeyEmri = "andi11";
        private static readonly string SettingsDefaultEmri = string.Empty;

        private const string SettingsKeyDetyrimi = "andi111";
        private static readonly string SettingsDefaultDetyrimi = string.Empty;

        private const string SettingsKeyPP = "andi1111";
        private static readonly string SettingsDefaultPP = string.Empty;
        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }
        public static string GeneralSettingsPass
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKeyPass, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKeyPass, value);
            }
        }

        public static string GeneralSettingsEmri
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKeyEmri, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKeyEmri, value);
            }
        }
        public static string GeneralSettingsDetyrimi
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKeyDetyrimi, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKeyDetyrimi, value);
            }
        }
        public static string GeneralSettingsPP
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKeyPP, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKeyPP, value);
            }
        }

    }
}