using IssueTracker.Interface;

namespace IssueTracker.Data
{
    public class UnitOfWork(AppDbContext context, IIssueRepository issues) : IUnitOfWork
    {
        public IIssueRepository Issues { get; } = issues;

        public bool HasChanges()
        {
            return context.ChangeTracker.HasChanges();
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
