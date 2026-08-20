using IssueTracker.Entities;

namespace IssueTracker.Interface
{
    public interface IIssueService
    {
        void AddIssue(Issue issue);
        Task<Issue?> GetIssueAsync(string id);
        Task<bool> UpdateIssueAsync(string id);
        Task<bool> RollbackStatus(string id);


        Task<IList<Issue>?> GetAllIssuesAsync();
        Task<IList<Issue>?> GetIssuesByPriorityAsync(string priority);
        Task<IList<Issue>?> GetIssuesStatusAsync(int statusId);


        Task<bool> SaveChangesAsync();
    }
}
