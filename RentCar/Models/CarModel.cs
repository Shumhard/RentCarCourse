using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarModel : NotifyModel
    {
        private bool _isEnabled;
        private double? _price;

        public string ImagePath { get; set; }

        public string Model { get; set; }

        public string Name { get; set; }

        public double Price
        {
            get { return _price ?? 0; }

            set { _price = value; }
        }

        public string PriceFull
        {
            get { return string.Format("{0} руб.", _price.HasValue ? _price.Value.ToString(CultureInfo.CurrentCulture) : "0"); }
        }

        public int YearProduction { get; set; }

        public Guid Guid { get; set; }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }
    }
}
