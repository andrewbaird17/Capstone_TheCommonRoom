using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheCommonRoom_Capstone.Models;

namespace TheCommonRoom_Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Household> Households { get; set; }
        public DbSet<HouseholdAdministrator> HouseholdAdministrators { get; set; }
        public DbSet<Roommate> Roommates { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Chore> Chores { get; set; }
        public DbSet<Poll> Polls { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {
                    Name = "Household Administrator",
                    NormalizedName = "HOUSEHOLD ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "Roommate",
                    NormalizedName = "ROOMMATE"
                }
            );
        }
    }
}
