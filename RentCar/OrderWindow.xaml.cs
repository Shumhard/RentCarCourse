using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RentCar.Controls;
using DbWorkers;
using RentCar.Models;
using Common;

namespace RentCar
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();

            var additionalServices = DbReferenceWorker.GetAdditionalServiceReference();
            
            var model = new OrderWindowModel
            {
                OrderGuid = Guid.Empty,
                AdditionalServices = additionalServices.Select(x => new AdditionalService { Checked = false, Name = x.Name }).ToList()
            };
            DataContext = model;
        }

        public void LoadOrderByOrderGuid(Guid orderGuid)
        {
            var order = DbOrderWorker.GetOrder(orderGuid);
            ((OrderWindowModel)this.DataContext).Car = order.Car;
        }

        public void CreateOrderByCar(Car car)
        {
            ((OrderWindowModel)this.DataContext).Car = car;
        }

        private void OrderWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var model = (OrderWindowModel)DataContext;

            SetOrderControl();
        }

        private void SetOrderControl()
        {
            this.Title = "Заказ";
            var control = new OrderControl();
            control.CompleteStarted += OnCompleteStarted;
            MainControl.Content = control;
        }

        private void SetCompleteOrderControl()
        {
            this.Title = "Подтвердить заказ";
            var control = new CompleteOrderControl();
            control.CompleteCanceled += OnCompleteCanceled;
            MainControl.Content = control;
        }

        private void OnCompleteStarted(object sender, EventArgs e)
        {
            SetCompleteOrderControl();
        }

        private void OnCompleteCanceled(object sender, EventArgs e)
        {
            SetOrderControl();
        }
    }
}
