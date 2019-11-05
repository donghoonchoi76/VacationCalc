using System;
using System.Diagnostics;
using System.Windows.Input;
using VacationCalculator.Models;
using Xamarin.Forms;

namespace VacationCalculator.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        DateTime startDate = DateTime.Now.Date;
        DateTime endDate = DateTime.Now.Date;

        public NewItemViewModel()
        {
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                SetProperty(ref startDate, value.Date);
                if (endDate < startDate)
                    EndDate = startDate;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                if (value.Date < startDate)
                    return;

                SetProperty(ref endDate, value.Date);
            }
        }

        public string Description { get; set; }

        public void Save()
        {
            DateTime date = startDate;
            while (!(endDate < date))
            {
                Item item = new Item
                {   
                    Date = date.ToLongDateString(),
                    Description = Description
                };

                DataStore.SetItem(item);
                date = date.AddDays(1);
            }
        }

    }
}