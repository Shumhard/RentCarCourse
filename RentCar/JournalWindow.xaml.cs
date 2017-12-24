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
using Common;
using DbWorkers;
using Extentions;
using Models;
using RentCar;

namespace RentCar
{
    /// <summary>
    /// Логика взаимодействия для JournalWindow.xaml
    /// </summary>
    public partial class JournalWindow : Window
    {
        public JournalWindow()
        {
            InitializeComponent();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var element = (Button)sender;
            var model = (OrderModel)element.DataContext;

            var result = OrderWindow.EditOrder(this, model.Guid);
            if(result != null)
            {
                model.Area = result.Area.Name;
                model.RentRange = string.Format("{0} - {1}", result.BeginRentDate.Value.ToShortDateString(), result.EndRentDate.Value.ToShortDateString());
                model.PriceString = result.TotalCost.ToString() + " рублей";
                model.ServicesList = result.AdditionalServices.Where(x => x.Checked).Select(x => x.Name).ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: Получение заказов клиента

            var orders = DbWorkers.DbOrderWorker.GetClientOrders(UserData.User.UserGuid.Value);

            var model = new JournalWindowModel
            {
                Orders = new System.Collections.ObjectModel.ObservableCollection<OrderModel>(orders)
            };
            DataContext = model;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var element = (Hyperlink)sender;
            var model = (OrderModel)element.DataContext;

            if (DbOrderWorker.CancelOrder(model.Guid))
            {
                model.StatusString = OrderStatus.Canceled.DescriptionAttr();
            }
        }
    }
}
