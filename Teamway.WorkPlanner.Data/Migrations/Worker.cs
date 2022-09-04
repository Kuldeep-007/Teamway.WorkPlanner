using System;
using System.Collections.Generic;

namespace Teamway.WorkPlanner.Data.Migrations
{
    public partial class Worker
    {
        public Worker()
        {
            Credentials = new HashSet<Credential>();
        }

        public int Id { get; set; }
        public string IdentityId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string OfficialMail { get; set; } = null!;
        public string PersonalMail { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Credential> Credentials { get; set; }
    }
}
