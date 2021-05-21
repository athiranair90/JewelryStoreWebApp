using JewelryStoreWebApp.Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace JewelryStoreWebApp.Controllers.BusinessLogic
{
    public class PrintTextFile : IPrint
    {
        public string Print(PrintViewModel model)
        {
            var filepath = Path.Combine(model.OuputFilePath + "OrderDetail.txt");
            using (TextWriter tw = new StreamWriter(filepath))
            {
                tw.WriteLine("Customer Name : {0}", model.CustomerName);
                tw.WriteLine("Customer Type : {0}", model.CustomerType.ToString());
                tw.WriteLine("Gold Price : {0}", model.GoldPrice);
                tw.WriteLine("Weight : {0}", model.Weight);
                tw.WriteLine("Discount Rate : {0}", model.DiscountRate);
                tw.WriteLine("Total Price : {0}", model.TotalPrice);
            }
            return null;
        }
    }
}
