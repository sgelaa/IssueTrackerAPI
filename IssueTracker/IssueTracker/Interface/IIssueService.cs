using IssueTracker.Entities;
using IssueTracker.Helpers;

namespace IssueTracker.Interface
{
    public interface IIssueService
    {
        void AddIssue(Issue issue);
        Task<Issue?> GetIssueAsync(string id);
        Task<bool> AdvanceStatusAsync(string id);
        Task<bool> RollbackStatusAsync(string id);


        Task<PaginatedResult<Issue>?> GetAllIssuesAsync(int pageNumber, int pageSize);
        Task<IList<Issue>?> GetIssuesByPriorityAsync(int priorityId);
        Task<IList<Issue>?> GetIssuesStatusAsync(int statusId);


        Task<bool> SaveChangesAsync();
    }
}
