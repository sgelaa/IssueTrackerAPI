namespace IssueTracker.Entities
{
    public class Priority
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int PriorityId { get; set; }
        public required string Name { get; set; }
    }
}