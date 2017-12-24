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
using Common;
using DbWorkers;
using Extentions;
using Models;

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
            //TODO: Создание нового Заказа

            var model = (OrderWindowModel)DataContext;

            var order = new Order
            {
                Guid = model.IsEdit ? model.OrderGuid : Guid.NewGuid(),
                ClientGuid = UserData.User.UserGuid.Value,
                Car = model.Car,
                Name = model.Name,
                OrderDate = DateTime.Now.Date,
                TotalCost = model.TotalCost,
                RentBeginDate = model.BeginRentDate.Value,
                RentEndDate = model.EndRentDate.Value,
                AdditonalServiceGuids = model.AdditionalServices.Where(x => x.Checked).Select(x => x.Guid).ToList(),
                Area = model.Area,
                PaymentType = CashBtn.IsChecked.Value ? PaymentType.Cash : PaymentType.BankCard
            };

            if (model.IsEdit)
            {
                if (DbOrderWorker.UpdateOrder(order))
                {
                    if (CompleteSuccessed != null)
                    {
                        CompleteSuccessed(this, new EventArgs());
                    }
                }
            }
            else
            {
                if (DbOrderWorker.AddOrder(order))
                {
                    order.Car.Status = CarStatus.Busy;
                    DbCarWorker.UpdateCar(model.Car);

                    if (CompleteSuccessed != null)
                    {
                        CompleteSuccessed(this, new EventArgs());
                    }
                }
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
