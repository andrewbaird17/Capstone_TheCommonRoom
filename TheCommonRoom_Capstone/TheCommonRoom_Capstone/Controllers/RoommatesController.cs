using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheCommonRoom_Capstone.Data;
using TheCommonRoom_Capstone.Models;

namespace TheCommonRoom_Capstone.Controllers
{
    public class RoommatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoommatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Roommates
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var roomInDB = await _context.Roommates.Include("Household").Where(h => h.IdentityUserId == userId).FirstOrDefaultAsync();
            return View(roomInDB);
        }

        // GET: Roommates/Create
        public IActionResult Create()
        {
            Roommate newRoommate = new Roommate();
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Name");
            return View(newRoommate);
        }

        // POST: Roommates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Roommate roommate)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                roommate.IdentityUserId = userId;
                roommate.IsApproved = false;
                _context.Add(roommate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Name");
            return View(roommate);
        }

        // GET: Roommates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roommate = await _context.Roommates.FindAsync(id);
            if (roommate == null)
            {
                return NotFound();
            }
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Name", roommate.HouseholdId);
            return View(roommate);
        }

        // POST: Roommates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Roommate roommate)
        {
            if (id != roommate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    roommate.IdentityUserId = userId;
                    _context.Update(roommate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoommateExists(roommate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Id", roommate.HouseholdId);
            return View(roommate);
        }

        // GET: Roommates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roommate = await _context.Roommates
                .Include(r => r.Household)
                .Include(r => r.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roommate == null)
            {
                return NotFound();
            }

            return View(roommate);
        }

        // POST: Roommates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roommate = await _context.Roommates.FindAsync(id);
            _context.Roommates.Remove(roommate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoommateExists(int id)
        {
            return _context.Roommates.Any(e => e.Id == id);
        }

        //public IActionResult AddEvent()
        //{
        //    Event newEvent = new Event();
        //    return View(newEvent);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddEvent(Event eventNew)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        eventNew.IdentityUserId = userId;
        //        _context.Add(eventNew);
        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
