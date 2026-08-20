using IssueTracker.Entities;
using IssueTracker.Interface;

namespace IssueTracker.Data
{
    public class IssueService(IIssueRepository repository) : IIssueService
    {
        public void AddIssue(Issue issue)
        {
            repository.AddIssue(issue);
        }

        public async Task<IList<Issue>?> GetAllIssuesAsync()
        {
            return await repository.GetAllIssuesAsync();
        }

        public async Task<Issue?> GetIssueAsync(string id)
        {
            return await repository.GetIssueAsync(id);
        }

        public async Task<IList<Issue>?> GetIssuesByPriorityAsync(string priority)
        {
            return await repository.GetIssuesByPriorityAsync(priority);
        }

        public async Task<IList<Issue>?> GetIssuesStatusAsync(int statusId)
        {
            return await repository.GetIssuesStatusAsync(statusId);
        }

        public async Task<bool> RollbackStatus(string id)
        {
            return await repository.RollbackStatus(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await repository.SaveChangesAsync();
        }

        public async Task<bool> UpdateIssueAsync(string id)
        {
            return await repository.UpdateIssueAsync(id);
        }
    }
}
