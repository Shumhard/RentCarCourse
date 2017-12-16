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
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Сохранение новой инфы о клиенте

            Close();
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
