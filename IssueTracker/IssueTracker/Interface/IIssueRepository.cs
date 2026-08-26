using IssueTracker.Entities;
using IssueTracker.Helpers;

namespace IssueTracker.Interface
{
    public interface IIssueRepository
    {
        void AddIssue(Issue issue);
        Task<Issue?> GetIssueAsync(string id);
        Task<bool> AdvanceStatusAsync(string id);
        Task<bool> RollbackStatusAsync(string id);

        Task<Issue> UpdateIssue(Issue newIssue);
        Task<bool> DeleteIssue(string id);

        Task<PaginatedResult<Issue>> GetAllIssuesAsync(int pageNumber, int pageSize);
        Task<IReadOnlyList<Issue>?> GetIssuesByPriorityAsync(int priorityId);
        Task<IReadOnlyList<Issue>?> GetIssuesStatusAsync(int statusId);


        Task<bool> SaveChangesAsync();

    }
}