using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Order
    {
        public static readonly string ArgumentNullExceptionMessage = "ExpirationDate is null";
        public static readonly string InvalidOperationExceptionMessage = "DeliveryDate more then ExpirationDate";
        public Guid Guid { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Area { get; set; }
        public OrderStatus Status { get; set; }
        public double TotalCost { get; set; }
        public Car Car { get; set; }
        public List<string> ServicesList { get; set; }
        public TimeSpan GetRentRange()  //  in d:h:m:s
        {
            if (ExpirationDate == null)
            {
                throw new ArgumentNullException(ArgumentNullExceptionMessage);
            }
            else if (ExpirationDate <= DeliveryDate)
            {
                throw new InvalidOperationException(InvalidOperationExceptionMessage);
            }
            else
            {
                return ExpirationDate.Value.Subtract(DeliveryDate);
            }
        }
    }
}
