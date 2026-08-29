using IssueTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class Seed
    {
        public static async Task Seedlookups(AppDbContext context)
        {
            string[] statuses = ["NEW", "OPEN", "IN-PROGRESS", "DONE", "CLOSED"];
            string[] priorities = ["LOW", "MEDIUM", "HIGH"];

            // foreach (var item in statuses)
            // if (!await context.Priorities.AnyAsync())
            // {

            //     for (int i = 0; i < statuses.Length; i++)
            //     {
            //         var status = new Status
            //         {
            //             Name = statuses[i],
            //             StatusId = i,
            //         };

            //         // look into add range approach
            //         context.Statuses.Add(status);
            //     }
            // }

            // if (!await context.Priorities.AnyAsync())
            // {

            //     for (int j = 0; j < priorities.Length; j++)
            //     {
            //         var priority = new Priority
            //         {
            //             Name = priorities[j],
            //             PriorityId = j,
            //         };

            //         context.Priorities.Add(priority);
            //     }
            // }

            // save all changes.
            await context.SaveChangesAsync();

        }
    }
}