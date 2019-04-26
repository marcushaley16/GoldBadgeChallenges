using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge_Repository
{
    public class GreenPlanRepository
    {
        private List<Car> _listOfCars = new List<Car>();

        public void CollectCarData(Car car)
        {
            _listOfCars.Add(car);
        }

        public List<Car> GetListOfCars()
        {
            return _listOfCars;
        }

        public Car GetCarByID(int carID)
        {
            Car car = new Car();

            foreach(Car c in _listOfCars)
            {
                if (c.CarID == carID)
                {
                    return c;
                }
            }
            return null;
        }

        public CarType GetCarsByType(int typeChoice)
        {
            CarType type = new CarType();
            switch (typeChoice)
            {
                case 1:
                    type = CarType.Electric;
                    break;
                case 2:
                    type = CarType.Hybrid;
                    break;
                case 3:
                    type = CarType.Gas;
                    break;
            }
            return type;
        }

        public void RemoveCarFromList(Car car)
        {
            _listOfCars.Remove(car);
        }
    }
}
