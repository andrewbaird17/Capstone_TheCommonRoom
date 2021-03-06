﻿using System;
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
    public class AnnouncementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Announcements
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
            var annoucements = _context.Announcements.Where(a => a.HouseholdId == householdId);

            return View(await annoucements.ToListAsync());
        }

        // GET: Announcements/Details/5
        public ActionResult Details(int id)
        {
            var announcement = _context.Announcements.Where(a => a.Id == id).FirstOrDefault();
            return View(announcement);
        }

        // GET: Announcements/Create
        public ActionResult Create()
        {
            Announcement announcement = new Announcement();
            return View(announcement);
        }

        // POST: Announcements/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Announcement announcement)
        {
            var todayDate = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (User.IsInRole("Roommate"))
                {
                    var userLoggedIn = await _context.Roommates.Where(r => r.IdentityUserId == userId).FirstOrDefaultAsync();
                    announcement.HouseholdId = userLoggedIn.HouseholdId;
                }
                else
                {
                    var userLoggedIn = await _context.HouseholdAdministrators.Where(r => r.IdentityUserId == userId).FirstOrDefaultAsync();
                    announcement.HouseholdId = userLoggedIn.HouseholdId;
                }
                announcement.PostedBy = userId;
                announcement.DatePosted = todayDate;
                _context.Add(announcement);
                await _context.SaveChangesAsync();
                return RedirectToAction("TextRoommatesAnnouncement", "Twilio");
            }
            return RedirectToAction("Index");
        }

        // Add Update of Announcements if 'PostedBy' equals that of the userId of user logged in 
        // GET: Announcements/Edit/5
        public ActionResult Edit(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var announcement = _context.Announcements.Where(a => a.Id == id).FirstOrDefault();
            // only allow member that posted announcement, edit the announcement
            if (announcement.PostedBy == userId)
            {
                return View(announcement);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Announcements/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Announcement announcement)
        {
            var todayDate = DateTime.Now.Date;
            announcement.DatePosted = todayDate;
            _context.Update(announcement);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}