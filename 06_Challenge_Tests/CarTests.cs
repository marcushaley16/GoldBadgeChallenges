using System;
using System.Collections.Generic;
using _06_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_Challenge_Tests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void AddCarTest()
        {
            // Arrange
            GreenPlanRepository carRepo = new GreenPlanRepository();
            Car car = new Car(CarType.Gas, "Honda", "Civic", 2019, 4, "Black", 1642);

            // Act
            carRepo.CollectCarData(car);
            List<Car> list = carRepo.GetListOfCars();

            var expected = 1;
            var actual = list.Count;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(list.Contains(car));
        }

        [TestMethod]
        public void GetCarByIDTest()
        {
            // Arrange
            GreenPlanRepository carRepo = new GreenPlanRepository();
            Car car = new Car(CarType.Electric, "Tesla", "Model S", 2019, 4, "Orange", 9999);

            // Act
            carRepo.GetCarByID(9999);

            var actual = 9999;
            var expected = car.CarID;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveCarTest()
        {
            // Arrange
            GreenPlanRepository carRepo = new GreenPlanRepository();
            Car car = new Car(CarType.Electric, "Tesla", "Model S", 2019, 4, "Orange", 9999);

            // Act
            carRepo.RemoveCarFromList(car);
            List<Car> list = carRepo.GetListOfCars();

            var expected = 0;
            var actual = list.Count;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsFalse(list.Contains(car));
        }
    }
}
