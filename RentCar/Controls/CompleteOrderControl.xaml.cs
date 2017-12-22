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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RentCar.Models;
using Common;

namespace RentCar.Controls
{
    /// <summary>
    /// Interaction logic for CompleteOrderControl.xaml
    /// </summary>
    public partial class CompleteOrderControl : UserControl
    {
        public event EventHandler CompleteCanceled;
        public event EventHandler CompleteSuccessed;

        public CompleteOrderControl()
        {
            InitializeComponent();
        }

        private void CompleteBtn_OnClick(object sender, RoutedEventArgs e)
        {           
            var window = (OrderWindow)(Window.GetWindow(this));
            OrderWindowModel orderWindowModel = (OrderWindowModel)window.DataContext;
            Order order = new Order();

            order.Guid = Guid.NewGuid();
            order.Address = orderWindowModel.City;
            order.Area = orderWindowModel.Area;
            order.Car = orderWindowModel.Car;
            order.OrderDate = DateTime.Now;
            order.DeliveryDate = Convert.ToDateTime(orderWindowModel.BeginRentDate);
            order.ExpirationDate = Convert.ToDateTime(orderWindowModel.EndRentDate);
            order.TotalCost = orderWindowModel.TotalCost;
            order.ServicesList = new List<string>();
            foreach (var service in orderWindowModel.AdditionalServices)
                order.ServicesList.Add(service.Name);
            if ((bool)this.PayBank.IsChecked)
                order.Status = OrderStatus.InProgressPaid;
            if ((bool)this.PayCash.IsChecked)
                order.Status = OrderStatus.InProgressNotPaid;

            // TODO
            //DbWorkers.DbOrderWorker.AddOrder(order);
            //DbWorkers.DbOrderWorker.UpdateOrder(order);

            order.Car.LowRentalDate = order.DeliveryDate;
            order.Car.HighRentalDate = (DateTime)order.ExpirationDate;
            if (order.Car.LowRentalDate.Date.CompareTo(DateTime.Now.Date) == 0)
                order.Car.Status = CarStatus.Busy;

            //DbWorkers.DbCarWorker.UpdateCar(order.Car);

            if (CompleteSuccessed != null)
            {
                CompleteSuccessed(this, new EventArgs());
            }
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (CompleteCanceled != null)
            {
                CompleteCanceled(this, new EventArgs());
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            var model = (OrderWindowModel)window.DataContext;

            DataContext = model;
        }
    }
}
