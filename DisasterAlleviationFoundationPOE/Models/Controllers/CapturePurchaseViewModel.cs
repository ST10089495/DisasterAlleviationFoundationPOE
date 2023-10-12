using DisasterAlleviationFoundationPOE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundationPOE
{
    public class CapturePurchaseViewModel
    {
        [Display(Name = "Select Disaster")]
        [Required(ErrorMessage = "Please select a disaster.")]
        public int DisasterId { get; set; }

        [Display(Name = "Select Good")]
        [Required(ErrorMessage = "Please select a type of good.")]
        public int GoodId { get; set; }

        [Display(Name = "Quantity to Purchase")]
        [Required(ErrorMessage = "Please enter the quantity.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int PurchaseQuantity { get; set; }

        [Display(Name = "Available Money")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal AvailableMoney { get; set; }

        // Additional properties for dropdown lists
        public List<Disaster> ActiveDisasters { get; set; }
        public List<Goods> AvailableGoods { get; set; }

        // Additional properties for error handling
        public string ErrorMessage { get; set; }
    }
}