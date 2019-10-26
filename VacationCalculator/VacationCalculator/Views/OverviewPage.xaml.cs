using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationCalculator.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VacationCalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverviewPage : ContentPage
    {
        public OverviewPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("!!!!!!!!!!!!! OnAppearing Overview page");
            (BindingContext as OverviewViewModel).Refresh();
        }
    }
}