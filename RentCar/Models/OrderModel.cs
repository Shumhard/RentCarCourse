using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderModel : NotifyModel
    {
        private string _rentRange;
        private string _area;
        private string _statusString;
        private string _priceString;
        private List<string> _servicesList;

        public Guid Guid { get; set; }

        public string ImagePath { get; set; }

        public string OrderDate { get; set; }

        public string RentRange
        {
            get { return _rentRange; }
            set
            {
                _rentRange = value;
                OnPropertyChanged("RentRange");
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

        public string StatusString
        {
            get { return _statusString; }
            set
            {
                _statusString = value;
                OnPropertyChanged("StatusString");
            }
        }

        public string PriceString
        {
            get { return _priceString; }
            set
            {
                _priceString = value;
                OnPropertyChanged("PriceString");
            }
        }

        public List<string> ServicesList
        {
            get { return _servicesList; }
            set
            {
                _servicesList = value;
                OnPropertyChanged("ServicesList");
            }
        }
    }
}
