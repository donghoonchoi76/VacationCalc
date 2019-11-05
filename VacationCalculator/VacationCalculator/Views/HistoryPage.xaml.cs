using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VacationCalculator.Models;
using VacationCalculator.Views;
using VacationCalculator.ViewModels;
using System.Diagnostics;

namespace VacationCalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            // Manually deselect item.
            ItemsListView.SelectedItem = item;
        }

        void DeleteItem_Clicked(object sender, EventArgs e)
        {
            if(ItemsListView.SelectedItem is Item item)
            {
                MessagingCenter.Send(this, "DeleteItem", item.Date);
            }                
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as HistoryViewModel).LoadItemsCommand.Execute(null);
        }
    }
}

