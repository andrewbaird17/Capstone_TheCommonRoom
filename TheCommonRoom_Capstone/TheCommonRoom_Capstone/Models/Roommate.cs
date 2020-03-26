using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCommonRoom_Capstone.Models
{
    public class Roommate
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Approved?")]
        public bool IsApproved { get; set; }
        [Display(Name = "Chore Assigned")]
        public string ChoreAssigned { get; set; }
        [Display(Name = "Chore Completed")]
        public bool ChoreCompleted { get; set; }
        [Display(Name = "Favorite Color")]
        public string Color { get; set; }

        [ForeignKey("Household")]
        public int HouseholdId { get; set; }
        public Household Household { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
