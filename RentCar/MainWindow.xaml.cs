using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Collections.ObjectModel;
using DbWorkers;
using Models;

namespace RentCar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window _personnelWindow = null;
        bool sortByPriceState = false;
        bool sortByYearState = false;
        bool sortByModelState = false;

        public MainWindow()
        {            
        }

        public MainWindow(bool isAuthorized)
        {
            InitializeComponent();

            var model = new MainWindowModel();
            model.IsAuthorized = isAuthorized;

            model.Cars = new ObservableCollection<CarModel>();
            model.Cars.Add(new CarModel { ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 10.5, Visible = true });
            model.Cars.Add(new CarModel { ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 100.55, Visible = true });
            model.Cars.Add(new CarModel { ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 1.0, Visible = true });
            model.Cars.Add(new CarModel { ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 1000.50, Visible = true });
            
            model.CityList = DbReferenceWorker.GetCityReference();
            model.MarkList = DbReferenceWorker.GetMarkReference();
            model.ModelList = DbReferenceWorker.GetModelReference();
            model.TypeList = DbReferenceWorker.GetTypeReference();
            DataContext = model;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.HighDate.Text = "21/12/12";
            this.LowDate.Text = "12/12/12";
            //TODO: Получение списка автомобилей
        }

        private void PersonnelCabinetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_personnelWindow != null)
            {
                _personnelWindow.Focus();
            }
            else
            {
                _personnelWindow = new Personnel_CabinetWindow();
                _personnelWindow.Closed += OnPersonnelCabinetClosed;
                _personnelWindow.Show();
            }
        }

        private void OnPersonnelCabinetClosed(object sender, EventArgs e)
        {
            _personnelWindow = null;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var windows = Application.Current.Windows;
            foreach (Window window in windows)
            {
                window.Close();
            }
        }

        private void OrderListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderListBox.SelectedIndex > -1)
            {
                var model = (MainWindowModel)DataContext;
                if (model.IsAuthorized)
                {
                    var orderWindow = new OrderWindow();
                    orderWindow.Owner = this;
                    orderWindow.ShowDialog();
                }

                OrderListBox.SelectedIndex = -1;
            }
        }

        private void PriceOrder_OnClick(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowModel)this.DataContext;
            if (sortByPriceState)
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderBy(x => x.Price));
            else
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Price));
            this.sortByPriceState = !sortByPriceState;
        }

        private void YearOrder_OnClick(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowModel)this.DataContext;
            if (sortByYearState)
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderBy(x => x.YearProduction));
            else
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.YearProduction));
            this.sortByYearState = !sortByYearState;
        }

        private void ModelOrder_OnClick(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowModel)this.DataContext;
            if (sortByModelState)
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderBy(x => x.Model));
            else
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Model));
            this.sortByModelState = !sortByModelState;
        }

        // stuff -------------
        private void CityCmb_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void MarkCmb_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void ModelCmb_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void TypeCmb_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        // stuff -------------

        private void SearchBtn_OnClick(object sender, RoutedEventArgs e)
        {
            double _highPrice = 0, _lowPrice = 0;
            DateTime _highDate, _lowDate;
            string _city, _model, _mark, _type;
            try
            {
                _city = this.CityCmb.SelectedItem.ToString();
                _model = this.ModelCmb.SelectedItem.ToString();
                _mark = this.MarkCmb.SelectedItem.ToString();
                _type = this.TypeCmb.SelectedItem.ToString();
                _highPrice = Convert.ToDouble(this.HighPrice.Text.ToString());
                _lowPrice = Convert.ToDouble(this.LowPrice.Text.ToString());
                _highDate = Convert.ToDateTime(this.HighDate.Text.ToString());
                _lowDate = Convert.ToDateTime(this.LowDate.Text.ToString());
                if (_highPrice < _lowPrice) throw new Exception();
                if (_highDate.CompareTo(_lowDate) < 0) throw new Exception();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Фильтр задан не корректно!");
                return;
            }

            var model = (MainWindowModel)this.DataContext;
            foreach (var car in model.Cars)
            {
                if (car.City.CompareTo(_city) != 0 ||
                    car.Model.CompareTo(_model) != 0 ||
                    car.Mark.CompareTo(_mark) != 0 ||
                    car.Type.CompareTo(_type) != 0 ||
                    car.Price.CompareTo(_highPrice) > 0 ||
                    car.Price.CompareTo(_lowPrice) < 0 ||
                    car.RentalDate.HighDate.CompareTo(_highDate) > 0 ||
                    car.RentalDate.LowDate.CompareTo(_lowDate) < 0)
                    car.Visible = false;
            }
            model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Visible));
        }

        private void ClearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowModel)this.DataContext;
            foreach (var car in model.Cars)
                car.Visible = true;
            model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Visible));
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
