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
using RentCar.Controls;
using RentEventArgs;

namespace RentCar
{
    public partial class AuthWindow : Window
    {     
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetSignInControl();
        }

        private void SetSignInControl()
        {
            this.Title = "Авторизация";
            var control = new SignInControl();
            control.AutorizationCompleted += OnAutorizationCompleted;
            control.RegisterStarted += OnRegisterStarted;
            MainControl.Content = control;
        }

        private void SetSignUpControl()
        {
            this.Title = "Регистрация";
            var control = new SignUpControl();
            control.RegisterEnded += OnRegisterEnded;
            MainControl.Content = control;
        }

        private void OnRegisterStarted(object sender, EventArgs e)
        {
            SetSignUpControl();
        }

        private void OnRegisterEnded(object sender, EventArgs e)
        {
            SetSignInControl();
        }

        private void OnAutorizationCompleted(object sender, AuthorizedEventArgs e)
        {
            this.Hide();
            var mainWindow = new MainWindow(e.IsAuthorized);
            mainWindow.Show();
            this.Close();
        }
    }
}
