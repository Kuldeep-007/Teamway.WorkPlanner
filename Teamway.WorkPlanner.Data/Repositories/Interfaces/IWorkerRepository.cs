using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamway.WorkPlanner.Data.Enums;
using Teamway.WorkPlanner.Data.Models;

namespace Teamway.WorkPlanner.Data.Interfaces
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<WorkerShift>> GetWorkerShiftsById(int workerId, ShiftFilterType shiftFilterType);
    }
}
