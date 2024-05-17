using InterviewProject.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InterviewProject.Data.Data
{
    public class InterviewProjectDb : IdentityDbContext
    {
        public InterviewProjectDb(DbContextOptions option) : base(option)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Contact> Contact { get; set; }
    }
}
