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

            if (IsAgree.IsChecked.Value)
            {
                var login = LoginTxt.Text;
                var password = PasswordTxt.Password;
                var passwordRepeat = PasswordRepeatTxt.Password;
                var email = EmailTxt.Text;
                var phone = PhoneTxt.Text;

                if (password.Equals(passwordRepeat))
                {
                    if (DbClientWorker.CheckClient(login))
                    {
                        var client = new Client
                        {
                            Guid = Guid.NewGuid(),
                            Login = login,
                            Password = password,
                            Email = email,
                            Phone = phone
                        };

                        DbClientWorker.AddClient(client);

                        if (RegisterEnded != null)
                        {
                            RegisterEnded(this, new EventArgs());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("Warning");
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
