using IssueTracker.Entities;

namespace IssueTracker.Data
{
    public class Seed
    {
        public static async Task Seedlookups(AppDbContext context)
        {
            string[] statuses = ["NEW", "OPEN", "IN-PROGRESS", "DONE", "CLOSED"];
            string[] priorities = ["LOW", "MEDIUM", "HIGH"];

            // foreach (var item in statuses)
            for (int i = 0; i < statuses.Length; i++)
            {
                var status = new Status
                {
                    Name = statuses[i],
                    StatusId = i,
                };

                context.Statuses.Add(status);
            }

            for (int j = 0; j < priorities.Length; j++)
            {

                var priority = new Priority
                {
                    Name = priorities[j],
                    PriorityId = j,
                };

                context.Priorities.Add(priority);
            }

            // save all changes.
            await context.SaveChangesAsync();

        }
    }
}