using IssueTracker.Interface;

namespace IssueTracker.Data
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public IIssueRepository Issues { get; } = new IssueRepository(context);

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
