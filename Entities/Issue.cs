using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Entities
{
    public class Issue
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string  Title { get; set; }
        public required string Description { get; set; }
        public required string Priority { get; set; }

        public required string Type { get; set; }    
        public required string Status { get; set; }

        public DateTime Created { get; set; }

    }
}