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
        }

        private void OrderWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
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
