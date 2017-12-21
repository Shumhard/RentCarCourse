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
using Models;

namespace RentCar.Controls
{
    /// <summary>
    /// Логика взаимодействия для PersonnelInfoControl.xaml
    /// </summary>
    public partial class PersonnelInfoControl : UserControl
    {
        public event EventHandler EditStarted;

        public PersonnelInfoControl()
        {
            InitializeComponent();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if(EditStarted != null)
            {
                EditStarted(this, new EventArgs());
            }
        }

        private void JournalBtn_Click(object sender, RoutedEventArgs e)
        {
            var journalWindow = new JournalWindow();
            journalWindow.Owner = Window.GetWindow(this);
            journalWindow.ShowDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: Получение данных о клиенте

            //var window = Window.GetWindow(this);
            //var model = (PersonnelCabinetWindowModel)window.DataContext;
            //DataContext = model;

            var window = Window.GetWindow(this);
            var model = (PersonnelCabinetWindowModel)window.DataContext;
            model.setClientInfo(DbWorkers.DbClientWorker.GetClient(model.Guid));
            DataContext = model;
        }
    }
}