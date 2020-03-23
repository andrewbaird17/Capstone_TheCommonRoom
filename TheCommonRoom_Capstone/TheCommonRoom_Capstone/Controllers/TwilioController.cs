using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
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
                body: "There's a new Announcement posted to your household on TheCommonRoom. " +
                "Log in to your Account to see it!",
                from: new Twilio.Types.PhoneNumber("+18312221547"),
                to: new Twilio.Types.PhoneNumber($"+1{roommate.PhoneNumber}")
                );
            };
            return RedirectToAction("EmailRoommates");
        }
        public IActionResult TextRoommatesBill()
        {
            var roommates = GetRoommates();
            foreach (var roommate in roommates)
            {
                var message = MessageResource.Create(
                body: "There's a new Bill posted to your household on TheCommonRoom. " +
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
                body: "There's new Chores Assigned to your household on TheCommonRoom. " +
                "Log in to your Account to see it!",
                from: new Twilio.Types.PhoneNumber("+18312221547"),
                to: new Twilio.Types.PhoneNumber($"+1{roommate.PhoneNumber}")
                );
            };
            return RedirectToAction("Index", "Home");
        }
        public IActionResult TextRoommatesPoll()
        {
            var roommates = GetRoommates();
            foreach (var roommate in roommates)
            {
                var message = MessageResource.Create(
                body: "There's a new Poll posted to your household on TheCommonRoom. " +
                "Log in to your Account to see it!",
                from: new Twilio.Types.PhoneNumber("+18312221547"),
                to: new Twilio.Types.PhoneNumber($"+1{roommate.PhoneNumber}")
                );
            };
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> EmailRoommates()
        {
            var apiKey = My_API_Key.SendGridAPI;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("baird.andrew4@gmail.com", "Example User");
            var subject = "Sending with Twilio SendGrid is Fun";
            var to = new EmailAddress("baird.andrew007@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
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