﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using VacationCalculator.Models;
using VacationCalculator.ViewModels;

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
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            (BindingContext as NewItemViewModel).Save();
                        
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}