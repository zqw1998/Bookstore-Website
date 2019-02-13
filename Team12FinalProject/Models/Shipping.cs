using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Team12FinalProject.Models
{
    public class Shipping
    {
        public Int32 ShippingID { get; set; }

        [Range(0, 1000, ErrorMessage = "Shipping Base can only be from 0 to 1000")]
        [Display(Name = "Shipping Base:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ShippingBase { get; set; } = 3.5m;

        [Range(0, 1000, ErrorMessage = "Shipping Addition can only be from 0 to 1000")]
        [Display(Name = "Shipping Addition:")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ShippingAddition { get; set; } = 1.5m;

        //public List<Order> Orders { get; set; }

        /*public Shipping()
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }
        }*/
    }
}
