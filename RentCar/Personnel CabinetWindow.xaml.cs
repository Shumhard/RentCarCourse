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
using RentCar;
using RentCar.Controls;
using Common;
using DbWorkers;
using Models;

namespace RentCar
{
    /// <summary>
    /// Логика взаимодействия для Personnel_CabinetWindow.xaml
    /// </summary>
    public partial class Personnel_CabinetWindow : Window
    {
        public Personnel_CabinetWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var client = DbClientWorker.GetClient(UserData.User.UserGuid.Value);
            var model = new PersonnelCabinetWindowModel
            {
                Login = client.Login,
                Password = client.Password,
                FirstName = client.FirstName,
                SecondName = client.LastName,
                Patronymic = client.Patronymic,
                Burthday = client.Birthday.ToString(),
                BankCard = client.BankCard,
                Email = client.Email,
                PassportNumber = client.PassportNumber,
                PassportSeria = client.PassportSeries,
                Phone = client.Phone,
                Sex = client.Sex,
                ImagePath = System.IO.Path.Combine(Settings.AttachedFiles, client.ImagePath)
            };
            DataContext = model;

            SetPersonnelInfo();
        }

        private void SetPersonnelInfo()
        {
            var infoContet = new PersonnelInfoControl();
            infoContet.EditStarted += OnEditStarted;
            PersonelInfoContent.Content = infoContet;
        }

        private void SetPersonnelInfoEdit()
        {
            var editInfoContet = new PersonnelInfoEditControl();
            editInfoContet.EditEnded += OnEditEnded;
            PersonelInfoContent.Content = editInfoContet;
        }

        private void OnEditStarted(object sender, EventArgs e)
        {
            SetPersonnelInfoEdit();
        }

        private void OnEditEnded(object sender, EventArgs e)
        {
            SetPersonnelInfo();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var orderWindow = new OrderWindow();
            orderWindow.Owner = this;
            orderWindow.ShowDialog();
        }
    }
}
