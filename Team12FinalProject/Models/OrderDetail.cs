using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team12FinalProject.Models
{
    public class OrderDetail
    {
        public Int32 OrderDetailID { get; set; }

        [Required(ErrorMessage = "You need to enter the number for book")]
        [Display(Name = "Quantity")]
        [Range(1, 1000, ErrorMessage = "Number of products must be between 1 and 1000")]
        public Int32 Quantity { get; set; }

        [Required(ErrorMessage = "Please enter the price of the item at the time of order")]
        [Display(Name = "Product Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal BookPrice { get; set; }

        [Required(ErrorMessage = "Please enter the quantity* product price at the time of the order")]
        [Display(Name = "Total Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TotalPrice { get { return BookPrice * Quantity; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal PriceWithDiscount
        {
            get
            {
                if (Order.Coupon != null && Order.Coupon.CouponType == CouponType.discount)
                {
                    return Order.Coupon.Amount / 100 * TotalPrice;
                }
                else
                {
                    return TotalPrice;
                }
            }
        }

        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}

