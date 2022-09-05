using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamway.WorkPlanner.Data.Enums;

namespace Teamway.WorkPlanner.Data.Models
{
    public class WorkerShift
    {
        public DateTime Date { get; set; }
        public string Day { get; set; }
        public List<Shift> Shifts { get; set; }
    }

    public class Shift
    {
        public string ShiftType { get; set; }
        public string ShiftHours { get; set; }
        public bool IsShift { get; set; }
    }
}
