using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using VacationCalculator.Models;
using VacationCalculator.Views;
using System.Linq;

namespace VacationCalculator.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public static int TotalVacations { get; set; }

        public HistoryViewModel()
        {
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(() => {                
                ExecuteLoadItemsCommand();
            }); 

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", (obj, item) =>
            {
                var newItem = item as Item;
                if (Items.Where((Item arg) => arg.Date == newItem.Date).Count() > 0)
                    return;

                Items.Add(newItem);
                DataStore.SetItem(newItem);
                ExecuteLoadItemsCommand();
            });

            MessagingCenter.Subscribe<HistoryPage, string>(this, "DeleteItem", (obj, id) =>
            {
                Item item = DataStore.GetItem(id);
                if (item != null)
                {
                    Items.Remove(item);                    
                }                    
                DataStore.DeleteItem(id);
                ExecuteLoadItemsCommand();
            });
        }

        void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
            {
                return;
            }   

            IsBusy = true;
            try
            {
                Items.Clear();
                var items = DataStore.GetItems(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}