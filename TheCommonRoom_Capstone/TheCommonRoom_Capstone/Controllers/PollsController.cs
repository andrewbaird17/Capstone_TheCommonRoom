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
    public class PollsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PollsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Polls
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
            var polls = _context.Polls.Where(p => p.HouseholdId == householdId);

            return View(await polls.ToListAsync());
        }

        // GET: Polls/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var pollChosen = await _context.Polls.FirstOrDefaultAsync(p => p.Id == id);
            return View(pollChosen);
        }

        // GET: Polls/Create
        public ActionResult Create()
        {
            Poll poll = new Poll();
            return View(poll);
        }

        // POST: Polls/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Poll poll)
        {
            var todayDate = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (User.IsInRole("Roommate"))
                {
                    var userLoggedIn = await _context.Roommates.Where(r => r.IdentityUserId == userId).FirstOrDefaultAsync();
                    poll.HouseholdId = userLoggedIn.HouseholdId;
                }
                else
                {
                    var userLoggedIn = await _context.HouseholdAdministrators.Where(r => r.IdentityUserId == userId).FirstOrDefaultAsync();
                    poll.HouseholdId = userLoggedIn.HouseholdId;
                }
                poll.DateCreated = todayDate;
                _context.Add(poll);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // GET: Polls/Edit/5
        public async Task<IActionResult> Vote(int id)
        {
            var pollChosen = await _context.Polls.FirstOrDefaultAsync(p => p.Id == id);
            return View(pollChosen);
        }

        // POST: Polls/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Vote(int id, Poll poll)
        {
            var pollVoted = await _context.Polls.FirstOrDefaultAsync(p => p.Id == poll.Id);
            if (ModelState.IsValid)
            {
                if(poll.CastVoteOptionOne == true)
                {
                    pollVoted.VotesForOptionOne += 1;
                }
                else if (poll.CastVoteOptionTwo == true)
                {
                    pollVoted.VotesForOptionTwo += 1;
                }
                _context.Update(pollVoted);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}