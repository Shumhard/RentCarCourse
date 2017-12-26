using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Models;
using RentCar;
using System.Collections.ObjectModel;

namespace DbWorkers
{
    public static class DbCarWorker
    {
        public static ObservableCollection<CarModel> GetCarsByFilter(Filter filter)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var carModels = new ObservableCollection<CarModel>();

                var dbCars = context.Car.AsQueryable();
                if (!string.IsNullOrEmpty(filter.City))
                {
                    dbCars = dbCars.Where(x => x.City == filter.City);
                }
                if (!string.IsNullOrEmpty(filter.Model))
                {
                    dbCars = dbCars.Where(x => x.Model == filter.Model);
                }
                if (!string.IsNullOrEmpty(filter.Mark))
                {
                    dbCars = dbCars.Where(x => x.Mark == filter.Mark);
                }
                if (!string.IsNullOrEmpty(filter.Type))
                {
                    dbCars = dbCars.Where(x => x.Type == filter.Type);
                }
                if (filter.PriceFrom.HasValue)
                {
                    dbCars = dbCars.Where(x => x.Price >= filter.PriceFrom);
                }
                if (filter.PriceTo.HasValue)
                {
                    dbCars = dbCars.Where(x => x.Price <= filter.PriceTo);
                }

                if(filter.DateFrom.HasValue || filter.DateTo.HasValue)
                {
                    var dbActiveOrders = context.Order.Where(x => (x.StatusId.Value != (int)OrderStatus.Canceled) && (x.StatusId.Value != (int)OrderStatus.Complete));
                    if (filter.DateFrom.HasValue)
                    {
                        dbActiveOrders = dbActiveOrders.Where(x => filter.DateFrom.Value >= x.RentBeginDate || filter.DateFrom.Value <= x.RentEndDate);
                    }
                    if (filter.DateTo.HasValue)
                    {
                        dbActiveOrders = dbActiveOrders.Where(x => filter.DateTo.Value <= x.RentBeginDate || filter.DateTo.Value >= x.RentEndDate);
                    }
                    var dbOrderCarGuids = dbActiveOrders.Select(x => x.CarGuid).ToList();
                    dbCars = dbCars.Where(x => !dbOrderCarGuids.Contains(x.Guid));
                }
                
                foreach(var dbCar in dbCars)
                {
                    var carModel = new CarModel()
                    {
                        Guid = dbCar.Guid,
                        IsEnabled = (CarStatus)dbCar.Status.Value == CarStatus.Free,
                        ImagePath = System.IO.Path.Combine(Settings.AttachedFiles ?? "", dbCar.Photo),
                        Model = dbCar.Model,
                        Name = string.Format("{0} {1} {2}", dbCar.Mark, dbCar.Model, dbCar.Type),
                        Price = dbCar.Price.HasValue ? dbCar.Price.Value : 0,
                        YearProduction = dbCar.YearProduction.HasValue ? dbCar.YearProduction.Value : 0
                    };
                    carModels.Add(carModel);
                }

                return carModels;
            }
        }

        public static Car GetCar(Guid carGuid)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbCar = context.Car.SingleOrDefault(x => x.Guid == carGuid);
                if(dbCar == null)
                {
                    return null;
                }

                var car = ConstructCar(dbCar);
                return car;
            }
        }

        public static Car ConstructCar(Db.Car dbCar)
        {
            return new Common.Car
            {
                Guid = dbCar.Guid,
                Color = dbCar.Color,
                Model = dbCar.Model,
                Mileage = dbCar.Mileage.Value,
                Photo = dbCar.Photo,
                Price = dbCar.Price.Value,
                Status = (CarStatus)dbCar.Status,
                YearProduction = dbCar.YearProduction.Value,
                City = dbCar.City,
                Mark = dbCar.Mark,
                Type = dbCar.Type
            };
        }

        public static void AddCar(Car car)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbCar = new Db.Car
                {
                    Guid = car.Guid,
                    City = car.City,
                    Color = car.Color,
                    Mark = car.Mark,
                    Mileage = car.Mileage,
                    Model = car.Model,
                    Photo = car.Photo,
                    Price = car.Price,
                    Status = (int)CarStatus.Free,
                    Type = car.Type,
                    YearProduction = car.YearProduction
                };

                context.Car.Add(dbCar);
                context.SaveChanges();
            }
        }

        public static void DeleteCar(Guid carGuid)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbCar = context.Car.SingleOrDefault(x => x.Guid == carGuid);
                if(dbCar == null)
                {
                    return;
                }

                context.Car.Remove(dbCar);
                context.SaveChanges();
            }
        }

        public static void UpdateCar(Car car)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbCar = context.Car.SingleOrDefault(x => x.Guid == car.Guid);
                if (dbCar == null)
                {
                    return;
                }
                
                dbCar.Guid = car.Guid;
                dbCar.City = car.City;
                dbCar.Color = car.Color;
                dbCar.Mark = car.Mark;
                dbCar.Mileage = car.Mileage;
                dbCar.Model = car.Model;
                dbCar.Photo = car.Photo;
                dbCar.Price = car.Price;
                dbCar.Status = (int)car.Status;
                dbCar.Type = car.Type;
                dbCar.YearProduction = car.YearProduction;

                context.SaveChanges();
            }
        }
    }
}
