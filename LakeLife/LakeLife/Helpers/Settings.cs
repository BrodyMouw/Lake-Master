using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

namespace LakeLife.Helpers
{
    public static class Settings
    {
        private static ISettings Setting
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        //Tarp and Clean
        public static bool ItemStatus1
        {
            get
            {
                return Setting.GetValueOrDefault("ItemStatus1", false);
            }
            set
            {
                Setting.AddOrUpdateValue("ItemStatus1", value);
            }
        }
        //half detail
        public static bool ItemStatus2
        {
            get
            {
                return Setting.GetValueOrDefault("ItemStatus2", false);
            }
            set
            {
                Setting.AddOrUpdateValue("ItemStatus2", value);
            }
        }
        //full detail
        public static bool ItemStatus3
        {
            get
            {
                return Setting.GetValueOrDefault("ItemStatus3", false);
            }
            set
            {
                Setting.AddOrUpdateValue("ItemStatus3", value);
            }
        }

        public static bool ItemStatus4
        {
            get
            {
                return Setting.GetValueOrDefault("ItemStatus4", false);
            }
            set
            {
                Setting.AddOrUpdateValue("ItemStatus4", value);
            }
        }

        public static void Reset()
        {
            Settings.ItemStatus1 = false;
            Settings.ItemStatus2 = false;
            Settings.ItemStatus3 = false;
            Settings.ItemStatus4 = false;
        }
    }
}