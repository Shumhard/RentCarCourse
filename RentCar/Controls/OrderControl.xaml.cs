using RentCar.Models;
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
using DbWorkers;

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
            window.Close();
        }

        private void OrderBtn_OnClick(object sender, RoutedEventArgs e)
        {
            DateTime _highDate, _lowDate;
            DateTime _now = DateTime.Now;
            string _area;

            try
            {
                _highDate = Convert.ToDateTime(this.EndRentDate.Text.ToString());
                _lowDate = Convert.ToDateTime(this.BeginRentDate.Text.ToString());
                if (_highDate.CompareTo(_lowDate) <= 0) throw new Exception();
                if (_lowDate.CompareTo(_now) < 0) throw new Exception();
            }
            catch
            {
                MessageBox.Show("Дата указана не корректно!");
                return;
            }
            try
            {
                _area = this.AreaCmb.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Выберите район проката!");
                return;
            }

            var window = (OrderWindow)(Window.GetWindow(this));
            OrderWindowModel orderWindowModel = (OrderWindowModel)window.DataContext;

            if (orderWindowModel.Car.CheckBusyness(_lowDate, _highDate))
            {
                MessageBox.Show("В этот промежуток машина недоступна!");
                return;
            }

            if (CompleteStarted != null)
            {
                CompleteStarted(this, new EventArgs());
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            var model = (OrderWindowModel)window.DataContext;
            DataContext = model;

            model.City = model.Car.City;
            var areaList = DbReferenceWorker.GetAreaReference(model.City);
            AreaCmb.ItemsSource = areaList;
        }
    }
}
