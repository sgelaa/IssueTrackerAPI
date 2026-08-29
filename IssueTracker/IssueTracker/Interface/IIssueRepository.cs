using IssueTracker.Entities;
using IssueTracker.Helpers;

namespace IssueTracker.Interface
{
    public interface IIssueRepository
    {
        void AddIssue(Issue issue);
        Task<Issue?> GetIssueAsync(string id);

        Task UpdateIssueAsync(Issue newIssue);
        Task DeleteIssueAsync(string id);

        Task<PaginatedResult<Issue>> GetAllIssuesAsync(int pageNumber, int pageSize);
        Task<IReadOnlyList<Issue>?> GetIssuesByPriorityAsync(int priorityId);
        Task<IReadOnlyList<Issue>?> GetIssuesStatusAsync(int statusId);

    }
}