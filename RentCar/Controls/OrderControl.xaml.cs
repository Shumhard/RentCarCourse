using Models;
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
using Extentions;

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

        private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window?.Close();
        }

        private void OrderBtn_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckInputs();

                if (CompleteStarted != null)
                {
                    CompleteStarted(this, new EventArgs());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            var model = (OrderWindowModel)window.DataContext;
            DataContext = model;

            var areaList = DbReferenceWorker.GetAreaReference(model.City);
            AreaCmb.ItemsSource = areaList;

            if(model.Area != null)
            {
                AreaCmb.SelectedValue = model.Area.Guid;
            }            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //var checkBox = (CheckBox)sender;
            //var model = (AdditionalService)checkBox.DataContext;
            //((OrderWindowModel)DataContext).TotalCost += model.Price;
            UpdateTotalCost();
        }

        private void AreaCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTotalCost();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //var checkBox = (CheckBox)sender;
            //var model = (AdditionalService)checkBox.DataContext;
            //((OrderWindowModel)DataContext).TotalCost -= model.Price;
            UpdateTotalCost();
        }

        private void BeginRentDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTotalCost();
        }

        private void EndRentDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTotalCost();
        }

        private void CheckInputs()
        {
            var model = (OrderWindowModel)DataContext;
            if (model.BeginRentDate == null || model.EndRentDate == null)
            {
                throw new Exception("Диапазон дат проката не задан");
            }

            if (model.BeginRentDate > model.EndRentDate)
            {
                throw new Exception("Дата начала больше даты окончания");
            }

            if(AreaCmb.SelectedIndex == -1)
            {
                throw new Exception("Район проката не выбран");
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                throw new Exception("Имя клиента не выбрано");
            }
        }

        private void UpdateTotalCost()
        {
            var model = (OrderWindowModel)DataContext;
            if (model.BeginRentDate != null && model.EndRentDate != null)
            {
                if (model.BeginRentDate > model.EndRentDate)
                {
                    MessageBox.Show("Дата начала больше даты окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var area = AreaCmb.SelectedIndex > -1 ? (Common.Area)AreaCmb.SelectedItem : null;

                model.TotalCost = ((model.EndRentDate.Value - model.BeginRentDate.Value).TotalDays + 1) * model.Car.Price * (area == null ? 1.0 : area.PriceMultiplier);
                model.TotalCost += (model.AdditionalServices.Where(x => x.Checked).Sum(x => x.Price));
            }
        }
    }
}
