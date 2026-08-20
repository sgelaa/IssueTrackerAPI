using IssueTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class AppDbContext (DbContextOptions options) : DbContext(options)
    {
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
    }
}