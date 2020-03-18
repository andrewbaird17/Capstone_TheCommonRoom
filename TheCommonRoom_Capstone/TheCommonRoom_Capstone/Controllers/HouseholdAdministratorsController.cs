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
    public class HouseholdAdministratorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HouseholdAdministratorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HouseholdAdministrators
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var hhaInDB = _context.HouseholdAdministrators.Where(h => h.IdentityUserId == userId).FirstOrDefault();
            var roomatesInHousehold = _context.Roommates.Where(r => r.HouseholdId == hhaInDB.HouseholdId);
            return View(await roomatesInHousehold.ToListAsync());
        }

        // GET: HouseholdAdministrators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var householdAdministrator = await _context.HouseholdAdministrators
                .Include(h => h.Household)
                .Include(h => h.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (householdAdministrator == null)
            {
                return NotFound();
            }

            return View(householdAdministrator);
        }

        // GET: HouseholdAdministrators/Create
        public IActionResult Create()
        {
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Id");
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: HouseholdAdministrators/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,HouseholdId,IdentityUserId")] HouseholdAdministrator householdAdministrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(householdAdministrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Id", householdAdministrator.HouseholdId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", householdAdministrator.IdentityUserId);
            return View(householdAdministrator);
        }

        // GET: HouseholdAdministrators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var householdAdministrator = await _context.HouseholdAdministrators.FindAsync(id);
            if (householdAdministrator == null)
            {
                return NotFound();
            }
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Id", householdAdministrator.HouseholdId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", householdAdministrator.IdentityUserId);
            return View(householdAdministrator);
        }

        // POST: HouseholdAdministrators/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,HouseholdId,IdentityUserId")] HouseholdAdministrator householdAdministrator)
        {
            if (id != householdAdministrator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(householdAdministrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseholdAdministratorExists(householdAdministrator.Id))
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
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Id", householdAdministrator.HouseholdId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", householdAdministrator.IdentityUserId);
            return View(householdAdministrator);
        }

        // GET: HouseholdAdministrators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var householdAdministrator = await _context.HouseholdAdministrators
                .Include(h => h.Household)
                .Include(h => h.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (householdAdministrator == null)
            {
                return NotFound();
            }

            return View(householdAdministrator);
        }

        // POST: HouseholdAdministrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var householdAdministrator = await _context.HouseholdAdministrators.FindAsync(id);
            _context.HouseholdAdministrators.Remove(householdAdministrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseholdAdministratorExists(int id)
        {
            return _context.HouseholdAdministrators.Any(e => e.Id == id);
        }
    }
}
