using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge_Repository
{
    public class GreetRepository
    {
        private List<Customer> _listOfCustomers = new List<Customer>();

        public void AddNewCustomer(Customer customer)
        {
            _listOfCustomers.Add(customer);
        }

        public List<Customer> SeeAllCustomers()
        {
            return _listOfCustomers;
        }

        public Customer GetCustomerByID(int id)
        {
            Customer customer = new Customer();

            foreach(Customer c in _listOfCustomers)
            {
                if (c.ID == id)
                {
                    return c;
                }
            }
            return null;
        }

        public CustomerType GetCustomersByType(int typeChoice)
        {
            CustomerType type = new CustomerType();
            switch (typeChoice)
            {
                case 1:
                    type = CustomerType.Current;
                    break;
                case 2:
                    type = CustomerType.Past;
                    break;
                case 3:
                    type = CustomerType.Potential;
                    break;
            }
            return type;
        }

        public void RemoveCustomerFromList(Customer customer)
        {
            _listOfCustomers.Remove(customer);
        }   
    }
}
