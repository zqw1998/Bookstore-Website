using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team12FinalProject.Models
{
    public class Book
    {

        [Display(Name = "Book ID")]
        public Int32 BookID { get; set; }

        [Display(Name = "Unique Number")]
        public Int32 UniqueID { get; set; }

        //[Required(ErrorMessage = "Please enter the author name")]
        [Display(Name = "Author")]
        public string Author { get; set; }

        //[Required(ErrorMessage = "Please enter the book title")]
        [Display(Name = "Book Title")]
        public string Title { get; set; }

        [Display(Name = "Stock")]
        [Range(0, 1000, ErrorMessage = "Number of products must be between 1 and 1000")]
        public Int32 CopiesOnHand { get; set; }

        [Required(ErrorMessage = "Please the book price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Book Price")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter the publication date")]
        [Display(Name = "Publication Date")]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [Required(ErrorMessage = "Please enter the cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Cost of Good")]
        public Decimal Cost { get; set; }

        [Display(Name = "Description")]
        public String Description { get; set; }


        [Display(Name = "Average Customer Rating")]
        public Double AvgRating
        {
            get
            {
                if (!Reviews.Where(r => r.Approve == Approve.Yes).Any())
                {
                    return 0;
                }
                else
                {
                    return Reviews.Where(r => r.Approve == Approve.Yes).Average(c => c.CustomerRating);
                }

            }
        }


        [Display(Name = "Availablity")]
        public string Availablity
        {
            get
            {
                if (CopiesOnHand > 0)
                {
                    return "In stock";
                }
                else
                {
                    return "Out of stock";
                }
            }
        }

        [Required(ErrorMessage = "Please enter the reorder point")]
        [Display(Name = "Reorder Point")]
        public Int32 Reorder { get; set; }

        [Display(Name = "Inventory")]
        public Int32 Inventory { get { return CopiesOnHand + QuantityOnOrder; } }

        [Display(Name = "Copies On Order")]
        public Int32 QuantityOnOrder { get; set; } = 0;

        [Display(Name = "Last Order Date")]
        [DataType(DataType.Date)]
        public DateTime? LastOrdered { get; set; }

        [Display(Name = "Discontinued")]
        public bool Discontinued { get; set; } = false;

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Cost of Goods Sold")]
        public Decimal COGS { get { return InitialCost * InitialCopies + ProcurementDetails.Sum(c => c.BookPrice * c.Quantity); } }

        [Display(Name = "Inventory History")]
        public Int32 TotalInventoryEver { get { return InitialCopies + ProcurementDetails.Sum(c => c.Quantity); } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Average Cost")]
        public Decimal AvgCost
        {
            get
            {
                if (TotalInventoryEver == 0)
                {
                    return COGS;
                }
                else
                {
                    return COGS / TotalInventoryEver;
                }
            }
        }

        public Decimal TotalRevenue { get { return OrderDetails.Sum(c => c.PriceWithDiscount); } }

        public Decimal TotalCost { get { return AvgCost * OrderDetails.Sum(c => c.Quantity); } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal AvgProfit
        {
            get
            {
                if (OrderDetails.Sum(c => c.Quantity) == 0)
                {
                    return TotalRevenue - TotalCost;
                }
                return (TotalRevenue - TotalCost) / OrderDetails.Sum(c => c.Quantity);
            }
        }


        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Profit { get { return TotalRevenue - TotalCost; } }

        public Decimal InitialCost { get; set; }
        public Int32 InitialCopies { get; set; }


        public List<Review> Reviews { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ProcurementDetail> ProcurementDetails { get; set; }
        public Genre Genre { get; set; }

        public Book()
        {
            if (Reviews == null)
            {
                Reviews = new List<Review>();
            }
            if (OrderDetails == null)
            {
                OrderDetails = new List<OrderDetail>();
            }
            if (ProcurementDetails == null)
            {
                ProcurementDetails = new List<ProcurementDetail>();
            }
        }
    }
}

