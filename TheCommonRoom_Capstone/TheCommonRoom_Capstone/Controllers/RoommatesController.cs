using System;
using System.Collections.Generic;
using System.Linq;
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
            var applicationDbContext = _context.Roommates.Include(r => r.Household).Include(r => r.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Roommates/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Roommates/Create
        public IActionResult Create()
        {
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Id");
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Roommates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,IsApproved,HouseholdId,IdentityUserId")] Roommate roommate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roommate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Id", roommate.HouseholdId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", roommate.IdentityUserId);
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
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Id", roommate.HouseholdId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", roommate.IdentityUserId);
            return View(roommate);
        }

        // POST: Roommates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,IsApproved,HouseholdId,IdentityUserId")] Roommate roommate)
        {
            if (id != roommate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", roommate.IdentityUserId);
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
    }
}
