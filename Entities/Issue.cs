using System.Text.Json.Serialization;
using IssueTracker.Helpers.Enum;

namespace IssueTracker.Entities
{
    public class Issue
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string  Title { get; set; }
        public required string Description { get; set; }

        // LOW - MEDIUM - HIGH
        public required int PriorityId { get; set; }

        // NEW - OPEN - IN-PROGRESS - DONE - CLOSED
        public required int StatusId { get; set; }

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
