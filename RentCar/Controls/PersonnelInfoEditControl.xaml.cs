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
using Common;
using DbWorkers;
using Extentions;
using Models;

namespace RentCar.Controls
{
    /// <summary>
    /// Логика взаимодействия для PersonnelInfoEdit.xaml
    /// </summary>
    public partial class PersonnelInfoEditControl : UserControl
    {
        public event EventHandler EditEnded;

        public PersonnelInfoEditControl()
        {
            InitializeComponent();
        }

        private void LoadImageBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Загрузка новой аватарки клиента

            var imageFileDialog = new Microsoft.Win32.OpenFileDialog();
            imageFileDialog.DefaultExt = ".png";
            imageFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            imageFileDialog.Title = "Выберите изображение";

            if(imageFileDialog.ShowDialog() == true)
            {
                EditImage.Source = new BitmapImage(new Uri(imageFileDialog.FileName));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Сохранение новой инфы о клиенте

            try
            {
                var uri = new Uri(((BitmapFrame)EditImage.Source).Decoder.ToString());

                var client = new Client
                {
                    Guid = UserData.User.UserGuid.Value,
                    Login = LoginTxt.Text,
                    Password = Password.Password,
                    FirstName = FirstNameTxt.Text,
                    LastName = SecondNameTxt.Text,
                    Patronymic = PatronymicTxt.Text,
                    Birthday = Burthday.SelectedDate,
                    Sex = SexCmb.SelectedIndex > -1 ? SexCmb.SelectedValue.ToString() : null,
                    Email = EmailTxt.Text,
                    Phone = PhoneTxt.Text,
                    PassportNumber = PassportNumberTxt.Text,
                    PassportSeries = PassportSeriaTxt.Text,
                    BankCard = BankCard.Text,
                    ImagePath = @"Users\" + System.IO.Path.GetFileName(uri.AbsolutePath)
                };

                if(DbClientWorker.UpdateClient(client))
                {
                    var imagePath = System.IO.Path.Combine(Settings.AttachedFiles, client.ImagePath);
                    if (!System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Copy(uri.AbsolutePath, System.IO.Path.Combine(Settings.AttachedFiles, client.ImagePath));
                    }

                    var model = (PersonnelCabinetWindowModel)DataContext;
                    model.Login = client.Login;
                    model.Password = client.Password;
                    model.FirstName = client.FirstName;
                    model.SecondName = client.LastName;
                    model.Patronymic = client.Patronymic;
                    model.Burthday = client.Birthday.ToString();
                    model.Sex = client.Sex;
                    model.Email = client.Email;
                    model.Phone = client.Phone;
                    model.PassportNumber = client.PassportNumber;
                    model.PassportSeria = client.PassportSeries;
                    model.BankCard = client.BankCard;
                    model.ImagePath = imagePath;

                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close()
        {
            if(EditEnded != null)
            {
                EditEnded(this, new EventArgs());
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            var model = (PersonnelCabinetWindowModel)window.DataContext;
            DataContext = model;

            Password.Password = model.Password;
            var sexList = DbReferenceWorker.GetSexReference();
            SexCmb.ItemsSource = sexList;
        }
    }
}
