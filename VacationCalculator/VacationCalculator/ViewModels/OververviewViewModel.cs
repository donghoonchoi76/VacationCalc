using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace VacationCalculator.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        int initialDays = 7;
        int currentDays;
        int daysSpent;
        int nextDays;
        string nextDaysDate;

        DateTime beginingDate = new DateTime(2019, 2, 15);

        public OverviewViewModel()
        {
            Title = "Overview";
        }

        public int CurrentDays 
        {
            get { return currentDays; }
            set { SetProperty(ref currentDays, value); }
        }

        private int DaysSpent
        {
            get { return daysSpent; }
            set { SetProperty(ref daysSpent, value); }
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
            int totalDays = (int)(DateTime.Now - beginingDate).TotalDays / 35;
            DaysSpent = DataStore.ItemCount;
            CurrentDays = totalDays + initialDays - DaysSpent;
            NextDays = CurrentDays + 1;
            NextDaysDate = beginingDate.AddDays((totalDays + 1) * 35).ToLongDateString();
        }
    }
}
