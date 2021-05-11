using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace JewelryStoreAPIs.Authentication
{
    [XmlRoot("UserSecrets")]
    public class UserSecrets
    {
        [XmlElement("Employee")]
        public List<EmployeeSecrets> employees;

    }

    public class EmployeeSecrets
    {
        [XmlElement("userID")]
        public string UserID { get; set; }

        [XmlElement("Password")]
        public string Password { get; set; }
    }
}
