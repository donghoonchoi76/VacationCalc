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

                if (SetProperty(ref beginingDate, value))
                    SettingParamsStore.SetItem(new SettingItem(SettingItems.BeginningDate.ToString(), beginingDate.ToString()));
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

                if(SetProperty(ref initialDays, value))
                    SettingParamsStore.SetItem(new SettingItem(SettingItems.InitialDays.ToString(), initialDays.ToString()));
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

                if (SetProperty(ref percentOfPay, value))
                    SettingParamsStore.SetItem(new SettingItem(SettingItems.PercentOfPay.ToString(), percentOfPay.ToString()));
            }
        }
    }
}