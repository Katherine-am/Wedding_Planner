using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace weddingPlanner.Models
{
    public class User
    {
        [Key]
        public int UserID {get; set;}
        [Required]
        [MinLength(2)]
        public string FirstName {get; set;}
        [Required]
        [MinLength(2)]
        public string LastName {get; set;}
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters")]
        public string Password {get; set;}
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        public List<WeddingGuest> Guests {get; set;} 
        public List<Wedding> CreatedWeddings {get; set;}
    }

    public class UserLogin
    {
        [Required]
        [EmailAddress]
        [NotMapped]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Password {get; set;}
    }
}