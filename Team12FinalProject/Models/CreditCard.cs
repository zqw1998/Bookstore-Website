using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Team12FinalProject.Models
{
    public enum CardType { Visa, AmericanExpress, Discover, MasterCard }
    public class CreditCard
    {
        public Int32 CreditCardID { get; set; }

        [Required(ErrorMessage = "Card holder is required.")]
        [Display(Name = "Card Holder")]
        public String CardHolder { get; set; }

        [Required(ErrorMessage = "Please enter the credit card number")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Please enter a valid credit card number")]
        [Display(Name = "Credit Card Number")]
        public String CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Please select a card Type")]
        [Display(Name = "Card Type")]
        public CardType CardType { get; set; }

        public String CardNumberShort
        {
            get
            {
                if (CreditCardNumber == null)
                {
                    String x = "Not long enough";
                    return x;
                }
                if (CreditCardNumber.Length <= 4)
                {
                    String x = "Not long enough";
                    return x;
                }
                else
                {
                    String x = "XXXX-XXXX-XXXX-";
                    x += CreditCardNumber.Substring(CreditCardNumber.Length - 4);
                    return x;
                }
            }
        }

        public virtual List<Order> Orders { get; set; }
        public virtual AppUser AppUser { get; set; }

        public CreditCard()
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }
        }

        public CreditCard(String CardNum)
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }

            CreditCardNumber = CardNum;
        }

    }
}