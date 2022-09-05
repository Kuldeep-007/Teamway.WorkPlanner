using EnumsNET;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamway.WorkPlanner.Data.Enums;
using Teamway.WorkPlanner.Data.Interfaces;
using Teamway.WorkPlanner.Data.Models;

namespace Teamway.WorkPlanner.Data.Repositories.Classes
{
    public class WorkerRepository : DbContextBase, IWorkerRepository
    {
        public WorkerRepository() : base() 
        {
        }

        public Task<IEnumerable<WorkerShift>> GetWorkerShiftsById(int workerId, ShiftFilterType shiftFilterType)
        {
            try
            {
                var recordsTillDate = DateTime.Now;
                switch (shiftFilterType)
                {
                    case ShiftFilterType.Week:
                        recordsTillDate = recordsTillDate.AddDays(DayOfWeek.Friday - recordsTillDate.DayOfWeek).Date;
                        break;
                    case ShiftFilterType.Month:
                        recordsTillDate = recordsTillDate.AddMonths(1).AddDays(-1);
                        break;
                    default:
                        recordsTillDate = DateTime.Now;
                        break;
                }

                List<WorkerShift> workerShifts = new List<WorkerShift>();
                var worker = _dbContext.Workers.Include(x=>x.WorkerShifts.Where(x=>x.Date <= recordsTillDate)).FirstOrDefault(x => x.Id == workerId);

                if (worker == null)
                {
                    throw new Exception($"No such worker exists with Id: {workerId}");
                }

                foreach(var shift in worker.WorkerShifts)
                {
                    workerShifts.Add(new WorkerShift()
                    {
                        Date = shift.Date,
                        Day = shift.Date.DayOfWeek.ToString(),
                        Shifts = new List<Shift>()
                        {
                            new Shift()
                            {
                                ShiftType = "Morning",
                                ShiftHours = (ShiftType.Morning).AsString(EnumFormat.Description),
                                IsShift = shift.ShiftType == (int)ShiftType.Morning ? true : false
                            },
                            new Shift()
                            {
                                ShiftType = "Afternoon",
                                ShiftHours = (ShiftType.Afternoon).AsString(EnumFormat.Description),
                                IsShift = shift.ShiftType == (int)ShiftType.Afternoon ? true : false
                            },
                            new Shift()
                            {
                                ShiftType = "Night",
                                ShiftHours = (ShiftType.Night).AsString(EnumFormat.Description),
                                IsShift = shift.ShiftType == (int)ShiftType.Night ? true : false
                            }

                        }
                    });
                }

                return Task.FromResult(workerShifts.AsEnumerable());
            }
            catch
            {
                throw;
            }
        }
    }
}
