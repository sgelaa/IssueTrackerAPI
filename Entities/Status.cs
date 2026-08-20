namespace IssueTracker.Entities
{
    public class Status
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int StatusId { get; set; }   
        public required string Name { get; set; }
    }
}