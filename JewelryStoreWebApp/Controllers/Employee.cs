using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreWebApp.Controllers
{
    public class Employee
    {
            public string userID { get; set; }
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public UserType UserType { get; set; }

            public double DiscountPercentage { get; set; }
    }
    public enum UserType
    {
        Normal,
        Privileged
    }
}
