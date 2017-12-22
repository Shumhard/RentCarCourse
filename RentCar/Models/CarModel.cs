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
        private Car _car;

        public Car Car 
        {
            get { return _car; }
        }
        public string ImagePath { get; set; }
        public string Model { get; set; }
        public string Mark { get; set; }
        public string City { get; set; }
        public double Price
        {
            get { return _price ?? 0; }
            set { _price = value; }
        }        
        public string PriceFull
        {
            get { return string.Format("{0} руб./сут.", _price.HasValue ? _price.Value.ToString(CultureInfo.CurrentCulture) : "0"); }
        }
        public string NameFull
        {
            get { return string.Format("{0} {1} / {2}", this.Mark, this.Model, this.City); }
        }

        public bool Visible { get; set; }
        public bool Enable { get; set; }

        public CarModel() { ; }
        public CarModel(Car car)
        {
            this._car = car;
            this.ImagePath = car.Photo;
            this.Model = car.Model;
            this.Mark = car.Mark;
            this.City = car.City;
            this.Price = car.Price;
            this.Enable = true;
            this.Visible = true;
        }
    }
}
