﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCommonRoom_Capstone.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        public string Details { get; set; }
        public DateTime DatePosted { get; set; }
        [Display(Name ="Posted By")]
        public string PostedBy { get; set; }

        [ForeignKey("Household")]
        public int HouseholdId { get; set; }
        public Household Household { get; set; }
    }
}
