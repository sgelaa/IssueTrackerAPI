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

        // [JsonIgnore]
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        

    }
}