using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderModel
    {
        public string ImgPath { get; set; }

        public string OrderDate { get; set; }

        public string RentRange { get; set; }

        public string Area { get; set; }

        public string StatusString { get; set; }

        public string PriceString { get; set; }

        public List<string> ServicesList { get; set; }
    }
}
