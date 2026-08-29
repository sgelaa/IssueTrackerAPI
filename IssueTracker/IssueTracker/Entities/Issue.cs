using System.Text.Json.Serialization;
using IssueTracker.Helpers.Enum;

namespace IssueTracker.Entities
{
    public class Issue
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public  string?  Title { get; set; }
        public string? Description { get; set; }

        // LOW - MEDIUM - HIGH
        public  int PriorityId { get; set; } = 0;

        // NEW - OPEN - IN-PROGRESS - DONE - CLOSED
        public  int StatusId { get; set; } = 0;

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public string StatusName => Enum.GetName(typeof(Statuses), StatusId) ?? "UNKNOWN";
        public string PriorityName => Enum.GetName(typeof(Priorities), PriorityId) ?? "UNKNOWN";

        // [JsonIgnore]
        // public Status Status { get; set; } = null!;
        // // [JsonIgnore]
        // public Priority Priority { get; set; } = null!;
    }
}
