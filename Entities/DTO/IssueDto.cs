namespace IssueTracker.Entities.DTO
{
    public class IssueDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int PriorityId { get; set; }
        public required int StatusId { get; set; }
    }
}