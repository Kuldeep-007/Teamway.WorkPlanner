using System;
using System.Collections.Generic;

namespace Teamway.WorkPlanner.Data.Migrations
{
    public partial class WorkerShift
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public DateTime Date { get; set; }
        public int ShiftType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
