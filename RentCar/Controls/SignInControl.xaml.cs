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
using RentEventArgs;
using Common;
using DbWorkers;

namespace RentCar.Controls
{
    /// <summary>
    /// Логика взаимодействия для SignInControl.xaml
    /// </summary>
    public partial class SignInControl : UserControl
    {
        public event EventHandler RegisterStarted;
        public event EventHandler<AuthorizedEventArgs> AutorizationCompleted;

        public SignInControl()
        {
            InitializeComponent();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Логика проверки Клиента

            var login = LoginTxt.Text;
            var password = PasswordTxt.Password;

            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Error");
            }

            if((UserData.User.UserGuid = DbClientWorker.SignIn(login, password)) != null)
            {
                if (AutorizationCompleted != null)
                {
                    AutorizationCompleted(this, new AuthorizedEventArgs(true));
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if(RegisterStarted != null)
            {
                RegisterStarted(this, new EventArgs());
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GuestBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (AutorizationCompleted != null)
            {
                AutorizationCompleted(this, new AuthorizedEventArgs(false));
            }
        }
    }
}
