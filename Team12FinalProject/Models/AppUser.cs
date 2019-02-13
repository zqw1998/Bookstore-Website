using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Team12FinalProject.Models
{
    public class AppUser : IdentityUser
    {


        [Display(Name = "Customer Number")]
        public Int32 CustomerNumber { get; set; }

        [Display(Name = "Disabled")]
        public Boolean Disabled { get; set; }

        [Required(ErrorMessage = "Please enter the first name")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the last name")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Middle Initial")]
        public String Initial { get; set; }

        // [Required(ErrorMessage = "Please enter the birthday")]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "Please enter the street name")]
        [Display(Name = "Street")]
        public String Street { get; set; }

        [Required(ErrorMessage = "Please enter the city name")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "Please enter the state")]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Please enter the zip code")]
        [Display(Name = "Zip Code")]
        public Int32 ZipCode { get; set; }

        [Display(Name = "SSN")]
        public String SSN { get; set; }


        [InverseProperty("Author")]
        public List<Review> ReviewWritten { get; set; }

        [InverseProperty("Approver")]
        public List<Review> ReviewApproved { get; set; }

        public List<CreditCard> CreditCards { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Order> Orders { get; set; }
        public List<Procurement> Procurements { get; set; }

        public Int32 myReviews { get; set; }
        public Int32 myApprovedReviews { get; set; } = 0;
        public Int32 myRejectedReviews { get; set; } = 0;

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Cost
        {
            get { return Orders.Sum(c => c.Cost); }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Revenue
        {
            get { return Orders.Sum(c => c.Revenue); }
        }

        public Int32 TotalQuantity
        {
            get { return Orders.Sum(c => c.Quantity); }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal CustomerProfit
        {
            get { return Revenue-Cost; }
        }


        public AppUser()
        {
            if (CreditCards == null)
            {
                CreditCards = new List<CreditCard>();
            }

            if (Reviews == null)
            {
                Reviews = new List<Review>();
            }
            if (Orders == null)
            {
                Orders = new List<Order>();
            }
            if (Procurements == null)
            {
                Procurements = new List<Procurement>();
            }
            if (ReviewApproved == null)
            {
                ReviewApproved = new List<Review>();
            }
            if (ReviewWritten == null)
            {
                ReviewWritten = new List<Review>();
            }
        }
    }
}
