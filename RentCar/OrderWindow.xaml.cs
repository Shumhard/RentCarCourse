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
using Models;

namespace RentCar
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public static bool CreateOrder(Window owner, Guid carGuid)
        {
            try
            {
                var orderWindow = new OrderWindow(null, carGuid);
                orderWindow.Owner = owner;
                orderWindow.ShowDialog();

                var model = (OrderWindowModel)orderWindow.DataContext;
                return model.IsSuccess;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public static OrderWindowModel EditOrder(Window owner, Guid orderGuid)
        {
            try
            {
                var orderWindow = new OrderWindow(orderGuid, null);
                orderWindow.Owner = owner;
                orderWindow.ShowDialog();

                var model = (OrderWindowModel)orderWindow.DataContext;
                return model.IsSuccess ? model : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public OrderWindow()
        {
            InitializeComponent();
            
            var model = new OrderWindowModel
            {
                OrderGuid = Guid.Empty,
                AdditionalServices = DbReferenceWorker.GetAdditionalServiceReference()
            };
            DataContext = model;
        }

        public OrderWindow(Guid? orderGuid, Guid? carGuid)
        {
            InitializeComponent();

            if(orderGuid == null && carGuid == null)
            {
                throw new Exception("Отсутствуют данные для заказа");
            }
            
            var model = orderGuid == null ? CreateModelByCar(carGuid.Value) : CreateModelByOrder(orderGuid.Value);
            DataContext = model;
        }

        private OrderWindowModel CreateModelByCar(Guid carGuid)
        {
            var model = new OrderWindowModel()
            {
                Car = DbCarWorker.GetCar(carGuid),
                AdditionalServices = DbReferenceWorker.GetAdditionalServiceReference()
            };

            return model;
        }

        private OrderWindowModel CreateModelByOrder(Guid orderGuid)
        {
            var order = DbOrderWorker.GetOrder(orderGuid);
            var additionalServices = DbReferenceWorker.GetAdditionalServiceReference();
            foreach(var serviceGuid in order.AdditonalServiceGuids)
            {
                var service = additionalServices.SingleOrDefault(x => x.Guid == serviceGuid);
                if(service != null)
                {
                    service.Checked = true;
                }
            }

            var model = new OrderWindowModel()
            {
                OrderGuid = order.Guid,
                AdditionalServices = additionalServices,
                Area = order.Area,
                BeginRentDate = order.RentBeginDate,
                EndRentDate = order.RentEndDate,
                Name = order.Name,
                TotalCost = order.TotalCost ?? 0,
                Car = order.Car,
                IsEdit = true
            };

            return model;
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
            control.CompleteSuccessed += OnCompleteSuccessed;
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

        private void OnCompleteSuccessed(object sender, EventArgs e)
        {
            var model = (OrderWindowModel)DataContext;
            model.IsSuccess = true;
            Close();
        }
    }
}
