using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace RentCar.Models
{
    public class OrderWindowModel : INotifyPropertyChanged
    {
        private string _beginRentDate;
        private string _endRentDate;
        private string _city;
        private string _area;
        private string _name;
        private string _carName;
        private List<AdditionalService> _additionalServices;
        private double _totalCost;

        public Guid OrderGuid { get; set; }

        public string BeginRentDate
        {
            get { return _beginRentDate; }
            set
            {
                _beginRentDate = value;
                OnPropertyChanged("BeginRentDate");
            }
        }

        public string EndRentDate
        {
            get { return _endRentDate; }
            set
            {
                _endRentDate = value;
                OnPropertyChanged("EndRentDate");
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        public string Area
        {
            get { return _area; }
            set
            {
                _area = value;
                OnPropertyChanged("Area");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string CarName
        {
            get 
            {
                return string.Format("{0} {1} / {2}", this.Car.Mark, this.Car.Model, this.Car.City);
            }
            set
            {
                _name = value;
                OnPropertyChanged("CarName");
            }
        }

        public List<AdditionalService> AdditionalServices
        {
            get { return _additionalServices; }
            set
            {
                _additionalServices = value;
                OnPropertyChanged("AdditionalServices");
            }
        }

        public double TotalCost
        {
            get { return _totalCost; }
            set
            {
                _totalCost = value;
                OnPropertyChanged("TotalCost");
                OnPropertyChanged("TotalCostString");
            }
        }
        
        public string TotalCostString
        {
            get { return _totalCost.ToString() + " руб."; }
        }

        public Car Car { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }        
    }

    public class AdditionalService : INotifyPropertyChanged
    {
        private bool _checked;
        private string _name;

        public double Price { get; set; }

        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                OnPropertyChanged("Checked");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
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
