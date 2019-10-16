using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace VacationCalculator.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        int initialDays = 7;
        DateTime beginingDate = new DateTime(2019, 2, 15);

        public OverviewViewModel()
        {
            Title = "Overview";
        }

        public int CurrentDays 
        {
            get
            {
                return (int)(DateTime.Now - beginingDate).TotalDays / 42 + initialDays - DaysSpent;
            }
        }

        private int DaysSpent
        {
            get
            {
                return DataStore.ItemCount;
            }
        }

        public int OneMoreDays { get { return CurrentDays + 1; } }
        public string OneMoreDaysDate
        {
            get
            {
                return beginingDate.AddDays((((int)(DateTime.Now - beginingDate).TotalDays / 42) + 1) * 42).ToLongDateString();
            }
        }
    }
}
