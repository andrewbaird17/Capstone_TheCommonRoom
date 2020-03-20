using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCommonRoom_Capstone.Models
{
    public class Household
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public List<Event> HouseEvents { get; set; }
        [NotMapped]
        public List<Announcement> HouseAnnouncements { get; set; }
        [NotMapped]
        public List<Bill> HouseBills { get; set; }
        [NotMapped]
        public List<Chore> HouseChores { get; set; }
        [NotMapped]
        public List<Poll> HousePolls { get; set; }
    }
}
