using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MainWindowModel
    {
        public bool IsAuthorized { get; set; }

        public List<CarModel> Cars { get; set; } 
        
        public List<string> CityList { get; set; }
        
        public List<string> MarkList { get; set; }

        public List<string> ModelList { get; set; }

        public List<string> TypeList { get; set; } 
        
         
    }

    public class CarModel
    {
        private double? _price;

        public string ImagePath { get; set; }

        public string Model { get; set; }

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
    }
}
