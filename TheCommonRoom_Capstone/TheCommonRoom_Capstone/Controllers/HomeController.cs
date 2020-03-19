using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheCommonRoom_Capstone.Data;
using TheCommonRoom_Capstone.Models;

namespace TheCommonRoom_Capstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Household Administrator"))
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var hhaInfo = _context.HouseholdAdministrators.Where(c => c.IdentityUserId == userId).FirstOrDefault();
                if (hhaInfo == null)
                {
                    return RedirectToAction("Create", "Administrators");
                }
                else
                {
                    return RedirectToAction("Index", "Administrators");
                }
            }
            else if (User.IsInRole("Roommate"))
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var roommateInfo = _context.Roommates.Where(c => c.IdentityUserId == userId).FirstOrDefault();
                if (roommateInfo == null)
                {
                    return RedirectToAction("Create", "Administrators");
                }
                else
                {
                    return RedirectToAction("Index", "Administrators");
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
