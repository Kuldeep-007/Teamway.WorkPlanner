using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamway.WorkPlanner.Data;
using Teamway.WorkPlanner.Data.Enums;
using Teamway.WorkPlanner.Data.Interfaces;
using Teamway.WorkPlanner.Data.Models;

namespace Teamway.WorkPlanner.Data.Repositories.Classes
{
    public class AdminRepository : DbContextBase, IAdminRepository
    {
        public AdminRepository() : base() { }

        public Task<IEnumerable<WorkerShift>> GetWorkerShiftsById(int workerId, ShiftFilterType shiftFilterType)
        {
            throw new NotImplementedException();
        }

        public Task<WorkerShift> UpsertShiftForWorkerById(int workerId, WorkerShift workerShift)
        {
            throw new NotImplementedException();
        }
    }
}
