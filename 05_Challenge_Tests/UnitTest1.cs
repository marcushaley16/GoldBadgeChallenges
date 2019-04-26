using System;
using System.Collections.Generic;
using _05_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_Challenge_Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void AddCustomerTest()
        {
            // Arrange
            GreetRepository greetRepo = new GreetRepository();
            Customer customer = new Customer("Daenerys", "Targaryen", CustomerType.Current, 18, "Khaleesi@westeros.com", 7777);

            // Act
            greetRepo.AddNewCustomer(customer);
            List<Customer> list = greetRepo.SeeAllCustomers();

            var expected = 1;
            var actual = list.Count;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(list.Contains(customer));
        }

        [TestMethod]
        public void RemoveCustomerTest()
        {
            // Arrange
            GreetRepository greetRepo = new GreetRepository();
            Customer customer = new Customer("Daenerys", "Targaryen", CustomerType.Current, 18, "Khaleesi@westeros.com", 7777);

            // Act
            greetRepo.RemoveCustomerFromList(customer);
            List<Customer> list = greetRepo.SeeAllCustomers();

            var expected = 0;
            var actual = list.Count;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.IsFalse(list.Contains(customer));
        }

        [TestMethod]
        public void GetCustomerByIDTest()
        {
            // Arrange
            GreetRepository greetRepo = new GreetRepository();
            Customer customer = new Customer("Daenerys", "Targaryen", CustomerType.Current, 18, "Khaleesi@westeros.com", 7777);

            // Act
            greetRepo.GetCustomerByID(7777);
            
            var expected = 7777;
            var actual = customer.ID;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
