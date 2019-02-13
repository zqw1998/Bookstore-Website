using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team12FinalProject.Models
{
    public enum CouponType { shipping, discount }
    public class Coupon
    {
        public Int32 CouponID { get; set; }

        [Required(ErrorMessage = "Please enter a Coupon Code")]
        [Display(Name = "Coupon Code")]
        [StringLength(20, ErrorMessage = "The coupon code should be a 1-20 digit combinations of letters and numbers.", MinimumLength = 1)]
        public String CouponCode { get; set; }

        [Required]
        [Display(Name = "Is this an enabled Coupon Code?")]
        public Boolean Enabled { get; set; }

        [Required(ErrorMessage = "Coupon Type is required.")]
        [Display(Name = "Coupon Type")]
        public CouponType CouponType { get; set; }

        [Display(Name = "Minimum Total / Discount Percentage")]
        public Decimal Amount { get; set; }

        public List<Order> Orders { get; set; }

        public Coupon()
        {
            if(Orders == null)
            {
                Orders = new List<Order>();
            }
        }
    }

}
