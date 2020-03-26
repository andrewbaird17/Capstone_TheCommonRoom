using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCommonRoom_Capstone.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        [Display(Name ="Posted By")]
        public string PostedBy { get; set; }
        [Display(Name ="Share To Pay")]
        public double TotalAmount { get; set; }
        public double AmountToPayCents { get; set; }
        [ForeignKey("Household")]
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
    }
}
