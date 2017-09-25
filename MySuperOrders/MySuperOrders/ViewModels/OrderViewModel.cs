using GalaSoft.MvvmLight.Command;
using MySuperOrders.Models;
using MySuperOrders.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MySuperOrders.ViewModels
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryInformation { get; set; }
        public string Client { get; set; }
        public string Phone { get; set; }
        public bool IsDelivered { get; set; }


        private ApiService apiService;
        private DialogService dialogService;
        private NavigationService navigationService;

        public OrderViewModel()
        {
            DeliveryDate = DateTime.Today;
            apiService = new ApiService();
            dialogService = new DialogService();
            navigationService = new NavigationService();
        }


        public ICommand SaveCommand
        {
            get { return new RelayCommand(Save); }

        }

        private async void Save()
        {
            try
            {
                await apiService.CreateOrder(new Order()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = this.Title,
                    Client = this.Client,
                    DeliveryDate = this.DeliveryDate,
                    DeliveryInformation = this.DeliveryInformation,
                    Description = this.Description,
                    IsDelivered = false
                });
                await dialogService.ShowMessage("El pedido ha sido creado", "informacion");
                navigationService.Navigate("MainPageRefresh");
                
                
            }
            catch  
            {
                await dialogService.ShowMessage("Ha ocurrido un error", "Error");
            }
         
        }

    }
}
