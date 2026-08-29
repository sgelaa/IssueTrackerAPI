namespace IssueTracker.Interface
{
    // wrapper - abstraction
    public interface IUnitOfWork
    {
        IIssueRepository Issues { get; }
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
        bool HasChanges();
    }
}
