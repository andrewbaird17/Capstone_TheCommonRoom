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
            return RedirectToAction("TextHHA");
        }
        public IActionResult TextHHA()
        {
            var hha = GetHHA();
            var message = MessageResource.Create(
            body: "There's a new notification pending in your household on TheCommonRoom. " +
            "Log in to your Account to see it!",
            from: new Twilio.Types.PhoneNumber("+18312221547"),
            to: new Twilio.Types.PhoneNumber($"+1{hha.PhoneNumber}")
            );
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
            return RedirectToAction("TextHHA");
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
            return RedirectToAction("EmailRoommates");
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
            return RedirectToAction("TextHHA");
        }
        public async Task<IActionResult> EmailRoommates()
        {
            var roommates = GetRoommates();
            foreach (var roommate in roommates)
            {
                var user = _context.Users.Where(u => u.Id == roommate.IdentityUserId).FirstOrDefault();

                var apiKey = My_API_Key.SendGridAPI;
                var client = new SendGridClient(apiKey);
                // change 'from' to a different email address if needed in future
                var from = new EmailAddress("CommonRoom@gmail.com", "Common Room Team");
                var subject = "New Notification on TheCommonRoom";
                var to = new EmailAddress(user.Email, $"{roommate.FirstName} {roommate.LastName}");
                var plainTextContent = "You have a new notification to view in your Common Room account. " +
                    "Please log in to to view!";
                var htmlContent = "<strong>You have a new notification to view in your Common Room account. " +
                    "Please log in to to view!</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
            return RedirectToAction("EmailHHA");
        }
        public async Task<IActionResult> EmailHHA()
        {
            var hha = GetHHA();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.Where(u => u.Id == hha.IdentityUserId).FirstOrDefault();
            if (user.Id != userId)
            {
                var apiKey = My_API_Key.SendGridAPI;
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("CommonRoom@gmail.com", "Common Room Team");
                var subject = "New Notification on TheCommonRoom";
                var to = new EmailAddress(user.Email, $"{hha.FirstName} {hha.LastName}");
                var plainTextContent = "You have a new notification to view in your TheCommonRoom account. " +
                    "Please log in to to view!";
                var htmlContent = "<strong>You have a new notification to view in your TheCommonRoom account. " +
                    "Please log in to to view!</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
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
        public HouseholdAdministrator GetHHA()
        {
            HouseholdAdministrator hha = new HouseholdAdministrator();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Roommate"))
            {
                var userLoggedIn = _context.Roommates.Where(r => r.IdentityUserId == userId).FirstOrDefault();
                hha = _context.HouseholdAdministrators.Where(r => r.HouseholdId == userLoggedIn.HouseholdId).FirstOrDefault();
            }
            else
            {
                var userLoggedIn = _context.HouseholdAdministrators.Where(r => r.IdentityUserId == userId).FirstOrDefault();
                hha = _context.HouseholdAdministrators.Where(r => r.HouseholdId == userLoggedIn.HouseholdId).FirstOrDefault();
            }
            return hha;
        }
    }
}