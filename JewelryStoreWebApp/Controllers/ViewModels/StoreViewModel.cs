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
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Gold Price")]
        public string GoldPrice { get; set; }

        [Required]
        [Display(Name = "Weight")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string Weight { get; set; }

        [Display(Name = "Total Price")]
        public string TotalPrice { get; set; }

        [Display(Name = "Discount Rate")]
        public string DiscountRate { get; set; }

        public UserType CustomerType { get; set; }

        [Display(Name = "Customer Type")]
        public string userType { get; set; }
    }
}
