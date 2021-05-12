using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStoreWebApp.Controllers.ViewModels
{
    public class StoreViewModel
    {
        [Required]
        public string GoldPrice { get; set; }

        [Required]
        public string Weight { get; set; }

        public string TotalPrice { get; set; }
        public string DiscountRate { get; set; }
        public string userType { get; set; }
    }
}
