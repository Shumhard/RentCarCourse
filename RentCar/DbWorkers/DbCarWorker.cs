using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DbWorkers
{
    public static class DbCarWorker
    {
        public static List<Car> GetCars()
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbCars = context.Car.AsQueryable();
                var cars = new List<Car>();
                foreach(var dbCar in dbCars)
                {
                    var car = ConstructCar(dbCar);
                    cars.Add(car);
                }

                return cars;
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
                Model = dbCar.Model,
                Mileage = dbCar.Mileage.Value,
                Photo = dbCar.Photo,
                Price = dbCar.Price.Value,
                Status = (CarStatus)dbCar.Status,
                YearProduction = dbCar.YearProduction.Value
            };
        }

        public static void AddCar(Car car)
        {
            using (var context = new Db.OpenRentEntities())
            {
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

                dbCar.Model = car.Model;
                dbCar.YearProduction = car.YearProduction;
                dbCar.Photo = car.Photo;
                dbCar.Price = car.Price;
                dbCar.Mileage = car.Mileage;
                dbCar.Status = (int)car.Status;

                context.SaveChanges();
            }
        }
    }
}
