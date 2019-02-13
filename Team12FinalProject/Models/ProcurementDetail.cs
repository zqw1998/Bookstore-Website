using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team12FinalProject.Models
{
    public class ProcurementDetail
    {
        public Int32 ProcurementDetailID { get; set; }

        [Required(ErrorMessage = "You need to enter the number for book")]
        [Display(Name = "Quantity")]
        [Range(0, 1000, ErrorMessage = "Number of products must be between 0 and 1000")]
        public Int32 Quantity { get; set; } 

        [Required(ErrorMessage = "Please enter the price of the item at the time of reorder")]
        [Display(Name = "Reorder Price")]
        [Range(0.01, 1000, ErrorMessage = "Book price must be greater than zero")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal BookPrice { get; set; }

        [Required(ErrorMessage = "Please indicate the extended price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Extended Price")]
        public Decimal ExtendedPrice { get; set; }

        public Book Book { get; set; }
        public Procurement Procurement { get; set; }
    }
}
