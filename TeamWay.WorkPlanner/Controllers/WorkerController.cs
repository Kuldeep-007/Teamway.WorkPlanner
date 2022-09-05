using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teamway.WorkPlanner.Data.Enums;
using Teamway.WorkPlanner.Data.Interfaces;

namespace TeamWay.WorkPlanner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerRepository _workerRepository;
        public WorkerController(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Worker")]
        public async Task<IActionResult> GetWorkerShiftsById(int id, ShiftFilterType shiftType)
        {
            var workerShifts = await _workerRepository.GetWorkerShiftsById(id, shiftType);

            if (workerShifts == null)
            {
                return NotFound();
            }

            return Ok(workerShifts.ToList());
        }
    }
}
