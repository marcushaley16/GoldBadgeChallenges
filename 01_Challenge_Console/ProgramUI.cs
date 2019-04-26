using _01_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Console
{
    public class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        internal void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("What would you like to do?\n" +
                    "1. Add Meal to Menu\n" +
                    "2. Remove Meal from Menu\n" +
                    "3. See Menu\n" +
                    "4. Exit\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Add meal to menu
                        AddMeal();
                        break;
                    case "2":
                        // Remove meal from menu
                        RemoveMeal();
                        break;
                    case "3":
                        // See menu
                        ShowMenu();
                        break;
                    case "4":
                        // Exit
                        running = false;
                        break;
                }
            }
        }
        private void AddMeal()
        {
            Console.WriteLine("What would you like to name the meal?");
            string mealName = Console.ReadLine();

            Console.WriteLine("What number would you like to assign to the meal?");
            string mealNumAsString = Console.ReadLine();
            int mealNumber = int.Parse(mealNumAsString);

            Console.WriteLine("Enter a description for the meal.");
            string mealDescription = Console.ReadLine();

            Console.WriteLine("List each of the meal's ingredients seperated by commas.");
            string mealIngredients = Console.ReadLine();

            Console.WriteLine("Enter the price of the meal.");
            string mealPriceAsString = Console.ReadLine();
            decimal mealPrice = decimal.Parse(mealPriceAsString);

            Menu newMeal = new Menu(mealNumber, mealName, mealDescription, mealIngredients, mealPrice);
            _menuRepo.AddMealToMenu(newMeal);
        }

        private void RemoveMeal()
        {
            Console.Clear();
            
            List<Menu> menu = _menuRepo.SeeMenu();

            foreach (Menu meal in menu)
            {
                Console.WriteLine($"Name: {meal.MealName}\n Number: {meal.MealNumber}\n Description: {meal.MealDescription}\n Ingredients: {meal.MealIngredients}\n Price: {meal.MealPrice}\n");
            }

            Console.WriteLine("Enter the number of the meal that you would like to remove from the menu.");
            string mealNumAsString = Console.ReadLine();
            int mealNumber = int.Parse(mealNumAsString);
            _menuRepo.RemoveMealFromMenu(mealNumber);

            Console.WriteLine("The meal has been removed from the menu.");
            Console.ReadLine();
        }

        private void ShowMenu()
        {
            List<Menu> menu = _menuRepo.SeeMenu();

            foreach (Menu meal in menu)
            {
                Console.WriteLine($"Name: {meal.MealName}\n Number: {meal.MealNumber}\n Description: {meal.MealDescription}\n Ingredients: {meal.MealIngredients}\n Price: {meal.MealPrice}\n");
            }
            Console.ReadLine();
        }
    }
}
