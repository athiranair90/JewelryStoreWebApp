using JewelryStoreWebApp.Controllers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreWebApp.Controllers.BusinessLogic
{
    public interface IPrint
    {
        string Print(PrintViewModel model);
    }
}
