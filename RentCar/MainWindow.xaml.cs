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
using DbWorkers;
using Models;
using Extentions;
using System.Collections.ObjectModel;

namespace RentCar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window _personnelWindow = null;
        OrderDirections _directions;

        public MainWindow()
        {
            InitializeComponent();

            _directions = new OrderDirections
            {
                ModelDirection = OrderDirection.Down,
                YearDirection = OrderDirection.Down,
                PriceDirection = OrderDirection.Down
            };

            var model = new MainWindowModel();
            model.IsAuthorized = false;
            model.CityList = DbReferenceWorker.GetCityReference();
            model.MarkList = DbReferenceWorker.GetMarkReference();
            model.ModelList = DbReferenceWorker.GetModelReference();
            model.TypeList = DbReferenceWorker.GetTypeReference();
            DataContext = model;
        }

        public MainWindow(bool isAuthorized)
        {
            InitializeComponent();



            _directions = new OrderDirections
            {
                ModelDirection = OrderDirection.Down,
                YearDirection = OrderDirection.Down,
                PriceDirection = OrderDirection.Down
            };

            var model = new MainWindowModel();
            model.IsAuthorized = isAuthorized;
            model.CityList = DbReferenceWorker.GetCityReference();
            model.MarkList = DbReferenceWorker.GetMarkReference();
            model.ModelList = DbReferenceWorker.GetModelReference();
            model.TypeList = DbReferenceWorker.GetTypeReference();
            DataContext = model;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: Получение списка автомобилей
            GetCarsByFilter();
        }
        
        private void PersonnelCabinetBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_personnelWindow != null)
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
            foreach(Window window in windows)
            {
                window.Close();
            }
        }

        private void OrderListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderListBox.SelectedIndex > -1)
            {
                var model = (MainWindowModel) DataContext;
                if (model.IsAuthorized)
                {
                    var selectedCarModel = (CarModel)OrderListBox.SelectedItem;
                    var result = OrderWindow.CreateOrder(this, selectedCarModel.Guid);
                    selectedCarModel.IsEnabled = !result;
                }

                OrderListBox.SelectedIndex = -1;
            }
        }

        private void PriceOrder_OnClick(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowModel)DataContext;
            if(_directions.PriceDirection == OrderDirection.Down)
            {
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Price));
                _directions.PriceDirection = OrderDirection.Up;
            }
            else
            {
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderBy(x => x.Price));
                _directions.PriceDirection = OrderDirection.Down;
            }
        }

        private void YearOrder_OnClick(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowModel)DataContext;
            if (_directions.YearDirection == OrderDirection.Down)
            {
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.YearProduction));
                _directions.YearDirection = OrderDirection.Up;
            }
            else
            {
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderBy(x => x.YearProduction));
                _directions.YearDirection = OrderDirection.Down;
            }
        }

        private void ModelOrder_OnClick(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowModel)DataContext;
            if (_directions.ModelDirection == OrderDirection.Down)
            {
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderByDescending(x => x.Model));
                _directions.ModelDirection = OrderDirection.Up;
            }
            else
            {
                model.Cars = new ObservableCollection<CarModel>(model.Cars.OrderBy(x => x.Model));
                _directions.ModelDirection = OrderDirection.Down;
            }
        }

        private void SearchBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO: Выборка автомобилей по фильтру
            GetCarsByFilter();
        }

        private void ClearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO: Очистка фильтра

            var model = (MainWindowModel)DataContext;            
            model.SelectedCity = null;
            model.SelectedModel = null;
            model.SelectedMark = null;
            model.SelectedType = null;
            model.DateFrom = null;
            model.DateTo = null;
            model.PriceFrom = "";
            model.PriceTo = "";
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {            
            
        }

        private void GetCarsByFilter()
        {
            try
            {
                var model = (MainWindowModel)DataContext;
                var priceFrom = model.PriceFrom.ToDouble(null);
                var priceTo = model.PriceTo.ToDouble(null);

                if (model.DateFrom != null && model.DateTo != null && model.DateFrom > model.DateTo)
                {
                    throw new Exception("Неверный диапазон дат");
                }
                if (priceFrom != null && priceTo != null && priceFrom > priceTo)
                {
                    throw new Exception("Неверный диапазон цены");
                }

                var filter = new Common.Filter();
                filter.City = model.SelectedCity;
                filter.Model = model.SelectedModel;
                filter.Mark = model.SelectedMark;
                filter.Type = model.SelectedType;
                filter.DateFrom = model.DateFrom;
                filter.DateTo = model.DateTo;
                filter.PriceFrom = priceFrom;
                filter.PriceTo = priceTo;
                
                model.Cars = DbCarWorker.GetCarsByFilter(filter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //private ObservableCollection<CarModel> GetOrderedCars(ObservableCollection<CarModel> cars)
        //{
        //    IOrderedEnumerable<CarModel> orderCars = cars.OrderBy(x => x.IsEnabled);

        //    if (_directions.PriceDirection == OrderDirection.Down)
        //    {
        //        orderCars = orderCars.OrderBy(x => x.Price);
        //    }
        //    else
        //    {
        //        orderCars = orderCars.OrderByDescending(x => x.Price);
        //    }

        //    if (_directions.YearDirection == OrderDirection.Down)
        //    {
        //        orderCars = orderCars.OrderBy(x => x.YearProduction);
        //    }
        //    else
        //    {
        //        orderCars = orderCars.OrderByDescending(x => x.YearProduction);
        //    }

        //    if (_directions.ModelDirection == OrderDirection.Down)
        //    {
        //        orderCars = orderCars.OrderBy(x => x.Model);
        //    }
        //    else
        //    {
        //        orderCars = orderCars.OrderByDescending(x => x.Model);
        //    }

        //    return new ObservableCollection<CarModel>(orderCars);
        //}
    }

    public class OrderDirections
    {
        public OrderDirection PriceDirection;
        public OrderDirection YearDirection;
        public OrderDirection ModelDirection;
    }

    public enum OrderDirection
    {
        Down = 1,
        Up = 2
    }
}
