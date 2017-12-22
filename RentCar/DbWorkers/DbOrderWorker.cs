using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DbWorkers
{
    public static class DbOrderWorker
    {
        public static List<Order> GetOrders(Guid clientGuid, DateTime? fromDate, DateTime? toDate)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbOrderGuids = context.ClientOrders.Where(x => x.ClientGuid == clientGuid).Select(x => x.OrderGuid).ToList();
                if (dbOrderGuids.Count == 0)
                {
                    return new List<Order>();
                }

                var dbOrders = context.Order.Where(x => dbOrderGuids.Contains(x.Guid)).AsQueryable();
                if (fromDate.HasValue)
                {
                    dbOrders = dbOrders.Where(x => x.OrderDate >= fromDate);
                }
                if (toDate.HasValue)
                {
                    dbOrders = dbOrders.Where(x => x.OrderDate <= toDate);
                }
                var orders = new List<Order>();
                foreach (var dbOrder in dbOrders)
                {
                    orders.Add(new Order
                    {
                        Guid = dbOrder.Guid,
                        Address = dbOrder.Address,
                        OrderDate = dbOrder.OrderDate.Value,
                        DeliveryDate = dbOrder.DeliveryDate.Value,
                        ExpirationDate = dbOrder.ExpirationDate.Value,
                        Status = (OrderStatus)dbOrder.Status,
                        Car = new Car
                        {
                            Guid = dbOrder.Car.Guid,
                            Model = dbOrder.Car.Model,
                            YearProduction = dbOrder.Car.YearProduction.Value,
                            Photo = dbOrder.Car.Photo,
                            Mileage = dbOrder.Car.Mileage.Value,
                            Price = dbOrder.Car.Price.Value,
                            Status = (CarStatus)dbOrder.Car.Status.Value
                        }
                    });
                }

                return orders;
            }
        }

        public static Order GetOrder(Guid orderGuid)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbOrder = context.Order.SingleOrDefault(x => x.Guid == orderGuid);
                if (dbOrder == null)
                {
                    return null;
                }

                return new Order
                {
                    Guid = dbOrder.Guid,
                    Address = dbOrder.Address,
                    OrderDate = dbOrder.OrderDate.Value,
                    DeliveryDate = dbOrder.DeliveryDate.Value,
                    ExpirationDate = dbOrder.ExpirationDate.Value,
                    Status = (OrderStatus)dbOrder.Status,
                    Car = new Car
                    {
                        Guid = dbOrder.Car.Guid,
                        Model = dbOrder.Car.Model,
                        YearProduction = dbOrder.Car.YearProduction.Value,
                        Photo = dbOrder.Car.Photo,
                        Mileage = dbOrder.Car.Mileage.Value,
                        Price = dbOrder.Car.Price.Value,
                        Status = (CarStatus)dbOrder.Car.Status.Value
                    }
                };
            }
        }

        public static void AddOrder(Order order)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbOrder = new Db.Order
                {
                    Guid = order.Guid,
                    Address = order.Address,
                    CarGuid = order.Car.Guid,
                    DeliveryDate = order.DeliveryDate,
                    ExpirationDate = order.ExpirationDate,
                    OrderDate = order.OrderDate,
                    Status = (int)order.Status
                };

                context.Order.Add(dbOrder);
                context.SaveChanges();
            }
        }

        public static void DeleteOrder(Guid orderGuid)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbOrder = context.Order.SingleOrDefault(x => x.Guid == orderGuid);
                if (dbOrder == null)
                {
                    return;
                }

                context.Order.Remove(dbOrder);
                context.SaveChanges();
            }
        }

        public static void UpdateOrder(Order order)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbOrder = context.Order.SingleOrDefault(x => x.Guid == order.Guid);
                if (dbOrder == null)
                {
                    return;
                }

                dbOrder.Address = order.Address;
                dbOrder.CarGuid = order.Car.Guid;
                dbOrder.DeliveryDate = order.DeliveryDate;
                dbOrder.ExpirationDate = order.ExpirationDate;
                dbOrder.OrderDate = order.OrderDate;
                dbOrder.Status = (int)order.Status;

                context.SaveChanges();
            }
        }
    }
}
