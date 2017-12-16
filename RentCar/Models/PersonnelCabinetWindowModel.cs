using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Models
{
    public class PersonnelCabinetWindowModel : INotifyPropertyChanged
    {
        private string _login;
        private string _password;
        private string _firstName = "";
        private string _secondName = "";
        private string _patronymic = "";
        private string _phone;
        private string _email;
        private DateTime? _burthday;
        private string _sex;
        private string _passportSeria;
        private string _passportNumber;
        private string _bankCard;
        private string _imagePath;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
                OnPropertyChanged("PasswordString");
            }
        }

        public string PasswordString
        {
            get
            {
                if (string.IsNullOrEmpty(_password))
                {
                    return "******";
                }

                if(_password.Length > 1)
                {
                    return string.Format("{0}******{1}", _password[0], _password.Last());
                }

                return string.Format("{0}******", _password[0]);
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
                OnPropertyChanged("FullName");
            }
        }

        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                OnPropertyChanged("SecondName");
                OnPropertyChanged("FullName");
            }
        }

        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                _patronymic = value;
                OnPropertyChanged("Patronymic");
                OnPropertyChanged("FullName");
            }
        }

        public string FullName
        {
            get
            {
                return string.Join(" ", new string[] { _secondName, _firstName, _patronymic });
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
                OnPropertyChanged("Sex");
            }
        }

        public string Burthday
        {
            get { return _burthday.HasValue ? _burthday.Value.ToShortDateString() : ""; }
            set
            {
                DateTime burthday;
                if (DateTime.TryParse(value, out burthday))
                {
                    _burthday = burthday;
                }
                else
                {
                    _burthday = null;
                }
                OnPropertyChanged("Burthday");
            }
        }

        public string PassportSeria
        {
            get { return _passportSeria; }
            set
            {
                _passportSeria = value;
                OnPropertyChanged("PassportSeria");
            }
        }

        public string PassportNumber
        {
            get { return _passportNumber; }
            set
            {
                _passportNumber = value;
                OnPropertyChanged("PassportNumber");
            }
        }

        public string BankCard
        {
            get { return _bankCard; }
            set
            {
                _bankCard = value;
                OnPropertyChanged("BankCard");
            }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
