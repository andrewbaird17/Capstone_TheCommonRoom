﻿using System;
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
        [Display(Name ="Option One")]
        public string OptionOne { get; set; }
        [Display(Name = "Option Two")]
        public string OptionTwo { get; set; }
        [Display(Name = "Votes for Option One")]
        public int VotesForOptionOne { get; set; }
        [Display(Name = "Votes for Option Two")]
        public int VotesForOptionTwo { get; set; }
        public bool CastVoteOptionOne { get; set; }
        public bool CastVoteOptionTwo { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("Household")]
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
    }
}
