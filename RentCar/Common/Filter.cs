using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Filter
    {
        public string City { get; set; }

        public string Model { get; set; }

        public string Mark { get; set; }

        public string Type { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public double? PriceFrom { get; set; }

        public double? PriceTo { get; set; }
    }
}
