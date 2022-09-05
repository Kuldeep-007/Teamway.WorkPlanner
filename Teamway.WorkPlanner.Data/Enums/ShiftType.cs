using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamway.WorkPlanner.Data.Enums
{
    public enum ShiftType
    {
        [Description("08:00 - 16:00")]
        Morning,
        [Description("16:00 - 00:00")]
        Afternoon,
        [Description("00:00 - 08:00")]
        Night
    }
}
