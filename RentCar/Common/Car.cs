using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Car
    {
        public Guid Guid { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Photo { get; set; }
        public int YearProduction { get; set; }
        public double Price { get; set; }
        public double Mileage { get; set; }
        public CarStatus Status { get; set; }
    }
}
