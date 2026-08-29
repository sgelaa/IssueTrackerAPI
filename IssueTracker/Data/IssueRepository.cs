using IssueTracker.Entities;
using IssueTracker.Helpers;
using IssueTracker.Interface;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class IssueRepository(AppDbContext context) : IIssueRepository
    {
        public void AddIssue(Issue issue) => context.Add(issue);

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

        public async Task<IReadOnlyList<Issue>?> GetIssuesStatusAsync(int statusId)
        {
            return await context.Issues
                .Where(x => x.StatusId == statusId)
                .ToListAsync();
        }

        public async Task UpdateIssueAsync(Issue newIssue) => context.Issues.Update(newIssue);

        public async Task DeleteIssueAsync(string id)
        {
            var stub = new Issue { Id = id };
            context.Issues.Remove(stub);
        }
    }
}
