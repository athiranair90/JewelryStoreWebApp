using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace ModelLayer.EmployeeFromXML
{
    [Serializable]
    [XmlRoot(ElementName = "Company", DataType = "string", IsNullable = true)]
    public class Company
    {
        [XmlElement("Employee")]
        public List<Employees> Employees { get; set; }

        public Company()
        {
            Employees = new List<Employees>();
        }

    }

    public class Employees
    {
        [XmlElement("userID")]
        public string userID { get; set; }

        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("UserType")]
        public UserType UserType { get; set; }


        [XmlElement("DiscountPercentage")]
        public int DiscountPercentage { get; set; }
    }
}
