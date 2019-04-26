using System;
using System.Collections.Generic;
using _02_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Challenge_Tests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void AddNewClaimTest()
        {
            // Arrange
            ClaimsRepository claimsRepo = new ClaimsRepository();
            Claims claim = new Claims(9999, ClaimType.Car, "Hit by meteorite", 10000m, new DateTime(2019 - 4 - 10), new DateTime(2019 - 4 - 15), true);

            // Act
            claimsRepo.AddNewClaim(claim);
            Queue<Claims> queue = claimsRepo.SeeAllClaims();

            var expected = 1;
            var actual = queue.Count;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(queue.Contains(claim));
        }

        [TestMethod]
        public void GetNextClaimTest()
        {
            // Arrange


            // Act


            // Assert


        }

        [TestMethod]
        public void PeekNextClaimTest()
        {
            // Arrange


            // Act


            // Assert


        }
    }
}
