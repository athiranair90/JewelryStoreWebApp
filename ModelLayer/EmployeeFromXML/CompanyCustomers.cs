using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Configuration;
using System.Reflection;

namespace ModelLayer.EmployeeFromXML
{
    public class CompanyCustomers : ICustomerProvider
    {
        private static Company Customers;
        private static string XMLFilePath= Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Resources\Customers.xml";
        private static Dictionary<string, Employees> CustomerDetails = new Dictionary<string, Employees>();
        public CompanyCustomers()
        {
            //CreatedOn = DateTime.Now.ToString();
            Customers = SharedMethods.LoadDataModel<Company>(XMLFilePath);
            CustomerDetails = SharedMethods.GetCustomerDetails(Customers);
        }

        public IEnumerable<Employees> GetAllCustomers()
        {
            return Customers.Employees;
        }

        public Employees GetACustomer(string userID)
        {
            if (CustomerDetails.ContainsKey(userID))
            {
                return CustomerDetails[userID];
            }
            return null;
        }

        //public void LoadDataModel(string filePath)
        //{
        //    if (CustomerDetails.Count == 0)
        //    {

        //        Console.WriteLine("Inside" + CreatedOn);
        //        Customers = SharedMethods.DeserializeToObject<Company>(filePath);
        //        CustomerDetails = SharedMethods.GetCustomerDetails(Customers);
        //    }

        //    Console.WriteLine("Ouside"+CreatedOn);
        //}

        
    }
}
