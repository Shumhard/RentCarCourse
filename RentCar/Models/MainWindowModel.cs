using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Models
{
    public class MainWindowModel : NotifyModel
    {
        private ObservableCollection<CarModel> _cars;
        private string _selectedCity;
        private string _selectedModel;
        private string _selectedMark;
        private string _selectedType;
        private string _dateFrom;
        private string _dateTo;
        private string _priceFrom;
        private string _priceTo;

        public bool IsAuthorized { get; set; }

        public ObservableCollection<CarModel> Cars
        {
            get
            {
                return _cars;
            }
            set
            {
                _cars = value;
                OnPropertyChanged("Cars");
            }
        } 

        public string SelectedCity
        {
            get
            {
                return _selectedCity;
            }
            set
            {
                _selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        public string SelectedModel
        {
            get
            {
                return _selectedModel;
            }
            set
            {
                _selectedModel = value;
                OnPropertyChanged("SelectedModel");
            }
        }

        public string SelectedMark
        {
            get
            {
                return _selectedMark;
            }
            set
            {
                _selectedMark = value;
                OnPropertyChanged("SelectedMark");
            }
        }

        public string SelectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                _selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }

        public string DateFrom
        {
            get
            {
                return _dateFrom;
            }
            set
            {
                _dateFrom = value;
                OnPropertyChanged("DateFrom");
            }
        }

        public string DateTo
        {
            get
            {
                return _dateTo;
            }
            set
            {
                _dateTo = value;
                OnPropertyChanged("DateTo");
            }
        }

        public string PriceFrom
        {
            get
            {
                return _priceFrom;
            }
            set
            {
                _priceFrom = value;
                OnPropertyChanged("PriceFrom");
            }
        }

        public string PriceTo
        {
            get
            {
                return _priceTo;
            }
            set
            {
                _priceTo = value;
                OnPropertyChanged("PriceTo");
            }
        }

        public List<ReferenceValue> CityList { get; set; }
        
        public List<ReferenceValue> MarkList { get; set; }

        public List<ReferenceValue> ModelList { get; set; }

        public List<ReferenceValue> TypeList { get; set; }
    }
}
