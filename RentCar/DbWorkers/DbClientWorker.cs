using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DbWorkers
{
    public static class DbClientWorker
    {
        public static bool CheckClient(string email)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbClient = context.Client.SingleOrDefault(x => x.Email == email);
                return dbClient == null;
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
                Sex = dbClient.Sex,
                Email = dbClient.Email,
                //Login = dbClient.Login,
                Password = dbClient.Password,
                PassportNumber = dbClient.PassportNumber,
                PassportSeries = dbClient.PassportSeries
                //BankCard = dbClient.BankCard,
                //ImagePath = dbClient.ImagePath
            };
        }

        public static void AddClient(Client client)
        {
            using(var context = new Db.OpenRentEntities())
            {
                context.Client.Add(new Db.Client
                {
                    Guid = client.Guid,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Patronymic = client.Patronymic,
                    Birthday = client.Birthday,
                    Phone = client.Phone,
                    Sex = client.Sex,
                    Email = client.Email,
                    //Login = client.Login,
                    Password = client.Password,
                    PassportNumber = client.PassportNumber,
                    PassportSeries = client.PassportSeries
                    //BankCard = client.BankCard,
                    //ImagePath = client.ImagePath
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

        public static void UpdateClient(Client client)
        {
            using (var context = new Db.OpenRentEntities())
            {
                var dbClient = context.Client.SingleOrDefault(x => x.Guid == client.Guid);
                if(dbClient == null)
                {
                    return;
                }

                dbClient.FirstName = client.FirstName;
                dbClient.LastName = client.LastName;
                dbClient.Patronymic = client.Patronymic;
                dbClient.Birthday = client.Birthday;
                dbClient.Phone = client.Phone;
                dbClient.Sex = client.Sex;
                dbClient.Email = client.Email;
                //dbClient.Login = client.Login;
                dbClient.Password = client.Password;
                dbClient.PassportSeries = client.PassportSeries;
                dbClient.PassportNumber = client.PassportNumber;
                //dbClient.BankCard = client.BankCard;
                //dbClient.ImagePath = client.ImagePath;


                context.SaveChanges();
            }
        }
    }
}
