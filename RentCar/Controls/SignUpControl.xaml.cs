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

namespace RentCar.Controls
{
    /// <summary>
    /// Логика взаимодействия для SignUpControl.xaml
    /// </summary>
    public partial class SignUpControl : UserControl
    {
        public event EventHandler RegisterEnded;

        public SignUpControl()
        {
            InitializeComponent();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Создание нового клиента

            if(RegisterEnded != null)
            {
                RegisterEnded(this, new EventArgs());
            }
        }

        private void SignUpCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RegisterEnded != null)
            {
                RegisterEnded(this, new EventArgs());
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var conditionsWindow = new ConditionsWindow();
            conditionsWindow.Owner = Window.GetWindow(this);
            conditionsWindow.ShowDialog();
        }
    }
}
