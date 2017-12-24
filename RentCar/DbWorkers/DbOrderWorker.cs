using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Extentions;
using Models;
using RentCar;

namespace DbWorkers
{
    public static class DbOrderWorker
    {
        public static List<OrderModel> GetClientOrders(Guid clientGuid)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbOrderGuids = context.ClientOrders.Where(x => x.ClientGuid == clientGuid).Select(x => x.OrderGuid).ToList();
                if (dbOrderGuids.Count == 0)
                {
                    return new List<OrderModel>();
                }

                var dbOrders = context.Order.Where(x => dbOrderGuids.Contains(x.Guid)).OrderByDescending(x => x.OrderDate);
                var orders = new List<OrderModel>();
                foreach (var dbOrder in dbOrders)
                {
                    orders.Add(new OrderModel
                    {
                        Guid = dbOrder.Guid,
                        OrderDate = dbOrder.OrderDate.Value.ToShortDateString(),
                        RentRange = string.Format("{0} - {1}", dbOrder.RentBeginDate.Value.ToShortDateString(), dbOrder.RentEndDate.Value.ToShortDateString()),
                        Area = dbOrder.Area.Area1,
                        PriceString = dbOrder.TotalCost.ToString() + " рублей",
                        StatusString = ((OrderStatus)dbOrder.StatusId.Value).DescriptionAttr(),
                        ImagePath = System.IO.Path.Combine(Settings.AttachedFiles, dbOrder.Car.Photo),
                        ServicesList = dbOrder.OrderAdditionalServices.Select(x => x.AdditionalServices.Name).OrderBy(x => x).ToList()

                        //Guid = dbOrder.Guid,
                        //Address = dbOrder.Address,
                        //OrderDate = dbOrder.OrderDate.Value,
                        //DeliveryDate = dbOrder.DeliveryDate.Value,
                        //ExpirationDate = dbOrder.ExpirationDate.Value,
                        //Status = (OrderStatus)dbOrder.Status,
                        //Car = new Car
                        //{
                        //    Guid = dbOrder.Car.Guid,
                        //    Model = dbOrder.Car.Model,
                        //    Color = dbOrder.Car.Color,
                        //    YearProduction = dbOrder.Car.YearProduction.Value,
                        //    Photo = dbOrder.Car.Photo,
                        //    Mileage = dbOrder.Car.Mileage.Value,
                        //    Price = dbOrder.Car.Price.Value,
                        //    Status = (CarStatus)dbOrder.Car.Status.Value
                        //}
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
                    ClientGuid = dbOrder.ClientOrders.First().ClientGuid,
                    Name = dbOrder.Name,
                    OrderDate = dbOrder.OrderDate.Value,
                    RentBeginDate = dbOrder.RentBeginDate.Value,
                    RentEndDate = dbOrder.RentEndDate.Value,
                    Status = (OrderStatus)dbOrder.StatusId,
                    PaymentType = (PaymentType)dbOrder.PaymentTypeId,
                    TotalCost = dbOrder.TotalCost.Value,
                    Area = new Area
                    {
                        Guid = dbOrder.Area.Guid,
                        Name = dbOrder.Area.Area1,
                        PriceMultiplier = dbOrder.Area.PriceMultiplier.Value
                    },
                    Car = DbCarWorker.ConstructCar(dbOrder.Car),
                    AdditonalServiceGuids = dbOrder.OrderAdditionalServices.Select(x => x.ServiceGuid).ToList()
                };
            }
        }

        public static bool AddOrder(Order order)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbOrder = new Db.Order
                {
                    Guid = order.Guid,
                    Name = order.Name,
                    OrderDate = order.OrderDate,
                    RentBeginDate = order.RentBeginDate,
                    RentEndDate = order.RentEndDate,
                    StatusId = (int)OrderStatus.InProgressNotPaid,
                    PaymentTypeId = (int)order.PaymentType,
                    TotalCost = order.TotalCost,
                    AreaGuid = order.Area.Guid,
                    CarGuid = order.Car.Guid,
                };
                dbOrder.ClientOrders.Add(new Db.ClientOrders {
                    Guid = Guid.NewGuid(),
                    OrderGuid = order.Guid,
                    ClientGuid = order.ClientGuid
                });
                foreach(var addServiceGuid in order.AdditonalServiceGuids)
                {
                    dbOrder.OrderAdditionalServices.Add(new Db.OrderAdditionalServices {
                        Guid = Guid.NewGuid(),
                        OrderGuid = order.Guid,
                        ServiceGuid = addServiceGuid
                    });
                }

                context.Order.Add(dbOrder);
                context.SaveChanges();

                return true;
            }
        }

        public static bool DeleteOrder(Guid orderGuid)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbOrder = context.Order.SingleOrDefault(x => x.Guid == orderGuid);
                if (dbOrder == null)
                {
                    return false;
                }

                context.Order.Remove(dbOrder);
                context.SaveChanges();

                return true;
            }
        }

        public static bool CancelOrder(Guid orderGuid)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbOrder = context.Order.SingleOrDefault(x => x.Guid == orderGuid);
                if (dbOrder == null)
                {
                    return false;
                }

                dbOrder.StatusId = (int)OrderStatus.Canceled;
                context.SaveChanges();

                return true;
            }
        }

        public static bool UpdateOrder(Order order)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbOrder = context.Order.SingleOrDefault(x => x.Guid == order.Guid);
                if (dbOrder == null)
                {
                    return false;
                }

                dbOrder.Name = order.Name;
                dbOrder.RentBeginDate = order.RentBeginDate;
                dbOrder.RentEndDate = order.RentEndDate;
                dbOrder.TotalCost = order.TotalCost;
                dbOrder.AreaGuid = order.Area.Guid;
                dbOrder.PaymentTypeId = (int)order.PaymentType;

                var dbAddServices = new List<Db.OrderAdditionalServices>();
                var dbRemoveServices = new List<Db.OrderAdditionalServices>();
                foreach(var dbService in dbOrder.OrderAdditionalServices)
                {
                    if (!order.AdditonalServiceGuids.Contains(dbService.ServiceGuid))
                    {
                        dbRemoveServices.Add(dbService);
                    }
                }
                foreach (var serviceGuid in order.AdditonalServiceGuids)
                {
                    if (dbOrder.OrderAdditionalServices.Count(x => x.ServiceGuid == serviceGuid) == 0)
                    {
                        dbAddServices.Add(new Db.OrderAdditionalServices {
                            Guid = Guid.NewGuid(),
                            OrderGuid = order.Guid,
                            ServiceGuid = serviceGuid
                        });
                    }
                }
                foreach (var dbRemoveService in dbRemoveServices)
                {
                    dbOrder.OrderAdditionalServices.Remove(dbRemoveService);
                }
                foreach (var dbAddService in dbAddServices)
                {
                    dbOrder.OrderAdditionalServices.Add(dbAddService);
                }

                context.SaveChanges();

                return true;
            }
        }
    }
}
