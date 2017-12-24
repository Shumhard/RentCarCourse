using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using RentCar;

namespace DbWorkers
{
    public static class DbClientWorker
    {
        public static Guid? SignIn(string login, string password)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbClient = context.Client.SingleOrDefault(x => x.Login == login && x.Password == password);
                if(dbClient == null)
                {
                    return null;
                }
                return dbClient.Guid;
            }
        }

        public static bool CheckClient(string login)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbClient = context.Client.SingleOrDefault(x => x.Login == login);
                return dbClient != null;
            }
        }

        public static Client GetClient(Guid clientGuid)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbClient = context.Client.SingleOrDefault(x => x.Guid == clientGuid);
                if(dbClient == null)
                {
                    return null;
                }

                var client = ConstructClient(dbClient);
                return client;
            }
        }

        public static Client GetClient(string email, string password)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbClient = context.Client.SingleOrDefault(x => x.Email == email && x.Password == password);
                if (dbClient == null)
                {
                    return null;
                }

                var client = ConstructClient(dbClient);
                return client;
            }
        }

        private static Client ConstructClient(Db.Client dbClient)
        {
            return new Client
            {
                Guid = dbClient.Guid,
                FirstName = dbClient.FirstName,
                LastName = dbClient.LastName,
                Patronymic = dbClient.Patronymic,
                Birthday = dbClient.Birthday,
                Phone = dbClient.Phone,
                Email = dbClient.Email,
                Password = dbClient.Password,
                Sex = dbClient.Sex,
                PassportNumber = dbClient.PassportNumber,
                PassportSeries = dbClient.PassportSeries,
                BankCard = dbClient.BankCard,
                Login = dbClient.Login,
                ImagePath = System.IO.Path.Combine(Settings.AttachedFiles, dbClient.ImagePath)
            };
        }

        public static void AddClient(Client client)
        {
            using(var context = new Db.OpenRentEntities())
            {
                context.Client.Add(new Db.Client
                {
                    Guid = client.Guid,
                    Email = client.Email,
                    Phone =  client.Phone,
                    Login = client.Login,
                    Password = client.Password,
                    ImagePath = @"Users\default.png"
                });
                context.SaveChanges();
            }
        }

        public static void DeleteClient(Guid clientGuid)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbClient = context.Client.SingleOrDefault(x => x.Guid == clientGuid);
                if(dbClient == null)
                {
                    return;
                }

                context.Client.Remove(dbClient);
                context.SaveChanges();
            }
        }

        public static bool UpdateClient(Client client)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbClient = context.Client.SingleOrDefault(x => x.Guid == client.Guid);
                if(dbClient == null)
                {
                    return false;
                }

                dbClient.FirstName = client.FirstName;
                dbClient.LastName = client.LastName;
                dbClient.Patronymic = client.Patronymic;
                dbClient.Birthday = client.Birthday;
                dbClient.Phone = client.Phone;
                dbClient.Email = client.Email;
                dbClient.Password = client.Password;
                dbClient.Sex = client.Sex;
                dbClient.PassportNumber = client.PassportNumber;
                dbClient.PassportSeries = client.PassportSeries;
                dbClient.BankCard = client.BankCard;
                dbClient.Login = client.Login;
                dbClient.ImagePath = client.ImagePath;

                context.SaveChanges();

                return true;
            }
        }
    }
}
