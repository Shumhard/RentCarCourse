using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;

namespace RentCarTest
{
    [TestClass]
    public class CarCheckBusynessTest
    {
        private DateTime HD, LD;
        private Car car = new Car()
        {
            LowRentalDate = Convert.ToDateTime("10/11/18"),
            HighRentalDate = Convert.ToDateTime("20/11/18")
        };

        [TestMethod]
        public void TestMethod_LD_more_carHD__right()
        {
            HD = new DateTime();
            LD = car.HighRentalDate.AddDays(2);
            bool result = car.CheckBusyness(LD, HD);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod_HD_less_carLD__left()
        {
            HD = car.LowRentalDate.AddDays(-2);
            LD = HD.AddDays(-5);
            bool result = car.CheckBusyness(LD, HD);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod_LD_more_carHD_AND_HD_more_carHD__right()
        {
            HD = car.HighRentalDate.AddDays(7);
            LD = car.HighRentalDate.AddDays(4);
            bool result = car.CheckBusyness(LD, HD);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod_LD_less_carLD_AND_HD_less_carLD__left()
        {
            HD = car.LowRentalDate.AddDays(-2);
            LD = car.LowRentalDate.AddDays(-4);
            bool result = car.CheckBusyness(LD, HD);
            bool expected = false;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod_LD_more_carLD_AND_HD_less_carHD__in()
        {
            HD = car.HighRentalDate.AddDays(-2);
            LD = car.LowRentalDate.AddDays(2);
            bool result = car.CheckBusyness(LD, HD);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod_LD_less_carLD_AND_HD_more_carHD__contain()
        {
            HD = car.HighRentalDate.AddDays(2);
            LD = car.LowRentalDate.AddDays(-2);
            bool result = car.CheckBusyness(LD, HD);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod_LD_less_carLD_AND_HD_more_carLD__left_in()
        {
            HD = car.LowRentalDate.AddDays(2);
            LD = car.LowRentalDate.AddDays(-2);
            bool result = car.CheckBusyness(LD, HD);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod_LD_less_carHD_AND_HD_more_carHD__right_in()
        {
            HD = car.HighRentalDate.AddDays(2);
            LD = car.HighRentalDate.AddDays(-2);
            bool result = car.CheckBusyness(LD, HD);
            bool expected = true;
            Assert.AreEqual(expected, result);
        }
    }
}