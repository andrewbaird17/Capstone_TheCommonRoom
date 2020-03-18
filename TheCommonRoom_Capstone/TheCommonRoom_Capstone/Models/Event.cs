using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCommonRoom_Capstone.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        [Display(Name = "All day event?")]
        public bool IsFullDay { get; set; }
        public string Location { get; set; }
        [ForeignKey("HouseholdAdministrator")]
        public int? HouseholdAdminId { get; set; }
        public HouseholdAdministrator HouseholdAdministrator { get; set; }
        [ForeignKey("Roommate")]
        public int? RoommateId { get; set; }
        public Roommate Roomate { get; set; }
    }
}
