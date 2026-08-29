using IssueTracker.Entities;
using IssueTracker.Entities.DTO;
using IssueTracker.Helpers;
using IssueTracker.Helpers.Enum;
using IssueTracker.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    public class IssuesController(IIssueService service) : BaseApiController
    {

        [HttpGet("all")]
        public async Task<ActionResult<PaginatedResult<Issue>>> GetAllIssues([FromQuery] int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await service.GetAllIssuesAsync(pageNumber, pageSize));
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddIssue(IssueDto issueDto)
        {
            if (issueDto == null) return BadRequest("dto cannot be null");
            if (issueDto.PriorityId < (int)Priorities.Low && issueDto.PriorityId > (int)Priorities.High) return BadRequest("given priority is out of range");

            var issue = new Issue
            {
                Description = issueDto.Description,
                PriorityId = issueDto.PriorityId,
                StatusId = (int)Statuses.New,
                Title = issueDto.Title,

                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
            };

            service.AddIssue(issue);
            await service.SaveChangesAsync();

            return Created();
        }


        // [HttpPut("advance/{id}")]
        // public async Task<ActionResult> AdvanceStatus(string id)
        // {
        //     var issue = await service.GetIssueAsync(id);
        //     var success = false;
        //     if (issue != null)
        //     {
        //         if(issue.StatusId == (int)Statuses.Closed) return BadRequest("selected issue already closed");
        //         success = await service.AdvanceStatusAsync(id);
        //         await service.SaveChangesAsync();
        //     }

        //     return Ok(success);
        // }

        // [HttpPut("rollback/{id}")]
        // public async Task<ActionResult> RollbackStatus(string id)
        // {
        //     var issue = await service.GetIssueAsync(id);
        //     var success = false;
        //     if (issue != null)
        //     {
        //         if(issue.StatusId == (int)Statuses.Open) return BadRequest("selected issue already in open state");
        //         success = await service.RollbackStatusAsync(id);
        //         await service.SaveChangesAsync();
        //     }

        //     return Ok(success);
        // }

        [HttpGet("all/status/{status}")]
        public async Task<ActionResult> GetIssuesByStatus(int status)
        {
            if (status < (int)Statuses.New && status > (int)Statuses.Closed) return BadRequest("given status is out of range");
            var result = await service.GetIssuesStatusAsync(status);

            return Ok(result);
        }

        [HttpGet("all/priority/{priority}")]
        public async Task<ActionResult> GetIssuesByPriority(int priority)
        {
            if (priority < (int)Priorities.Low && priority > (int)Priorities.High) return BadRequest("given priority is out of range");
            var result = await service.GetIssuesByPriorityAsync(priority);

            return Ok(result);
        }
    }
}