using IssueTracker.Entities;
using IssueTracker.Helpers;
using IssueTracker.Interface;

namespace IssueTracker.Data
{
    public class IssueService(IIssueRepository repository) : IIssueService
    {
        public void AddIssue(Issue issue)
        {
            repository.AddIssue(issue);
        }

        public async Task<PaginatedResult<Issue>?> GetAllIssuesAsync(int pageNumber, int pageSize)
        {
            return await repository.GetAllIssuesAsync(pageNumber, pageSize);
        }

        public async Task<Issue?> GetIssueAsync(string id)
        {
            return await repository.GetIssueAsync(id);
        }

        public async Task<IList<Issue>?> GetIssuesByPriorityAsync(int priorityId)
        {
            return await repository.GetIssuesByPriorityAsync(priorityId);
        }

        public async Task<IList<Issue>?> GetIssuesStatusAsync(int statusId)
        {
            return await repository.GetIssuesStatusAsync(statusId);
        }

        public async Task<bool> RollbackStatusAsync(string id)
        {
            return await repository.RollbackStatusAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await repository.SaveChangesAsync();
        }

        public async Task<bool> AdvanceStatusAsync(string id)
        {
            return await repository.AdvanceStatusAsync(id);
        }
    }
}
