using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PriceWithDiscountTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void price100discount005num95()
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

        [TestMethod]
        public void price10discount002num2()
        {
            //arrange
            decimal price = 10;
            decimal discount = (Decimal)0.02;
            decimal num = (decimal)9.8;

            //Act

            price = CoffeHause.ClassHelper.DecimalClass.Discount(price, discount);

            //Assert

            Assert.AreEqual(price, num);
        }
        [TestMethod]
        public void pricem10discount003num2()
        {
            //arrange
            decimal price = -10;
            decimal discount = (Decimal)0.02;
            decimal num = (decimal)-9.8;

            //Act

            price = CoffeHause.ClassHelper.DecimalClass.Discount(price, discount);

            //Assert

            Assert.AreEqual(price, num);
        }
        [TestMethod]
        public void pricem98discount003num9()
        {
            //arrange
            decimal price = (decimal)-9.8;
            decimal discount = (decimal)0.02;
            decimal num = (decimal)-9.604;

            //Act

            price = CoffeHause.ClassHelper.DecimalClass.Discount(price, discount);

            //Assert

            Assert.AreEqual(price, num);
        }

        [TestMethod]
        public void pricem11discount500numm40()
        {
            //arrange
            decimal price = (decimal)10;
            decimal discount = (decimal)5;
            decimal num = (decimal)-40;

            //Act

            price = CoffeHause.ClassHelper.DecimalClass.Discount(price, discount);

            //Assert

            Assert.AreEqual(price, num);
        }

        [TestMethod]
        public void pricem9discount9numm819()
        {
            //arrange
            decimal price = (decimal)9;
            decimal discount = (decimal)0.09;
            decimal num = (decimal)8.19;

            //Act

            price = CoffeHause.ClassHelper.DecimalClass.Discount(price, discount);

            //Assert

            Assert.AreEqual(price, num);
        }
        [TestMethod]
        public void price15discount9numm13()
        {
            //arrange
            decimal price = (decimal)1.5;
            decimal discount = (decimal)0.09;
            decimal num = (decimal)1.365;

            //Act

            price = CoffeHause.ClassHelper.DecimalClass.Discount(price, discount);

            //Assert

            Assert.AreEqual(price, num);
        }
        [TestMethod]
        public void pricem15discount9numm60()
        {
            //arrange
            decimal price = (decimal)-15;
            decimal discount = (decimal)5;
            decimal num = (decimal)60;

            //Act

            price = CoffeHause.ClassHelper.DecimalClass.Discount(price, discount);

            //Assert

            Assert.AreEqual(price, num);
        }
        [TestMethod]
        public void pricem15discount15numm375()
        {
            //arrange
            decimal price = (decimal)-15;
            decimal discount = (decimal)-1.5;
            decimal num = (decimal)-37.5;

            //Act

            price = CoffeHause.ClassHelper.DecimalClass.Discount(price, discount);

            //Assert

            Assert.AreEqual(price, num);
        }
        [TestMethod]
        public void pricem15discount002numm1530()
        {
            //arrange
            decimal price = (decimal)-15;
            decimal discount = (decimal)-0.02;
            decimal num = (decimal)-15.30;

            //Act

            price = CoffeHause.ClassHelper.DecimalClass.Discount(price, discount);

            //Assert

            Assert.AreEqual(price, num);
        }
    }
}
