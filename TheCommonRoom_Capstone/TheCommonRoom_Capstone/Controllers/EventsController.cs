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
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Events
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
            var household = await _context.Households.Where(h => h.Id == householdId).FirstOrDefaultAsync();
            var roommates = await _context.Roommates.Where(e => e.HouseholdId == householdId).ToListAsync();
            var hha = await _context.HouseholdAdministrators.FirstOrDefaultAsync(a => a.HouseholdId == householdId);
            List<Event> events = new List<Event>();
            foreach (var roommate in roommates)
            {
                var eventsRoom = _context.Events.Where(e => e.IdentityUserId == roommate.IdentityUserId).ToList();
                foreach (var item in eventsRoom)
                {
                    events.Add(item);
                }
            }
            var eventshha = _context.Events.Where(e => e.IdentityUserId == hha.IdentityUserId).ToList();
            foreach (var item in eventshha)
            {
                events.Add(item);
            }

            // pass household when ready to pass list of events
            return View(events);
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var eventFound = await _context.Events.Where(e => e.Id == id).FirstOrDefaultAsync();
            return View(eventFound);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            Event newEvent = new Event();
            return View(newEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event eventNew)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                eventNew.IdentityUserId = userId;
                _context.Add(eventNew);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}