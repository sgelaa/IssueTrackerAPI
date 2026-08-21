using IssueTracker.Entities;

namespace IssueTracker.Interface
{
    public interface IIssueRepository
    {
        void AddIssue(Issue issue);
        Task<Issue?> GetIssueAsync(string id);
        Task<bool> UpdateIssueAsync(string id);
        Task<bool> RollbackStatus(string id);


        Task<IList<Issue>?> GetAllIssuesAsync();
        Task<IList<Issue>?> GetIssuesByPriorityAsync(int priorityId);
        Task<IList<Issue>?> GetIssuesStatusAsync(int statusId);


        Task<bool> SaveChangesAsync();

    }
}