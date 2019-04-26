using _06_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Challenge_Console
{
    class ProgramUI
    {
        private GreenPlanRepository _carsRepo = new GreenPlanRepository();

        internal void Run()
        {
            SeedList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("What would you like to do?\n" +
                    "1. Add a car to the list\n" +
                    "2. See all cars\n" +
                    "3. Search for car by ID\n" +
                    "4. Search for cars by Type\n" +
                    "5. Delete a car from the list\n" +
                    "6. Update data for a car\n" +
                    "7. Exit\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Add car to list
                        AddCar();
                        break;
                    case "2":
                        SeeAllCars();
                        break;
                    case "3":
                        // See data for a specific car
                        SeeCarByID();
                        break;
                    case "4":
                        // See cars by type
                        SeeCarsByType();
                        break;
                    case "5":
                        // Delete a car from the list
                        RemoveCar();
                        break;
                    case "6":
                        // Update car data
                        UpdateCar();
                        break;
                    case "7":
                        running = false;
                        break;
                }
            }
        }

        private void AddCar()
        {
            Console.WriteLine("What type of car would you like to add?\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n");

            string inputAsString = Console.ReadLine();
            int input = int.Parse(inputAsString);
            CarType type = (CarType)input;

            Console.WriteLine("What is the make of the car?");
            string carMake = Console.ReadLine();

            Console.WriteLine("What is the model of the car?");
            string carModel = Console.ReadLine();

            Console.WriteLine("What is the year of the car?");
            string yearAsString = Console.ReadLine();
            int carYear = int.Parse(yearAsString);

            Console.WriteLine("How many doors does the car have?");
            string doorsAsString = Console.ReadLine();
            int doorNumber = int.Parse(doorsAsString);

            Console.WriteLine("What color is the car?");
            string carColor = Console.ReadLine();

            Console.WriteLine("Enter a unique ID Number for the car.");
            string idAsString = Console.ReadLine();
            int carID = int.Parse(idAsString);

            Car newCar = new Car(type, carMake, carModel, carYear, doorNumber, carColor, carID);
            _carsRepo.CollectCarData(newCar);
        }

        private void SeeAllCars()
        {
            List<Car> list = _carsRepo.GetListOfCars();

            foreach (Car car in list)
            {
                Console.WriteLine($"Type: {car.Type}\n" +
                    $"Year: {car.CarYear}\n" +
                    $"Make: {car.CarMake}\n" +
                    $"Model: {car.CarModel}\n" +
                    $"Doors: {car.DoorNumber}\n" +
                    $"Color: {car.CarColor}\n" +
                    $"ID: {car.CarID}\n");
            }
            Console.ReadLine();
        }

        private void SeeCarByID()
        {
            // Ask for an ID to search by
            Console.WriteLine("Enter the ID number for the car you would like to see.");

            // Get user input
            int carID = int.Parse(Console.ReadLine());

            // Find the correct car
            Car car = _carsRepo.GetCarByID(carID);

            if (car != null)
            {
                Console.WriteLine($"Type: {car.Type}\n" +
                    $"Year: {car.CarYear}\n" +
                    $"Make: {car.CarMake}\n" +
                    $"Model: {car.CarModel}\n" +
                    $"Doors: {car.DoorNumber}\n" +
                    $"Color: {car.CarColor}\n" +
                    $"ID: {car.CarID}\n");
            }
            else
            {
                Console.WriteLine("There are no cars that match the entered ID.");
            }
            Console.ReadLine();
        }

        private void SeeCarsByType()
        {
            List<Car> list = _carsRepo.GetListOfCars();
            // Ask for type to search by
            Console.WriteLine("Which type of cars would you like to see?\n 1. Electric\n 2. Hybrid\n 3. Gas\n");

            // Get user input
            var typeResponse = int.Parse(Console.ReadLine());

            foreach (Car c in list)
            {
                if (c.Type == (CarType)typeResponse)
                {
                    Console.WriteLine($"Type: {c.Type}\n Year: {c.CarYear}\n Make: {c.CarMake}\n Model: {c.CarModel}\n ID: {c.CarID}\n");
                }
            }
            Console.ReadLine();
        }

        private void RemoveCar()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID Number of the car that you would like to remove from the list.");

            int carID = int.Parse(Console.ReadLine());

            Car car = _carsRepo.GetCarByID(carID);

            if (car != null)
            {
                Console.WriteLine($"Type: {car.Type}\n" +
                    $"Year: {car.CarYear}\n" +
                    $"Make: {car.CarMake}\n" +
                    $"Model: {car.CarModel}\n" +
                    $"Doors: {car.DoorNumber}\n" +
                    $"Color: {car.CarColor}\n" +
                    $"ID: {car.CarID}\n");

                Console.WriteLine("Please confirm that this is the car that you would like to remove from the list. (Y/N)");
                string confirmAsString = Console.ReadLine().ToLower(); // Converts to all lowercase
                bool confirm = false;

                switch (confirmAsString)
                {
                    case "y":
                    case "yes":
                        confirm = true;
                        Console.WriteLine("The car has been removed from the list.");
                        _carsRepo.RemoveCarFromList(car);
                        break;
                    case "n":
                    case "no":
                    default: // Makes it default to false if y, yes, n, no is not entered
                        confirm = false;
                        Console.WriteLine("Car removal has been cancelled.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("There are no cars that match the entered ID.");
            }
            Console.ReadLine();
        }

        private void UpdateCar()
        {
            // Ask for an ID to search by
            Console.WriteLine("Enter the ID number for the car you would like to see.");

            // Get user input
            int carID = int.Parse(Console.ReadLine());

            // Find the correct car
            Car car = _carsRepo.GetCarByID(carID);

            if (car != null)
            {
                Console.WriteLine($"Type: {car.Type}\n" +
                    $"Year: {car.CarYear}\n" +
                    $"Make: {car.CarMake}\n" +
                    $"Model: {car.CarModel}\n" +
                    $"Doors: {car.DoorNumber}\n" +
                    $"Color: {car.CarColor}\n" +
                    $"ID: {car.CarID}\n");
            }
            else
            {
                Console.WriteLine("There are no cars that match the entered ID.");
            }

            Console.WriteLine("Which property would you like to update?\n" +
                "1. Car Type\n" +
                "2. Year\n" +
                "3. Make\n" +
                "4. Model\n" +
                "5. Number of doors\n" +
                "6. Color\n" +
                "7. Car ID\n" +
                "8. No change");
            int propertyChoice = int.Parse(Console.ReadLine());

            switch (propertyChoice)
            {
                case 1:
                    Console.WriteLine($"The current Type is {car.Type}.");
                    car.Type = EnterNewType();
                    break;
                case 2:
                    Console.WriteLine($"The current car Year is {car.CarYear}.");
                    car.CarYear = EnterNewYear();
                    break;
                case 3:
                    Console.WriteLine($"The current car Make is {car.CarMake}.");
                    car.CarMake = EnterNewMake();
                    break;
                case 4:
                    Console.WriteLine($"The current car Model is {car.CarModel}.");
                    car.CarModel = EnterNewModel();
                    break;
                case 5:
                    Console.WriteLine($"The current Number of Doors is {car.DoorNumber}.");
                    car.DoorNumber = EnterNewDoorNumber();
                    break;
                case 6:
                    Console.WriteLine($"The current Color is {car.CarColor}.");
                    car.CarColor = EnterNewColor();
                    break;
                case 7:
                    Console.WriteLine($"The current Car ID is {car.CarID}.");
                    car.CarID = EnterNewCarID();
                    break;
                default:
                    break;
            }
            Console.WriteLine("Car data has been updated.");
            Console.ReadLine();
        }

        private CarType EnterNewType()
        {
            Console.WriteLine("Select a new Type for the car.\n" +
                "1. Electric\n" +
                "2. Hybrid\n" +
                "3. Gas\n");
            var typeResponse = int.Parse(Console.ReadLine());
            var type = _carsRepo.GetCarsByType(typeResponse);
            return type;
        }

        private int EnterNewYear()
        {
            Console.WriteLine("Enter a new year.");
            return int.Parse(Console.ReadLine());
        }

        private string EnterNewMake()
        {
            Console.WriteLine("Enter a new make.");
            return Console.ReadLine();
        }

        private string EnterNewModel()
        {
            Console.WriteLine("Enter a new model.");
            return Console.ReadLine();
        }

        private int EnterNewDoorNumber()
        {
            Console.WriteLine("Enter a new Door Number.");
            return int.Parse(Console.ReadLine());
        } 

        private string EnterNewColor()
        {
            Console.WriteLine("Enter a new Color.");
            return Console.ReadLine();
        }

        private int EnterNewCarID()
        {
            Console.WriteLine("Enter a new Car ID.");
            return int.Parse(Console.ReadLine());
        }
        private void SeedList()
        {
            Car carOne = new Car(CarType.Gas, "Subaru", "WRX STi", 2019, 4, "Blue", 2617);
            Car carTwo = new Car(CarType.Electric, "Tesla", "Model X", 2018, 4, "Black", 0616);
            Car carThree = new Car(CarType.Gas, "Nissan", "GTR", 2019, 2, "Red", 2416);
            Car carFour = new Car(CarType.Hybrid, "Honda", "Accord", 2017, 4, "White", 0617);

            _carsRepo.CollectCarData(carOne);
            _carsRepo.CollectCarData(carTwo);
            _carsRepo.CollectCarData(carThree);
            _carsRepo.CollectCarData(carFour);
        }
    }
}
