using IssueTracker.Entities;
using IssueTracker.Entities.DTO;
using IssueTracker.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    public class IssuesController(IIssueService service) : BaseApiController
    {

        [HttpGet("all")]
        public async Task<ActionResult> GetAllIssues()
        {
            return Ok(await service.GetAllIssuesAsync());
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddIssue(IssueDto issueDto)
        {
            if (issueDto == null) return BadRequest("dto cannot be null");
            var issue = new Issue
            {
                Description = issueDto.Description,
                PriorityId = issueDto.PriorityId,
                StatusId = issueDto.StatusId,
                Title = issueDto.Title,

                Created = DateTime.UtcNow,
            };

            service.AddIssue(issue);
            await service.SaveChangesAsync();

            return Created();
        }
    }
}