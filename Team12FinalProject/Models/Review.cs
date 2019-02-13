using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum Approve { No, Yes,Pending }
namespace Team12FinalProject.Models
{
    public class Review
    {
        public Int32 ReviewID { get; set; }

        [Required(ErrorMessage ="Please enter your review")]
        [Display(Name = "Reviews")]
        [StringLength(100)]
        public String Reviews { get; set; }

        [Range(1, 5, ErrorMessage = "Reviews can only be from 1-5")]
        [Required(ErrorMessage ="Please enter your rating")]
        [Display(Name = "Customer Rating")]
        public Int32 CustomerRating { get; set; }

        [Display(Name = "Approve?")]
        public Approve Approve { get; set; }

        [Display(Name ="Approved Date")]
        [DataType(DataType.Date)]
        public DateTime ApproveDate { get; set; }

        public AppUser Author { get; set; }
        public AppUser Approver { get; set; }

        public AppUser AppUser { get; set; }
        public Book Book { get; set; }
    }
}