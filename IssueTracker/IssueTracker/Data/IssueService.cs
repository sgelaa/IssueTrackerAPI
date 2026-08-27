using IssueTracker.Entities;
using IssueTracker.Helpers;
using IssueTracker.Interface;

namespace IssueTracker.Data
{
    public class IssueService(IUnitOfWork uow) : IIssueService
    {
        public void AddIssue(Issue issue)
        {
            uow.Issues.AddIssue(issue);
        }

        public async Task<PaginatedResult<Issue>?> GetAllIssuesAsync(int pageNumber, int pageSize)
        {
            return await uow.Issues.GetAllIssuesAsync(pageNumber, pageSize);
        }

        public async Task<Issue?> GetIssueAsync(string id)
        {
            return await uow.Issues.GetIssueAsync(id);
        }

        public async Task<IReadOnlyList<Issue>?> GetIssuesByPriorityAsync(int priorityId)
        {
            return await uow.Issues.GetIssuesByPriorityAsync(priorityId);
        }

        public async Task<IReadOnlyList<Issue>?> GetIssuesStatusAsync(int statusId)
        {
            return await uow.Issues.GetIssuesStatusAsync(statusId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await uow.SaveChangesAsync();
        }
    }
}
