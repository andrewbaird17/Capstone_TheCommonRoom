using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCommonRoom_Capstone.Models
{
    public class Poll
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string OptionOne { get; set; }
        public string OptionTwo { get; set; }
        public int VotesForOptionOne { get; set; }
        public int VotesForOptionTwo { get; set; }
        public DateTime DateCreated { get; set; }
        public double TotalAmount { get; set; }
        [ForeignKey("Household")]
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
    }
}
