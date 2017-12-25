using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RentCarTest
{
    [TestClass]
    public class CommonOrderTest
    {
        [TestMethod]
        public void GetRentRange_WithValidDateTime_2018_10_15_20_30_29_and_2016_12_2_1_29_19_Expected_1_10_13_19_1_10()
        {
            //  Arrange
            var order = new Common.Order()
            {
                RentBeginDate = new DateTime(2016, 12, 2, 1, 29, 19),
                RentEndDate = new DateTime(2018, 10, 15, 20, 30, 29)
            };
            var expected = new TimeSpan(682, 19, 1, 10);

            //  Act
            var result = order.GetRentRange();

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetRentRange_WithInvalidDateTime_2017_10_14_20_30_29_and_2017_10_15_20_30_29_Expected_InvalidOperationException()
        {
            //  Arrange
            var order = new Common.Order()
            {
                RentBeginDate = new DateTime(2017, 10, 15, 20, 30, 29),
                RentEndDate = new DateTime(2017, 10, 14, 20, 30, 29)
            };

            try
            {
                //  Act
                var result = order.GetRentRange();
            }
            catch (InvalidOperationException e)
            {
                //  Assert
                StringAssert.Contains(e.Message, Common.Order.InvalidOperationExceptionMessage);
                return;
            }

            //  Assert
            Assert.Fail("No exception was thrown.");
        }

        [TestMethod]
        public void GetRentRange_WithInvalidDateTime_null_and_2017_10_15_20_30_29_Expected_ArgumentNullException()
        {
            //  Arrange
            var order = new Common.Order()
            {
                RentBeginDate = new DateTime(2017, 10, 15, 20, 30, 29),
                RentEndDate = null
            };

            try
            {
                //  Act
                var result = order.GetRentRange();
            }
            catch (ArgumentNullException e)
            {
                //  Assert
                StringAssert.Contains(e.Message, Common.Order.ArgumentNullExceptionMessage);
                return;
            }

            //  Assert
            Assert.Fail("No exception was thrown.");
        }
    }
}