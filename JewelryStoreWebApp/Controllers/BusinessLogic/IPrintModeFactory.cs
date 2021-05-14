using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreWebApp.Controllers.BusinessLogic
{
    interface IPrintModeFactory
    {
        IPrint PrintModeSelector(PrintTypes printType);
    }
}
