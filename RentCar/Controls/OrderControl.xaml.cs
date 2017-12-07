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

namespace RentCar.Controls
{
    /// <summary>
    /// Логика взаимодействия для OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        public event EventHandler CompleteStarted;

        public OrderControl()
        {
            InitializeComponent();
        }

        private void OrderCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window?.Close();
        }

        private void OrderBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (CompleteStarted != null)
            {
                CompleteStarted(this, new EventArgs());
            }
        }
    }
}
