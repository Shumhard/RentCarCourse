using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Order
    {
        public Guid Guid { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public OrderStatus Status { get; set; }
        public Car Car { get; set; }
    }
}
