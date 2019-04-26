using _05_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge_Console
{
    public class ProgramUI
    {
        private GreetRepository _greetRepo = new GreetRepository();

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
                    "1. Add a new customer\n" +
                    "2. See all customers\n" +
                    "3. See customers by type\n" +
                    "4. Update customer data\n" +
                    "5. Remove a customer\n" +
                    "6. Email customers\n" +
                    "7. Exit\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Add a new customer
                        AddCustomer();
                        break;
                    case "2":
                        // See all customers
                        SeeCustomerList();
                        break;
                    case "3":
                        // See customers by type
                        SeeCustomersByType();
                        break;
                    case "4":
                        // Update customer data
                        UpdateCustomerData();
                        break;
                    case "5":
                        // Remove a customer
                        RemoveCustomer();
                        break;
                    case "6":
                        // Email customers
                        EmailCustomers();
                        break;
                    case "7":
                        // Exit
                        running = false;
                        break;
                }
            }
        }

        private void AddCustomer()
        {
            Console.Clear();

            Console.WriteLine("Which type of customer would you like to add?\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential\n");

            string inputAsString = Console.ReadLine();
            int input = int.Parse(inputAsString);
            CustomerType type = (CustomerType)input;

            Console.WriteLine("What is the customer's First Name?");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is the customer's Last Name?");
            string lastName = Console.ReadLine();

            Console.WriteLine("What is the customer's Age?");
            string ageAsString = Console.ReadLine();
            int age = int.Parse(ageAsString);

            Console.WriteLine("What is the customer's Email?");
            string email = Console.ReadLine();

            Console.WriteLine("Enter a unique ID number for the customer.");
            string idAsString = Console.ReadLine();
            int id = int.Parse(idAsString);

            Customer newCustomer = new Customer(firstName, lastName, type, age, email, id);
            _greetRepo.AddNewCustomer(newCustomer);
        }

        private void SeeCustomerList()
        {
            Console.Clear();

            List<Customer> list = _greetRepo.SeeAllCustomers();
            List<Customer> sortedList = list.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();

            Console.WriteLine($"Last Name First Name Type Age ID Email\n");
            foreach (Customer customer in sortedList)
            {
                Console.WriteLine($"{customer.LastName} {customer.FirstName} {customer.Type} {customer.Age} {customer.ID} {customer.Email}");
            }
            Console.ReadLine();
        }

        private void SeeCustomersByType()
        {
            Console.Clear();

            List<Customer> list = _greetRepo.SeeAllCustomers();
            List<Customer> sortedList = list.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();

            Console.WriteLine("Which type of customers would you like to see?\n 1. Current\n 2. Past\n 3. Potential\n");
            var typeResponse = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine($"Last Name First Name Type Age ID Email\n");
            foreach (Customer customer in sortedList)
            {
                if (customer.Type == (CustomerType)typeResponse)
                {
                    Console.WriteLine($"{customer.LastName} {customer.FirstName} {customer.Type} {customer.Age} {customer.ID} {customer.Email}");
                }
            }
            Console.ReadLine();
        }

        private void UpdateCustomerData()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID number for the customer you would like to update.");

            int id = int.Parse(Console.ReadLine());

            Customer customer = _greetRepo.GetCustomerByID(id);

            if (customer != null)
            {
                Console.WriteLine($"Last Name: {customer.LastName}\n" +
                    $"First Name: {customer.FirstName}\n" +
                    $"Type: {customer.Type}\n" +
                    $"Age: {customer.Age}\n" +
                    $"Email: {customer.Email}\n" +
                    $"ID: {customer.ID}\n");
            }
            else
            {
                Console.WriteLine("There are no customers that match the entered ID.");
            }

            Console.WriteLine("Which property would you like to update?\n" +
                "1. Last Name\n" +
                "2. First Name\n" +
                "3. Type\n" +
                "4. Age\n" +
                "5. Email\n" +
                "6. ID\n" +
                "7. No Change\n");
            int propertyChoice = int.Parse(Console.ReadLine());

            switch (propertyChoice)
            {
                case 1:
                    Console.WriteLine($"The current Last Name is {customer.LastName}.");
                    customer.LastName = EnterNewLastName();
                    break;
                case 2:
                    Console.WriteLine($"The current first name is {customer.FirstName}.");
                    customer.FirstName = EnterNewFirstName();
                    break;
                case 3:
                    Console.WriteLine($"The current type is {customer.Type}.");
                    customer.Type = EnterNewType();
                    break;
                case 4:
                    Console.WriteLine($"The current age is {customer.Age}.");
                    customer.Age = EnterNewAge();
                    break;
                case 5:
                    Console.WriteLine($"The current email is {customer.Email}.");
                    customer.Email = EnterNewEmail();
                    break;
                case 6:
                    Console.WriteLine($"The current ID is {customer.ID}.");
                    customer.ID = EnterNewID();
                    break;
                case 7:
                    RunMenu();
                    break;
                default:
                    break;
            }
            Console.WriteLine("Customer data has been updated.");
            Console.ReadLine();
        }

        private void RemoveCustomer()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of the customer that you would like to remove.");

            int id = int.Parse(Console.ReadLine());

            Customer customer = _greetRepo.GetCustomerByID(id);

            if (customer != null)
            {
                Console.WriteLine($"Last Name: {customer.LastName}\n" +
                    $"First Name: {customer.FirstName}\n" +
                    $"Type: {customer.Type}\n" +
                    $"Age: {customer.Age}\n" +
                    $"Email: {customer.Email}\n" +
                    $"ID: {customer.ID}\n");

                Console.WriteLine("Please confirm that this is the customer that you would like to remove. ( Y / N )");
                string confirmAsString = Console.ReadLine().ToLower();
                bool confirm = false;

                switch (confirmAsString)
                {
                    case "y":
                    case "yes":
                        confirm = true;
                        Console.WriteLine("The customer has been removed from the list.");
                        _greetRepo.RemoveCustomerFromList(customer);
                        break;
                    case "n":
                    case "no":
                    default:
                        confirm = false;
                        Console.WriteLine("Customer removal has been cancelled.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("There are no customers that match the entered ID.");
            }
            Console.ReadLine();
        }

        private void EmailCustomers()
        {
            Console.Clear();

            List<Customer> list = _greetRepo.SeeAllCustomers();
            List<Customer> sortedList = list.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();

            Console.WriteLine("Which type of customers would you like to email?\n 1. Current\n 2. Past\n 3. Potential\n");
            var typeResponse = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine($"Last Name First Name Type Age ID Email\n");
            foreach (Customer customer in sortedList)
            {
                if (customer.Type == (CustomerType)typeResponse)
                {
                    Console.WriteLine($"{customer.LastName} {customer.FirstName} {customer.Type} {customer.Age} {customer.ID} {customer.Email}\n");
                }
            }

            foreach (Customer customer in sortedList)
            {
                if (customer.Type == CustomerType.Current)
                {
                    Console.WriteLine("\nEmail: Thank you for your work with us. We appreciate your loyalty. Here's a coupon.\n\n");
                }
                else if (customer.Type == CustomerType.Past)
                {
                    Console.WriteLine("\nEmail: It's been a long time since we've heard from you, we want you back.\n\n");
                }
                else if (customer.Type == CustomerType.Potential)
                {
                    Console.WriteLine("\nEmail: We currently have the lowest rates on Helicopter insurance!\n\n");
                }

                Console.WriteLine("Would you like to send the Email to all listed customers now? ( Y / N )");
                string confirmAsString = Console.ReadLine().ToLower();
                bool confirm = false;

                switch (confirmAsString)
                {
                    case "y":
                    case "yes":
                        confirm = true;
                        Console.Clear();
                        Console.WriteLine("The emails have been sent.");
                        break;
                    case "n":
                    case "no":
                    default: // Makes it default to false if y, yes, n, no is not entered
                        confirm = false;
                        Console.Clear();
                        Console.WriteLine("The emails have been cancelled.");
                        break;
                }
                Console.ReadLine();
                RunMenu();
            }
        }

        private string EnterNewLastName()
        {
            Console.WriteLine("Enter a new last name.");
            return Console.ReadLine();
        }

        private string EnterNewFirstName()
        {
            Console.WriteLine("Enter a new first name.");
            return Console.ReadLine();
        }

        private CustomerType EnterNewType()
        {
            Console.WriteLine("Select a new Customer Type.\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential\n");
            var typeResponse = int.Parse(Console.ReadLine());
            var type = _greetRepo.GetCustomersByType(typeResponse);
            return type;
        }

        private int EnterNewAge()
        {
            Console.WriteLine("Enter a new age.");
            return int.Parse(Console.ReadLine());
        }

        private string EnterNewEmail()
        {
            Console.WriteLine("Enter a new email.");
            return Console.ReadLine();
        }

        private int EnterNewID()
        {
            Console.WriteLine("Enter a new unique ID.");
            return int.Parse(Console.ReadLine());
        }

        private void SeedList()
        {
            Customer customerOne = new Customer("Aegon", "Targaryen", CustomerType.Current, 21, "KingofWesteros@gmail.com", 9999);
            Customer customerTwo = new Customer("Tyrion", "Lannister", CustomerType.Past, 33, "ImpinAintEasy@gmail.com", 1111);
            Customer customerThree = new Customer("Jamie", "Lannister", CustomerType.Current, 39, "HearMeRoar@gmail.com", 3333);
            Customer customerFour = new Customer("Arya", "Stark", CustomerType.Potential, 16, "AGirlHasNoName@gmail.com", 5555);

            _greetRepo.AddNewCustomer(customerOne);
            _greetRepo.AddNewCustomer(customerTwo);
            _greetRepo.AddNewCustomer(customerThree);
            _greetRepo.AddNewCustomer(customerFour);
        }
    }
}
