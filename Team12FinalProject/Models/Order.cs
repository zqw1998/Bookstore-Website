using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team12FinalProject.Models
{
    public class Order
    {
        public Int32 OrderID { get; set; }

        [Required]
        [Display(Name = "Customer Number")]
        public Int32 OrderNumber { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Subtotal
        {
            get { return OrderDetails.Sum(rd => rd.TotalPrice); }
        }

        //[Display(Name = "Coupon Applied")]
        //public bool CouponApplied { get; set; }

        [Display(Name = "Discount:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal DiscountAmt { get; set; }
        /*{
            get
            {
                if (CouponApplied == true)
                {
                    return Coupon.Amount * Subtotal;
                }
                else
                {
                    return 0;
                }

            }
        }*/


        [Display(Name = "Shipping:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ShippingAmt { get; set; }
        /*{
            get{
               if (ShippingApplied == false)
                {
                    return Shipping.ShippingBase + Shipping.ShippingAddition * (OrderDetails.Sum(rd => rd.Quantity) - 1);
                }
                else
                {
                    lreturn 0;
                }

            }
        }*/


        [Display(Name = "Total:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TotalPrice
        {
            get { return Subtotal + ShippingAmt - DiscountAmt; }
        }

        [Display(Name = "Check Out Status")]
        public bool CheckOutStatus { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Cost
        {
            get { return OrderDetails.Sum(c => c.Book.AvgCost * c.Quantity) ; }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Revenue
        {
            get { return Subtotal - DiscountAmt; }
        }

        public Int32 Quantity
        {
            get { return OrderDetails.Sum(c => c.Quantity); }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderProfit
        {
            get { return Revenue-Cost; }
        }

        public List<OrderDetail> OrderDetails { get; set; }
        public Coupon Coupon { get; set; }
        public AppUser AppUser { get; set; }
        public CreditCard CreditCard { get; set; }
        //public Shipping Shipping { get; set; }

        public Order()
        {
            if(OrderDetails==null)
            {
                OrderDetails = new List<OrderDetail>();
            }
        }

    }
}