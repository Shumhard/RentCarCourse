using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DbWorkers.Tests
{
    [TestClass()]
    public class DbCarWorkerTests
    {
        [TestMethod()]
        public void GetCarTest()
        {
            var carGuid = Guid.NewGuid();
            var car = new Car
            {
                Guid = carGuid,
                Mark = "Audi",
                Model = "Sedan"
            };

            DbCarWorker.AddCar(car);
            var getCar = DbCarWorker.GetCar(carGuid);
            Assert.IsNotNull(getCar);
            DbCarWorker.DeleteCar(carGuid);
        }

        [TestMethod()]
        public void AddCarTest()
        {
            var carGuid = Guid.NewGuid();
            var car = new Car
            {
                Guid = carGuid,
                Mark = "Matiz",
                Model = "Sedan"
            };

            DbCarWorker.AddCar(car);
            var getCar = DbCarWorker.GetCar(carGuid);

            Assert.IsNotNull(getCar);
            Assert.AreEqual(getCar.Mark, "Matiz");
            Assert.AreEqual(getCar.Model, "Sedan");

            DbCarWorker.DeleteCar(carGuid);
        }

        [TestMethod()]
        public void DeleteCarTest()
        {
            var carGuid = Guid.NewGuid();
            var car = new Car
            {
                Guid = carGuid,
                Mark = "Matiz",
                Model = "Sedan"
            };

            DbCarWorker.AddCar(car);

            var getCar = DbCarWorker.GetCar(carGuid);
            Assert.IsNotNull(getCar);

            DbCarWorker.DeleteCar(carGuid);

            getCar = DbCarWorker.GetCar(carGuid);
            Assert.IsNull(getCar);
        }

        [TestMethod()]
        public void UpdateCarTest()
        {
            var carGuid = Guid.NewGuid();
            var car = new Car
            {
                Guid = carGuid,
                Mark = "Matiz",
                Model = "Sedan"
            };

            DbCarWorker.AddCar(car);

            var getCar = DbCarWorker.GetCar(carGuid);
            Assert.IsNotNull(getCar);

            getCar.Mark = "Matizy";
            getCar.Model = "Sedany";
            DbCarWorker.UpdateCar(getCar);

            var updatedCar = DbCarWorker.GetCar(carGuid);
            Assert.IsNotNull(getCar);
            Assert.AreEqual(getCar.Mark, "Matizy");
            Assert.AreEqual(getCar.Model, "Sedany");

            DbCarWorker.DeleteCar(carGuid);
        }
    }
}