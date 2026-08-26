using IssueTracker.Entities;
using IssueTracker.Helpers;
using IssueTracker.Helpers.Enum;
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

        public async Task<PaginatedResult<Issue>> GetAllIssuesAsync(int pageNumber, int pageSize)
        {
            var query = context.Issues
                .OrderByDescending(z => z.Created)
                .AsQueryable();

            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Issue?> GetIssueAsync(string id)
        {
            return await context.Issues.FindAsync(id);
        }

        public async Task<IReadOnlyList<Issue>?> GetIssuesByPriorityAsync(int priorityId)
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
                if (issue.StatusId >= (int)Statuses.New)
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
                if (issue.StatusId < (int)Statuses.Closed)
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

        public async Task<IReadOnlyList<Issue>?> GetIssuesStatusAsync(int statusId)
        {
            return await context.Issues
                .Where(x => x.StatusId == statusId)
                .ToListAsync();
        }

        public Task<Issue> UpdateIssue(Issue newIssue)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIssue(string id)
        {
            throw new NotImplementedException();
        }
    }
}