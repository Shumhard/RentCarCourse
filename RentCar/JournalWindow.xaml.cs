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
using Models;

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
            var orderWindow = new OrderWindow();
            orderWindow.Owner = this;
            orderWindow.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: Получение заказов клиента

            var model = new JournalWindowModel
            {
                Orders = new List<OrderModel>()
            };
            model.Orders.Add(new OrderModel
            {
                ImgPath = @"C:\Users\shuhard93\Desktop\audi.jpg",
                OrderDate = DateTime.Now.Date.ToShortDateString(),
                RentRange = DateTime.Now.Date.ToShortDateString() + " - " + DateTime.Now.Date.ToShortDateString(),
                Area = "Каштак 2",
                PriceString = "1000.5 рублей",
                StatusString = "В процессе (не оплачен)",
                ServicesList = new List<string>(new string[] { "Капуччино", "Покер" })
            });
            model.Orders.Add(new OrderModel
            {
                ImgPath = @"C:\Users\shuhard93\Desktop\audi.jpg",
                OrderDate = DateTime.Now.Date.ToShortDateString(),
                RentRange = DateTime.Now.Date.ToShortDateString() + " - " + DateTime.Now.Date.ToShortDateString(),
                Area = "Каштак 2",
                PriceString = "1000.5 рублей",
                StatusString = "В процессе (не оплачен)"
            });
            model.Orders.Add(new OrderModel
            {
                ImgPath = @"C:\Users\shuhard93\Desktop\audi.jpg",
                OrderDate = DateTime.Now.Date.ToShortDateString(),
                RentRange = DateTime.Now.Date.ToShortDateString() + " - " + DateTime.Now.Date.ToShortDateString(),
                Area = "Каштак 2",
                PriceString = "1000.5 рублей",
                StatusString = "В процессе (не оплачен)"
            });
            model.Orders.Add(new OrderModel
            {
                ImgPath = @"C:\Users\shuhard93\Desktop\audi.jpg",
                OrderDate = DateTime.Now.Date.ToShortDateString(),
                RentRange = DateTime.Now.Date.ToShortDateString() + " - " + DateTime.Now.Date.ToShortDateString(),
                Area = "Каштак 2",
                PriceString = "1000.5 рублей",
                StatusString = "В процессе (не оплачен)"
            });
            model.Orders.Add(new OrderModel
            {
                ImgPath = @"C:\Users\shuhard93\Desktop\audi.jpg",
                OrderDate = DateTime.Now.Date.ToShortDateString(),
                RentRange = DateTime.Now.Date.ToShortDateString() + " - " + DateTime.Now.Date.ToShortDateString(),
                Area = "Каштак 2",
                PriceString = "1000.5 рублей",
                StatusString = "В процессе (не оплачен)"
            });
            model.Orders.Add(new OrderModel
            {
                ImgPath = @"C:\Users\shuhard93\Desktop\audi.jpg",
                OrderDate = DateTime.Now.Date.ToShortDateString(),
                RentRange = DateTime.Now.Date.ToShortDateString() + " - " + DateTime.Now.Date.ToShortDateString(),
                Area = "Каштак 2",
                PriceString = "1000.5 рублей",
                StatusString = "В процессе (не оплачен)"
            });
            DataContext = model;
        }
    }
}
