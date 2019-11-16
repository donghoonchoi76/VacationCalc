using System;
using System.Windows.Input;
using VacationCalculator.Models;
using Xamarin.Forms;

namespace VacationCalculator.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel()
        {
        }

        public DateTime BeginningDate
        {
            get
            {
                SettingItem item = SettingParamsStore.GetItem(SettingItems.BeginningDate.ToString());
                if (item != null && DateTime.TryParse(item.Value, out DateTime beginingDate))
                    return beginingDate;

                return DateTime.Now;
            }
            set
            {
                DateTime beginingDate = DateTime.Now;
                SettingItem item = SettingParamsStore.GetItem(SettingItems.BeginningDate.ToString());
                if (item != null)
                    DateTime.TryParse(item.Value, out beginingDate);

                SettingParamsStore.SetItem(new SettingItem(SettingItems.BeginningDate.ToString(), value.ToLongDateString()));
                SetProperty(ref beginingDate, value);
            }
        }

        public int InitialDays
        {
            get 
            {
                SettingItem item = SettingParamsStore.GetItem(SettingItems.InitialDays.ToString());
                if (item != null && int.TryParse(item.Value, out int initialDays))
                    return initialDays;

                return 0;
            }
            set 
            {
                int initialDays = 0;
                SettingItem item = SettingParamsStore.GetItem(SettingItems.InitialDays.ToString());
                if (item != null)
                    int.TryParse(item.Value, out initialDays);

                SettingParamsStore.SetItem(new SettingItem(SettingItems.InitialDays.ToString(), value.ToString()));
                SetProperty(ref initialDays, value);
            }
        }

        public int PercentOfPay
        {
            get
            {
                SettingItem item = SettingParamsStore.GetItem(SettingItems.PercentOfPay.ToString());
                if (item != null && int.TryParse(item.Value, out int percentOfPay))
                    return percentOfPay;

                return 0;
            }
            set
            {
                int percentOfPay = 0;
                SettingItem item = SettingParamsStore.GetItem(SettingItems.PercentOfPay.ToString());
                if (item != null)
                    int.TryParse(item.Value, out percentOfPay);

                SettingParamsStore.SetItem(new SettingItem(SettingItems.PercentOfPay.ToString(), value.ToString()));
                SetProperty(ref percentOfPay, value);                    
            }
        }

        public bool HasData()
        {
            SettingItem item = SettingParamsStore.GetItem(SettingItems.PercentOfPay.ToString());
            if (item != null && int.TryParse(item.Value, out int v) && v != 0)
                return true;

            return false;
        }
    }
}