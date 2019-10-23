using System.Collections.Generic;
using weddingPlanner.Models;

namespace weddingPlanner.Models
{
    public class WrapperModel
    {
        public User newUser {get; set;}
        public Wedding newWedding {get; set;}
        public List<Wedding> allWeddings {get; set;}
        public List<WeddingGuest> Guests {get; set;}
        public WeddingGuest Guest {get; set;}
        public int guestCount {get; set;}
    }
}