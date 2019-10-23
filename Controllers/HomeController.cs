using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using weddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace weddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        
       [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u=>u.Email==newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    dbContext.Add(newUser);
                    dbContext.SaveChanges();
                    HttpContext.Session.SetInt32("UserID", newUser.UserID);
                    return RedirectToAction("Dashboard");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLogin userSubmission)
        {
            if(ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u=>u.Email==userSubmission.Email);
                if(userInDb==null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }
                var hasher = new PasswordHasher<UserLogin>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                {
                    HttpContext.Session.SetInt32("UserID", userInDb.UserID);
                    return RedirectToAction("Dashboard");
                }
            }
            else 
            {
                return View("Index");
            }
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("UserID")==null)
            {
                return View("Index");
            }
            else
            {
                WrapperModel ViewModel = new WrapperModel();
                ViewModel.newUser = dbContext.Users.FirstOrDefault(u=>u.UserID==HttpContext.Session.GetInt32("UserID"));
                ViewModel.allWeddings = dbContext.Weddings
                    .Include(u=>u.Creator)
                    .Include(u=>u.WeddingGuest)
                    .OrderByDescending(t=>t.CreatedAt).ToList();
                int count = 0;
                foreach(Wedding wedding in ViewModel.allWeddings){
                    count += wedding.WeddingGuest.Count;
                }
                ViewModel.guestCount = count;
                return View("Dashboard", ViewModel);
            }
        }

        [HttpPost("RSVP/{weddingID}")]
        public IActionResult nowRSVP(int WeddingID)
        {
            if(HttpContext.Session.GetInt32("UserID")==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                WrapperModel ViewModel = new WrapperModel();
                ViewModel.newUser = dbContext.Users.FirstOrDefault(u=>u.UserID==HttpContext.Session.GetInt32("UserID"));
                Wedding joinWedding = dbContext.Weddings
                    .Include(l=>l.WeddingGuest)
                    .ThenInclude(l=>l.User)
                    .SingleOrDefault(d=>d.WeddingID==WeddingID);
                WeddingGuest WantingToAttend = dbContext.WeddingGuests.FirstOrDefault(d=>d.UserID==ViewModel.newUser.UserID && d.WeddingID==WeddingID);
                if(WantingToAttend == null)
                {
                    WeddingGuest guest = new WeddingGuest
                    {
                        UserID = ViewModel.newUser.UserID,
                        WeddingID = joinWedding.WeddingID
                    };
                    dbContext.Add(guest);
                    dbContext.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    dbContext.Remove(WantingToAttend);
                    dbContext.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
            }
        }

        [HttpGet("NewWedding")]
        public IActionResult newWedding()
        {
            if(HttpContext.Session.GetInt32("UserID")==null)
            {
                return View("Index");
            }
            else
            {
                WrapperModel ViewModel = new WrapperModel();
                ViewModel.newUser = dbContext.Users.FirstOrDefault(u=>u.UserID==HttpContext.Session.GetInt32("UserID"));
                
                return View("NewWedding");
            }
        }

        [HttpPost("createWedding")]
        public IActionResult createWedding(WrapperModel Wedding)
        {
            if(HttpContext.Session.GetInt32("UserID")==null)
            {
                return View("Index");
            }
            Wedding.newWedding.UserID = (int)HttpContext.Session.GetInt32("UserID");
            if(ModelState.IsValid)
            {
                Wedding.newWedding.UserID = (int)HttpContext.Session.GetInt32("UserID");
                dbContext.Add(Wedding.newWedding);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                WrapperModel ViewModel = new WrapperModel();
                ViewModel.newUser = dbContext.Users.FirstOrDefault(u=>u.UserID==HttpContext.Session.GetInt32("UserID"));
                
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet("{weddingID}")]
        public IActionResult ViewWedding(int weddingID)
        {
            if(HttpContext.Session.GetInt32("UserID")==null)
            {
                return View("Index");
            }
            else
            {
                WrapperModel ViewModel = new WrapperModel();
                ViewModel.newWedding = dbContext.Weddings
                    .Include(u=>u.WeddingGuest)
                    .ThenInclude(u=>u.User)
                    .FirstOrDefault(w=>w.WeddingID==weddingID);
                return View("ViewWedding", ViewModel);
            }
        }

        [HttpGet("DeleteWedding/{WeddingID}")]
        public IActionResult DeleteWedding(int WeddingID)
        {
            if(HttpContext.Session.GetInt32("UserID")==null)
            {
                return View("Index");
            }
            else
            {
                WrapperModel ViewModel = new WrapperModel();
                ViewModel.newUser = dbContext.Users.FirstOrDefault(u=>u.UserID==HttpContext.Session.GetInt32("UserID"));
                Wedding deleteWedding = dbContext.Weddings.SingleOrDefault(d=>d.WeddingID==WeddingID);
                dbContext.Weddings.Remove(deleteWedding);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard", ViewModel);
            }
        }

        [HttpGet("SignOut")]
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
