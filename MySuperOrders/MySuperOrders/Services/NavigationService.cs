using MySuperOrders.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MySuperOrders.Services
{
    public class NavigationService
    {

        public async void Navigate(string pageName)
        {
            App.Master.IsPresented = false;
            switch (pageName)
            {
                case "AlarmsPage":
                    await Navigate(new AlarmsPage());
                    break;
                case "ClientsPage":
                    await Navigate(new ClientsPage());
                    break;
                case "SettingsPage":
                    await Navigate(new SettingsPage());
                    break;
                case "NewOrderPage":
                    await Navigate(new NewOrderPage());
                    break;
                case "MainPage":
                    await App.Navigator.PopToRootAsync();
                    break;
                default:
                    await App.Navigator.PopToRootAsync();
                    break;
            }
        }

        private static async Task Navigate<T>(T page) where T: Page
        {
           // NavigationPage.SetHasBackButton(page, false);
          //  NavigationPage.SetBackButtonTitle(page, "Atrás"); //IOS
    

            await App.Navigator.PushAsync(page);
        }

        internal void SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "MasterPage":
                    App.Current.MainPage = new MasterPage();
                    break;
                default:
                    break;
            }
          
        }
    }
}
