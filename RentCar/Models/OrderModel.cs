using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Models
{
    public class OrderModel
    {
        private readonly Guid _guid;

        public Guid Guid()
        {
            return _guid;
        }
        public string ImgPath { get; set; }
        public string OrderDate { get; set; }
        public string RentRange { get; set; }
        public string Area { get; set; }
        public string StatusString { get; set; }
        public string TotalCost { get; set; }
        public List<string> ServicesList { get; set; }

        public OrderModel() { }
        public OrderModel(Guid guid)
        {
            _guid = guid;
        }

        public OrderModel FillOrderModel(Order order)
        {
            ImgPath = order.Car.Photo;
            OrderDate = order.OrderDate.ToString();
            RentRange = order.GetRentRange().ToString();
            Area = order.Area;
            StatusString = order.Status.ToString();
            TotalCost = order.TotalCost.ToString();
            ServicesList = order.ServicesList;
            return this;
        }
    }
}
