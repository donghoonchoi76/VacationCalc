using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VacationCalculator.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            foreach (NavigationPage page in this.Children)
            {
                if(page.CurrentPage is SettingsPage settingPage)
                {
                    if(!settingPage.HasData())
                        this.CurrentPage = page;
                    break;
                }
            }
        }
    }
}