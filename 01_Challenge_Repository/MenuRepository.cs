using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Repository
{
    public class MenuRepository
    {
        private List<Menu> _menu = new List<Menu>();
        //private List<Ingredients> _listOfIngredients = new List<Ingredients>;

        public void AddMealToMenu(Menu meal)
        {
            _menu.Add(meal);
        }

        public void RemoveMealFromMenu(int menuID)
        {
            foreach (Menu meal in _menu)
            {
                if (meal.MealNumber == menuID)
                {
                    _menu.Remove(meal);
                    break;
                }
            }
            
        }
        public List<Menu> SeeMenu()
        {
            return _menu;
        }
    }
}
