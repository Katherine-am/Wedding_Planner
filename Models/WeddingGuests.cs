using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace weddingPlanner.Models
{
    public class WeddingGuest
    {
        public int WeddingGuestID {get; set;}
        public int UserID {get; set;}
        public int WeddingID {get; set;}
        public Wedding Wedding {get; set;}
        public User User {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}