using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PriceWithDiscountTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void price100discount5num95()
        {
            //arrange
            decimal price = 100;
            decimal discount = (Decimal)0.05;
            decimal num = 95;

            //Act

            price = CoffeHause.ClassHelper.DecimalClass.Discount(price, discount);

            //Assert

            Assert.AreEqual(price, num);
        }
    }
}
