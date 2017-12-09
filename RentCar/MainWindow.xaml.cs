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
using Models;

namespace RentCar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window _personnelWindow = null;

        public MainWindow()
        {
            InitializeComponent();

            var model = new MainWindowModel();
            model.IsAuthorized = true;
            model.Cars = new List<CarModel>();
            model.Cars.Add(new CarModel {ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 1.0 });
            model.Cars.Add(new CarModel { ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 10.5 });
            model.Cars.Add(new CarModel { ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 100.55 });
            model.Cars.Add(new CarModel { ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 1000.50 });
            DataContext = model;
        }

        public MainWindow(bool isAuthorized)
        {
            InitializeComponent();

            var model = new MainWindowModel();
            model.IsAuthorized = isAuthorized;
            model.Cars = new List<CarModel>();
            model.Cars.Add(new CarModel { ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 1.0 });
            model.Cars.Add(new CarModel { ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 10.5 });
            model.Cars.Add(new CarModel { ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 100.55 });
            model.Cars.Add(new CarModel { ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg", Model = "Mazda", Price = 1000.50 });
            DataContext = model;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
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
                    var orderWindow = new OrderWindow();
                    orderWindow.Owner = this;
                    orderWindow.ShowDialog();
                }

                OrderListBox.SelectedIndex = -1;
            }
        }

        private void PriceOrder_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void YearOrder_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ModelOrder_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

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

        private void SearchBtn_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ClearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {            
            
        }
    }
}
