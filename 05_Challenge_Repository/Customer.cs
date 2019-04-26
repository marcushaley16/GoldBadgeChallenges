using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge_Repository
{
    public enum CustomerType
    {
        Current = 1,
        Past,
        Potential
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int ID { get; set; }

        public Customer () { }

        public Customer (string firstName, string lastName, CustomerType type, int age, string email, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
            Age = age;
            Email = email;
            ID = id;
        }
    }
}
