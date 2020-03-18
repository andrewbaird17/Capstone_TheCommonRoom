﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCommonRoom_Capstone.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public List<Event> HouseEvents { get; set; }
    }
}