using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace weddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingID {get; set;}
        [Required]
        [MinLength(2)]
        public string WedderOne {get; set;}
        [Required]
        [MinLength(2)]
        public string WedderTwo {get; set;}
        [Required]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}")]
        public string Date {get; set;}
        [Required]
        [MinLength(5)]
        public string Address {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public int UserID {get; set;}
        public User Creator {get; set;}
        public List<WeddingGuest> WeddingGuest {get; set;}
    }
}