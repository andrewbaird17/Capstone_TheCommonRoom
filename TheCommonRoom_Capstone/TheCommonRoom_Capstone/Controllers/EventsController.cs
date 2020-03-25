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
            return View(events);
        }
        public async Task<IActionResult> UserIndex()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userEvents = await _context.Events.Where(e => e.IdentityUserId == userId).ToListAsync();
            return View(userEvents);
        }
        public IActionResult Calendar()
        {
            return View();
        }

        public JsonResult GetEvents()
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
            var roommates =  _context.Roommates.Where(e => e.HouseholdId == householdId).ToList();
            var hha = _context.HouseholdAdministrators.FirstOrDefault(a => a.HouseholdId == householdId);
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
            return new JsonResult(events);
        }
        // GET: Events/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.APIKey = My_API_Key.GoogleKey;
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
        public async Task<IActionResult> Edit(int id)
        {
            var eventFound = await _context.Events.Where(e => e.Id == id).FirstOrDefaultAsync();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            // only allow member that made that event, edit that event
            if (eventFound.IdentityUserId == userId)
            {
                return View(eventFound);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event eventUpdate)
        {
            var eventInDB = await _context.Events.Where(e => e.Id == id).FirstOrDefaultAsync();

            eventInDB.Title = eventUpdate.Title;
            eventInDB.Description = eventUpdate.Description;
            eventInDB.Start = eventUpdate.Start;
            eventInDB.End = eventUpdate.End;
            eventInDB.AllDay = eventUpdate.AllDay;
            eventInDB.Location = eventUpdate.Location;

            _context.Update(eventInDB);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}