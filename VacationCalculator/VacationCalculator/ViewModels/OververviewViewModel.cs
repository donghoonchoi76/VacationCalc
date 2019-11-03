using System;
using System.Diagnostics;
using System.Windows.Input;
using VacationCalculator.Models;
using Xamarin.Forms;

namespace VacationCalculator.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        int currentDays;
        int nextDays;
        string nextDaysDate;

        public OverviewViewModel()
        {
        }

        public int CurrentDays 
        {
            get { return currentDays; }
            set { SetProperty(ref currentDays, value); }
        }

        public int NextDays
        {
            get { return nextDays; }
            set { SetProperty(ref nextDays, value); }
        }
        
        public string NextDaysDate
        {
            get { return nextDaysDate; }
            set { SetProperty(ref nextDaysDate, value); }
        }

        public void Refresh()
        {
            SettingItem item = SettingParamsStore.GetItem(SettingItems.BeginningDate.ToString());

            DateTime beginingDate;
            if (item != null && DateTime.TryParse(item.Value, out beginingDate))
            {
                beginingDate = new DateTime(2019, 2, 15);
            }
            else
            {
                CurrentDays = 0;
                NextDays = 0;
                NextDaysDate = DateTime.Now.ToLongDateString();
                return;
            }

            item = SettingParamsStore.GetItem(SettingItems.PercentOfPay.ToString());
            if (int.TryParse(SettingParamsStore.GetItem(SettingItems.PercentOfPay.ToString()).Value, out int percentOfPay))
            {
                int totalVacationDays = (int)GetBusinessDays(beginingDate, DateTime.Now) * percentOfPay / 100;
                int daysSpent = DataStore.ItemCount;

                if (int.TryParse(SettingParamsStore.GetItem(SettingItems.InitialDays.ToString()).Value, out int initialDays))
                {
                    CurrentDays = totalVacationDays - daysSpent + initialDays;
                }
                else
                {
                    CurrentDays = totalVacationDays - daysSpent;                    
                }

                NextDays = CurrentDays + 1;
                int nextBusinessDays = (int)Math.Ceiling(((double)totalVacationDays + 1.0) * 100.0 / (double)percentOfPay);
                NextDaysDate = AddBusinessDays(beginingDate, nextBusinessDays).ToLongDateString();
            }
            else
            {
                CurrentDays = 0;
                NextDays = 0;
                NextDaysDate = DateTime.Now.ToLongDateString();
                return;
            }   
        }

        public static int GetBusinessDays(DateTime start, DateTime end)
        {
            if (start.DayOfWeek == DayOfWeek.Saturday)
            {
                start = start.AddDays(2);
            }
            else if (start.DayOfWeek == DayOfWeek.Sunday)
            {
                start = start.AddDays(1);
            }

            if (end.DayOfWeek == DayOfWeek.Saturday)
            {
                end = end.AddDays(-1);
            }
            else if (end.DayOfWeek == DayOfWeek.Sunday)
            {
                end = end.AddDays(-2);
            }

            int diff = (int)end.Subtract(start).TotalDays;
            int result = diff / 7 * 5 + diff % 7;

            if (end.DayOfWeek < start.DayOfWeek)
            {
                return result - 2;
            }
            else
            {
                return result;
            }
        }

        public static DateTime AddBusinessDays(DateTime date, int days)
        {
            if (days <= 0)
                return date;

            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                date = date.AddDays(2);
                days -= 1;
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
                days -= 1;
            }

            date = date.AddDays(days / 5 * 7);
            int extraDays = days % 5;

            if ((int)date.DayOfWeek + extraDays > 5)
            {
                extraDays += 2;
            }

            return date.AddDays(extraDays);
        }
    }
}
