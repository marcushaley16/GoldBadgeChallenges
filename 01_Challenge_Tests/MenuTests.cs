using System;
using System.Collections.Generic;
using _01_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge_Tests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void AddMealToMenuTest()
        {
            // Arrange
            MenuRepository menuRepo = new MenuRepository();
            Menu meal = new Menu(1, "Pepperoni Pizza", "2 slices of pepperoni pizza with a bread stick and drink", "Pepperoni, mozzerella cheese, marinara sauce", 5m);

            // Act
            menuRepo.AddMealToMenu(meal);
            List<Menu> list = menuRepo.SeeMenu();

            var expected = 1;
            var actual = list.Count;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(list.Contains(meal));
        }

        [TestMethod]
        public void RemoveMealFromMenuTest()
        {
            // Arrange
            MenuRepository menuRepo = new MenuRepository();
            Menu meal = new Menu(1, "Pepperoni Pizza", "2 slices of pepperoni pizza with a bread stick and drink", "Pepperoni, mozzerella cheese, marinara sauce", 5m);

            // Act
            menuRepo.RemoveMealFromMenu(menuID: 1);
            List<Menu> list = menuRepo.SeeMenu();

            var expected = 0;
            var actual = list.Count;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.IsFalse(list.Contains(meal));
        }
    }
}
