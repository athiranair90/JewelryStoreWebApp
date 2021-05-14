using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreWebApp.Controllers.BusinessLogic
{
    public class PrintMode : IPrintModeFactory
    {

        public IPrint PrintModeSelector(PrintTypes printType)
        {
            if (printType == PrintTypes.TextFile)
            {
               return new PrintTextFile();
            }
            else if (printType == PrintTypes.PrintToFile)
            {
               return new PrintToPaper();
            }
            return null;
        }
    }
}
