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
        private readonly Guid _guid;

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

        public PersonnelCabinetWindowModel() { }

        public PersonnelCabinetWindowModel(Guid guid)
        {
            this._guid = guid;
        }

        public Guid Guid
        {
            get { return _guid; }
        }

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

        public void setClientInfo(Common.Client client)
        {
            this._login = client.Login;
            this._password = client.Password;
            this._firstName = client.FirstName;
            this._secondName = client.LastName;
            this._patronymic = client.Patronymic;
            this._phone = client.Phone;
            this._email = client.Email;
            this._burthday = client.Birthday;
            this._sex = client.Sex;
            this._passportSeria = client.PassportSeries;
            this._passportNumber = client.PassportNumber;
            this._bankCard = client.BankCard;
            this._imagePath = client.ImagePath;
        }

        public Common.Client getClient()
        {
            return new Common.Client
            {
                Guid = this._guid,
                FirstName = this._firstName,
                LastName = this._secondName,
                Patronymic = this._patronymic,
                Birthday = this._burthday,
                Sex = this._sex,
                PassportSeries = this._passportSeria,
                PassportNumber = this._passportNumber,
                Login = this._login,
                Password = this._password,
                Phone = this._phone,
                Email = this._email,
                BankCard = this._bankCard,
                ImagePath = this._imagePath
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
