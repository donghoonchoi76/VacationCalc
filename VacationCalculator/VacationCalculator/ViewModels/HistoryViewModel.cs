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
        bool isLoading = false;

        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public static int TotalVacations { get; set; }

        public HistoryViewModel()
        {
            Title = "History";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                if (Items.Where((Item arg) => arg.Date == newItem.Date).Count() > 0)
                    return;

                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<HistoryPage, string>(this, "DeleteItem", async (obj, id) =>
            {
                await DataStore.DeleteItemAsync(id);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (isLoading)
                return;

            IsBusy = true;
            isLoading = true;
            
            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                isLoading = false;
                IsBusy = false;
            }
        }
    }
}