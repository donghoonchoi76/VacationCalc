using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VacationCalculator.Models;

namespace VacationCalculator.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {   
        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Description { get; set; }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Item item = new Item
            {
                Id = Guid.NewGuid().ToString(),
                Date = Date.ToLongDateString(),
                Description = Description
            };

            MessagingCenter.Send(this, "AddItem", item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}