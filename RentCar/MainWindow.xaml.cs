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
using Common;

namespace RentCar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Window _personnelWindow = null;
        private bool sortByPriceState = false;
        private bool sortByYearState = false;
        private bool sortByModelState = false;

        public MainWindow() { ; }
        public MainWindow(bool isAuthorized)
        {
            InitializeComponent();

            var model = new MainWindowModel();
            model.IsAuthorized = isAuthorized;
            
            // debug ----------------------------
            var cars = new List<Car>();
            model.Cars = new ObservableCollection<CarModel>();            
            for (int i = 2; i < 12; i++)
            {
                Car car = new Car();
                car.Guid = Guid.NewGuid();
                car.City = "Томск";
                car.HighRentalDate = Convert.ToDateTime("10/12/15");
                car.HighRentalDate = Convert.ToDateTime("10/12/17");
                car.Mark = "mazda";
                car.Model = "cx-5";
                car.Type = "Crossover";
                car.Mileage = 20005;
                car.Photo = @"F:\r2-d2.jpg";
                car.YearProduction = 2015;
                car.Status = CarStatus.Free;
                car.Price = 50 * i;
                cars.Add(car);
            }
            // debug ----------------------------

            //cars = DbCarWorker.GetCars();
            //model.Cars = new ObservableCollection<CarModel>();
            foreach (var car in cars) 
            {
                CarModel carModel = new CarModel(car);
                model.Cars.Add(carModel);
            }
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
                    var _carModel = (CarModel)((sender as ListBox).SelectedItem);
                    orderWindow.CreateOrderByCar(_carModel.Car);
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
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Visible).ThenBy(x => x.Car.Price));
            else
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Visible).ThenByDescending(x => x.Car.Price));
            this.sortByPriceState = !sortByPriceState;
        }

        private void YearOrder_OnClick(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowModel)this.DataContext;
            if (sortByYearState)
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Visible).ThenBy(x => x.Car.YearProduction));
            else
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Visible).ThenByDescending(x => x.Car.YearProduction));
            this.sortByYearState = !sortByYearState;
        }

        private void ModelOrder_OnClick(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowModel)this.DataContext;
            if (sortByModelState)
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Visible).ThenBy(x => x.Car.Model));
            else
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Visible).ThenByDescending(x => x.Car.Model));
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
            DateTime _now = DateTime.Now;
            string _city, _model, _mark, _type;
            try
            {
                _city = this.CityCmb.SelectedItem == null? "" : this.CityCmb.SelectedItem.ToString();
                _model = this.ModelCmb.SelectedItem == null ? "" : this.ModelCmb.SelectedItem.ToString();
                _mark = this.MarkCmb.SelectedItem == null ? "" : this.MarkCmb.SelectedItem.ToString();
                _type = this.TypeCmb.SelectedItem == null ? "" : this.TypeCmb.SelectedItem.ToString();
                _highPrice = this.HighPrice.Text.ToString() == ""? 0 : Convert.ToDouble(this.HighPrice.Text.ToString());
                _lowPrice = this.LowPrice.Text.ToString() == "" ? 0 : Convert.ToDouble(this.LowPrice.Text.ToString());
                _highDate = this.HighDate.Text.ToString() == ""? new DateTime() : Convert.ToDateTime(this.HighDate.Text.ToString());
                _lowDate = this.LowDate.Text.ToString() == "" ? new DateTime() : Convert.ToDateTime(this.LowDate.Text.ToString());
                if (_highPrice < _lowPrice) 
                    throw new Exception();
                if (_lowDate.Year != 1 && _lowDate.CompareTo(_now) < 0) 
                    throw new Exception();               
                if (_highDate.Year != 1 && _lowDate.Year != 1 && 
                    _highDate.CompareTo(_lowDate) <= 0) 
                    throw new Exception();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Фильтр задан не корректно!");
                return;
            }

            var model = (MainWindowModel)this.DataContext;
            foreach (var carmod in model.Cars)
            {
                if ((_city != "" && carmod.Car.City.CompareTo(_city) != 0) ||
                    (_model != "" && carmod.Car.Model.CompareTo(_model) != 0) ||
                    (_mark != "" && carmod.Car.Mark.CompareTo(_mark) != 0) ||
                    (_type != "" && carmod.Car.Type.CompareTo(_type) != 0) ||
                    (_highPrice != 0 && carmod.Car.Price.CompareTo(_highPrice) > 0) ||
                    (_lowPrice != 0 && carmod.Price.CompareTo(_lowPrice) < 0) ||
                    (_highDate.Year != 1 && !((carmod.Car.HighRentalDate.CompareTo(_highDate) < 0 && carmod.Car.LowRentalDate.CompareTo(_highDate) <= 0) ||
                    (carmod.Car.HighRentalDate.CompareTo(_highDate) > 0 && carmod.Car.LowRentalDate.CompareTo(_highDate) > 0))) ||
                    (_lowDate.Year != 1 && !((carmod.Car.HighRentalDate.CompareTo(_lowDate) <= 0 && carmod.Car.LowRentalDate.CompareTo(_lowDate) < 0) ||
                    (carmod.Car.HighRentalDate.CompareTo(_lowDate) > 0 && carmod.Car.LowRentalDate.CompareTo(_lowDate) > 0))))
                {
                    carmod.Enable = false;
                    carmod.Visible = false;                    
                }                    
            }
            model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Visible));
        }

        private void ClearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowModel)this.DataContext;
            foreach (var carmod in model.Cars)
            {
                carmod.Enable = true;
                carmod.Visible = true;                
            }                
            model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Visible));
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
