using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreWebApp.Controllers.ViewModels
{
    public class PrintViewModel : StoreViewModel
    {
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        public string OuputFilePath { get; set; }

    }
}
