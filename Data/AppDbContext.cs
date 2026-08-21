using IssueTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }


        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Status>()
        //         .HasAlternateKey(s => s.StatusId);
            
        //     modelBuilder.Entity<Issue>()
        //         .HasOne(i => i.Status)
        //         .WithMany()
        //         .HasForeignKey(i => i.StatusId)
        //         .HasPrincipalKey(s => s.StatusId);

        //     modelBuilder.Entity<Priority>()
        //         .HasAlternateKey(p => p.PriorityId);
                
        //     modelBuilder.Entity<Issue>()
        //         .HasOne(i => i.Priority)
        //         .WithMany()
        //         .HasForeignKey(i => i.PriorityId)
        //         .HasPrincipalKey(p => p.PriorityId);

        // }
    }
}