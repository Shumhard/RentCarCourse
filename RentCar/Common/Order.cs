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
        public Guid ClientGuid { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RentBeginDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentType PaymentType { get; set; }
        public double? TotalCost { get; set; }
        public Area Area { get; set; }
        public Car Car { get; set; }
        public List<Guid> AdditonalServiceGuids { get; set; }
    }
}
