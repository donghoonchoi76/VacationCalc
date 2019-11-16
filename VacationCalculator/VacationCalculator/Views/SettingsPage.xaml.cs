using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using VacationCalculator.ViewModels;
using VacationCalculator.Models;

namespace VacationCalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        public bool HasData()
        {   
            return (BindingContext as SettingsViewModel).HasData();
        }
    }
}