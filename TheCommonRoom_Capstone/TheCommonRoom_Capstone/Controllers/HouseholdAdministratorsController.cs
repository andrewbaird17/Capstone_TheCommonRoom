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
        public async Task<IActionResult> Details()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var householdAdministrator = await _context.HouseholdAdministrators.Include("Household").FirstOrDefaultAsync(m => m.IdentityUserId == userId);
            if (householdAdministrator == null)
            {
                return NotFound();
            }

            return View(householdAdministrator);
        }

        // GET: HouseholdAdministrators/Create
        public IActionResult Create()
        {
            HouseholdAdministrator newAdmin = new HouseholdAdministrator();
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Name");
            return View(newAdmin);
        }

        // POST: HouseholdAdministrators/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HouseholdAdministrator householdAdministrator)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                householdAdministrator.IdentityUserId = userId;
                _context.Add(householdAdministrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Name");
            return View(householdAdministrator);
        }

        // GET: HouseholdAdministrators/Edit/5
        public async Task<IActionResult> Edit()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var householdAdministrator = await _context.HouseholdAdministrators.FirstOrDefaultAsync(h=> h.IdentityUserId == userId);
            if (householdAdministrator == null)
            {
                return NotFound();
            }
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Name");
            return View(householdAdministrator);
        }

        // POST: HouseholdAdministrators/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HouseholdAdministrator householdAdministrator)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    householdAdministrator.IdentityUserId = userId;
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
            ViewData["HouseholdId"] = new SelectList(_context.Households, "Id", "Name", householdAdministrator.HouseholdId);          
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
    
        public async Task<IActionResult> ApproveRoommate(int id)
        {
            var roommateInDB = await _context.Roommates.FirstOrDefaultAsync(r => r.Id == id);
            if (roommateInDB.IsApproved == false)
            {
                roommateInDB.IsApproved = true;
                _context.Update(roommateInDB);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UnapproveRoommate(int id)
        {
            var roommateInDB = await _context.Roommates.FirstOrDefaultAsync(r => r.Id == id);
            if (roommateInDB.IsApproved == true)
            {
                roommateInDB.IsApproved = false;
                _context.Update(roommateInDB);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
