using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Models
{
    public class CarModel
    {
        private double? _price;

        public string ImagePath { get; set; }
        public string Model { get; set; }
        public string Mark { get; set; }
        public string Type { get; set; }
        public DateInterval RentalDate { get; set; }
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
        public string City { get; set; }
        public bool Visible { get; set; }

        public CarModel setDebugCarModel(
            double user_price = 1005, 
            string user_hdate = "10/12/15",
            string user_ldate = "10/12/17")
        {
            ImagePath = @"C:\Users\shuhard93\Desktop\audi.jpg";
            Model = "cx-5";
            Mark = "MAZDA";
            Type = "Crossover";
            RentalDate = new DateInterval();
            RentalDate.HighDate = Convert.ToDateTime(user_hdate);
            RentalDate.LowDate = Convert.ToDateTime(user_ldate);
            Price = user_price;
            YearProduction = 2015;
            City = "Город";
            Visible = true;
            return this;
        }
    }
}
