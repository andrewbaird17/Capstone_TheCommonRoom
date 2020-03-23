using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCommonRoom_Capstone.Data;
using TheCommonRoom_Capstone.Models;

namespace TheCommonRoom_Capstone.Controllers
{
    public class BillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BillsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Bills
        public async Task<IActionResult> Index()
        {
            int householdId;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.IsInRole("Roommate"))
            {
                householdId = _context.Roommates.FirstOrDefault(r => r.IdentityUserId == userId).HouseholdId;
            }
            else
            {
                householdId = _context.HouseholdAdministrators.FirstOrDefault(r => r.IdentityUserId == userId).HouseholdId;
            }
            var bills = _context.Bills.Where(b => b.HouseholdId == householdId);

            return View(await bills.ToListAsync());
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var billChosen = await _context.Bills.FirstOrDefaultAsync(b => b.Id == id);
            return View(billChosen);
        }

        // GET: Bills/Create
        public ActionResult Create()
        {
            Bill bill = new Bill();
            return View(bill);
        }

        // POST: Bills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bill bill)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (User.IsInRole("Roommate"))
                {
                    var userLoggedIn = await _context.Roommates.Where(r => r.IdentityUserId == userId).FirstOrDefaultAsync();
                    bill.HouseholdId = userLoggedIn.HouseholdId;
                    bill.PostedBy = userLoggedIn.FirstName;
                }
                else
                {
                    var userLoggedIn = await _context.HouseholdAdministrators.Where(r => r.IdentityUserId == userId).FirstOrDefaultAsync();
                    bill.HouseholdId = userLoggedIn.HouseholdId;
                    bill.PostedBy = userLoggedIn.FirstName;
                }
                _context.Add(bill);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Pay()
        {
            return View();
        }

        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            return View();
        }
        //// GET: Bills/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Bills/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}