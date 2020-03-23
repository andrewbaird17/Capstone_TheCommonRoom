using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheCommonRoom_Capstone.Data;
using TheCommonRoom_Capstone.Models;
using Twilio.Rest.Api.V2010.Account;

namespace TheCommonRoom_Capstone.Controllers
{
    public class TwilioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TwilioController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult TextRoommatesAnnouncement()
        {
            var roommates = GetRoommates();
            foreach (var roommate in roommates)
            {
                var message = MessageResource.Create(
                body: "There's a new Announcement posted on TheCommonRoom. " +
                "Log in to your Account to see it!",
                from: new Twilio.Types.PhoneNumber("+18312221547"),
                to: new Twilio.Types.PhoneNumber($"+1{roommate.PhoneNumber}")
                );
            };
            return RedirectToAction("Index","Home");
        }
        public IActionResult TextRoommatesBill()
        {
            var roommates = GetRoommates();
            foreach (var roommate in roommates)
            {
                var message = MessageResource.Create(
                body: "There's a new Bill posted on TheCommonRoom. " +
                "Log in to your Account to see it!",
                from: new Twilio.Types.PhoneNumber("+18312221547"),
                to: new Twilio.Types.PhoneNumber($"+1{roommate.PhoneNumber}")
                );
            };
            return RedirectToAction("Index", "Home");
        }
        public IActionResult TextRoommatesChore()
        {
            var roommates = GetRoommates();
            foreach (var roommate in roommates)
            {
                var message = MessageResource.Create(
                body: "There's new Chores Assigned on TheCommonRoom." +
                "Log in to your Account to see it!",
                from: new Twilio.Types.PhoneNumber("+18312221547"),
                to: new Twilio.Types.PhoneNumber($"+1{roommate.PhoneNumber}")
                );
            };
            return RedirectToAction("Index", "Home");
        }
        public List<Roommate> GetRoommates()
        {
            List<Roommate> roommatesInHH = new List<Roommate>();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Roommate"))
            {
                var userLoggedIn = _context.Roommates.Where(r => r.IdentityUserId == userId).FirstOrDefault();
                roommatesInHH = _context.Roommates.Where(r => r.HouseholdId == userLoggedIn.HouseholdId).ToList();
            }
            else
            {
                var userLoggedIn = _context.HouseholdAdministrators.Where(r => r.IdentityUserId == userId).FirstOrDefault();
                roommatesInHH = _context.Roommates.Where(r => r.HouseholdId == userLoggedIn.HouseholdId).ToList();
            }
            return roommatesInHH;
        }
    }
}