using IssueTracker.Entities;
using IssueTracker.Helpers;
using IssueTracker.Interface;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class IssueRepository(AppDbContext context) : IIssueRepository
    {
        public void AddIssue(Issue issue)
        {
            context.Add(issue);
        }

        public async Task<IList<Issue>?> GetAllIssuesAsync()
        {
            return await context.Issues
                // .Include(x => x.Status)
                // .Include(x => x.Priority)
                .ToListAsync();
        }

        public async Task<Issue?> GetIssueAsync(string id)
        {
            return await context.Issues.FindAsync(id);
        }

        public async Task<IList<Issue>?> GetIssuesByPriorityAsync(int priorityId)
        {
            return await context.Issues
                .Where(x => x.PriorityId == priorityId)
                .ToListAsync();
        }


        public async Task<bool> RollbackStatusAsync(string id)
        {
            var issue = await context.Issues.FindAsync(id);

            if (issue != null)
            {
                if (issue.StatusId >= Statuses.NEW)
                {
                    issue.StatusId--;
                    issue.Modified = DateTime.UtcNow;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> AdvanceStatusAsync(string id)
        {
            var issue = await context.Issues.FindAsync(id);

            if (issue != null)
            {
                if (issue.StatusId <= Statuses.CLOSED)
                {
                    issue.StatusId++;
                    issue.Modified = DateTime.UtcNow;
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IList<Issue>?> GetIssuesStatusAsync(int statusId)
        {
            return await context.Issues
                .Where(x => x.StatusId == statusId)
                .ToListAsync();
        }
    }
}