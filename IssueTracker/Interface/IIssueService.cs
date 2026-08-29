using IssueTracker.Entities;
using IssueTracker.Helpers;

namespace IssueTracker.Interface
{
    public interface IIssueService
    {
        void AddIssue(Issue issue);
        Task<Issue?> GetIssueAsync(string id);

        Task<PaginatedResult<Issue>?> GetAllIssuesAsync(int pageNumber, int pageSize);
        Task<IReadOnlyList<Issue>?> GetIssuesByPriorityAsync(int priorityId);
        Task<IReadOnlyList  <Issue>?> GetIssuesStatusAsync(int statusId);


        Task<bool> SaveChangesAsync();
    }
}
