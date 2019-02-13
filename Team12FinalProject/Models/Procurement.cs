using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum ProcurementType { Manual, Automatic }
namespace Team12FinalProject.Models
{
  public class Procurement
    {
        public Int32 ProcurementID { get; set; }

        [Required(ErrorMessage = "Please choose the Procurement Type")]
        [Display(Name = "Procurement Type")]
        public ProcurementType ProcurementType { get; set; }


        [Display(Name = "Procurement Date")]
        [DataType(DataType.Date)]
        public DateTime ProcurementDate { get; set; }

        [Required]
        public bool Completed { get; set; }

        [Display(Name = "Order Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ProcurementTotal
        {
            get { return ProcurementDetails.Sum(pd => pd.ExtendedPrice); }
        }



        public AppUser AppUser { get; set; }
        public List<ProcurementDetail> ProcurementDetails { get; set; }

        public Procurement()
        {
            if(ProcurementDetails==null)
            {
                ProcurementDetails = new List<ProcurementDetail>();
            }
        }
    }
}