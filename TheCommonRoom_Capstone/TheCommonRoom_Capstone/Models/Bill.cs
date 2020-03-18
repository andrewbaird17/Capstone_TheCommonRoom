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
        public string PostedBy { get; set; }
        public double TotalAmount { get; set; }
        [ForeignKey("Board")]
        public int BoardId { get; set; }
        public Board Board { get; set; }
    }
}
