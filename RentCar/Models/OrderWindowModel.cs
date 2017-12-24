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
    public class OrderWindowModel : NotifyModel
    {
        private DateTime? _beginRentDate;
        private DateTime? _endRentDate;
        private Area _area;
        private string _name;
        private List<AdditionalService> _additionalServices;
        private double _totalCost;

        public Guid OrderGuid { get; set; }
        public Car Car { get; set; }
        public bool IsEdit { get; set; }
        public bool IsSuccess { get; set; }

        public DateTime? BeginRentDate
        {
            get { return _beginRentDate; }
            set
            {
                _beginRentDate = value;
                OnPropertyChanged("BeginRentDate");
            }
        }

        public DateTime? EndRentDate
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
            get { return Car.City; }
        }

        public Area Area
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
            get { return _totalCost.ToString() + " рублей"; }
        }       
    }

    public class AdditionalService : NotifyModel
    {
        private bool _checked;

        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                OnPropertyChanged("Checked");
            }
        }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
