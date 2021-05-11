using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.EmployeeFromXML
{
    public interface ICustomerProvider
    {
        public IEnumerable<Employees> GetAllCustomers();
        //public Company GetCustomerDetails();
        public Employees GetACustomer(string userID);

    }
}
