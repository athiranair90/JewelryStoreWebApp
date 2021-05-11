using ModelLayer.EmployeeFromXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ModelLayer
{
    public static class SharedMethods
    {


        private static string CreatedOn;

        public static T DeserializeToObject<T>(string filePath) where T : class
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                T myDocument;
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    myDocument = (T)xmlSerializer.Deserialize(streamReader);
                }

                return myDocument;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public static T LoadDataModel<T>(string filePath) where T : class
        {
            T seririzedObj = null;
            Console.WriteLine("Inside" + CreatedOn);
            seririzedObj = DeserializeToObject<T>(filePath);

            //Console.WriteLine("Ouside" + CreatedOn);

            return seririzedObj;
        }

        public static Dictionary<string, Employees> GetCustomerDetails(Company users)
        {
            Dictionary<string, Employees> valuePairs = new Dictionary<string, Employees>();
            foreach (Employees employee in users.Employees)
            {
                valuePairs.Add(employee.userID, employee);
            }
            return valuePairs;
        }

    }
}
