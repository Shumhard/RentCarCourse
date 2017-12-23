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
        public string Photo { get; set; }
        public string Mark { get; set; }
        public string Type { get; set; }
        public DateTime HighRentalDate { get; set; }
        public DateTime LowRentalDate { get; set; }
        public int YearProduction { get; set; }
        public double Price { get; set; }
        public double Mileage { get; set; }
        public CarStatus Status { get; set; }
        public string City { get; set; }

        public bool CheckBusyness(DateTime lowDate, DateTime highDate)
        {            
            return (
                    highDate.Year != 1 && lowDate.Year == 1 &&
                    !(highDate.CompareTo(this.LowRentalDate) < 0)
                    ) ||
                    (
                    lowDate.Year != 1 && highDate.Year == 1 &&
                    !(lowDate.CompareTo(this.HighRentalDate) > 0)
                    ) ||
                    (
                    highDate.Year != 1 && lowDate.Year != 1 &&
                    !((lowDate.CompareTo(this.LowRentalDate) < 0 && highDate.CompareTo(this.LowRentalDate) < 0) ||
                    (lowDate.CompareTo(this.HighRentalDate) > 0 && highDate.CompareTo(this.HighRentalDate) > 0))
                    );
        }
    }
}
