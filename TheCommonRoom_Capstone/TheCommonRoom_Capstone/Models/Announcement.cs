﻿using System;
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
        public string PostedBy { get; set; }

        [ForeignKey("Board")]
        public int BoardId { get; set; }
        public Board Board { get; set; }
    }
}
