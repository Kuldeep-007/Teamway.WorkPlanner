using System;
using System.Collections.Generic;

namespace Teamway.WorkPlanner.Data.Migrations
{
    public partial class Credential
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int AccessLevel { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual Worker Worker { get; set; } = null!;
    }
}
