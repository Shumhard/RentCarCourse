using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using DbWorkers;

namespace RentCarTest
{
    [TestClass]
    public class DbClientWorkerTest
    {
        /// <summary>
        /// Тест метода получения клиента
        /// </summary>
        [TestMethod]
        public void TestGetClient()
        {
            var clientGuid = Guid.NewGuid();
            var client = new Client
            {
                Guid = clientGuid,
                Login = "UnitTestLogin",
                Password = "UnitTestPassword"
            };

            DbClientWorker.AddClient(client);
            var getClient = DbClientWorker.GetClient(clientGuid);
            Assert.IsNotNull(getClient);
            DbClientWorker.DeleteClient(clientGuid);
        }

        /// <summary>
        /// Тест метода добавления нового клиента
        /// </summary>
        [TestMethod]
        public void TestAddClient()
        {
            var clientGuid = Guid.NewGuid();
            var client = new Client
            {
                Guid = clientGuid,
                Login = "UnitTestLogin",
                Password = "UnitTestPassword"
            };

            DbClientWorker.AddClient(client);
            var getClient = DbClientWorker.GetClient(clientGuid);

            Assert.IsNotNull(getClient);
            Assert.AreEqual(getClient.Login, "UnitTestLogin");
            Assert.AreEqual(getClient.Password, "UnitTestPassword");

            DbClientWorker.DeleteClient(clientGuid);
        }

        /// <summary>
        /// Тест метода удаления клиента
        /// </summary>
        [TestMethod]
        public void TestDeleteClient()
        {
            var clientGuid = Guid.NewGuid();
            var client = new Client
            {
                Guid = clientGuid,
                Login = "UnitTestLogin",
                Password = "UnitTestPassword"
            };

            DbClientWorker.AddClient(client);

            var getClient = DbClientWorker.GetClient(clientGuid);
            Assert.IsNotNull(getClient);

            DbClientWorker.DeleteClient(clientGuid);

            getClient = DbClientWorker.GetClient(clientGuid);
            Assert.IsNull(getClient);
        }

        /// <summary>
        /// Тест метода обновления клиента
        /// </summary>
        [TestMethod]
        public void TestUpdateClient()
        {
            var clientGuid = Guid.NewGuid();
            var client = new Client
            {
                Guid = clientGuid,
                Login = "UnitTestLogin",
                Password = "UnitTestPassword"
            };

            DbClientWorker.AddClient(client);

            var getClient = DbClientWorker.GetClient(clientGuid);
            Assert.IsNotNull(getClient);

            getClient.Login = "nigoLtseTtinU";
            getClient.Password = "drowssaPtseTtinU";
            DbClientWorker.UpdateClient(getClient);

            var updatedClient = DbClientWorker.GetClient(clientGuid);
            Assert.IsNotNull(getClient);
            Assert.AreEqual(getClient.Login, "nigoLtseTtinU");
            Assert.AreEqual(getClient.Password, "drowssaPtseTtinU");

            DbClientWorker.DeleteClient(clientGuid);
        }
    }
}
