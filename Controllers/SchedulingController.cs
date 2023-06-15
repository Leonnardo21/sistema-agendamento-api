using ConnectHealthApi.Data;
using ConnectHealthApi.Extensions;
using ConnectHealthApi.Models;
using ConnectHealthApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConnectHealthApi.Controllers
{
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        [HttpGet("v1/scheduling")]
        public async Task<IActionResult> GetAsync([FromServices] ConnectHealthContext context)
        {
            try
            {
                var scheduling = await context.Schedulings.ToListAsync();
                if (scheduling == null)
                    return NotFound(new ResultViewModel<SchedulingModel>("S001G400 - Informação não encontrada!"));
                return Ok(scheduling);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<SchedulingModel>("S001G500 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/scheduling/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] ConnectHealthContext context)
        {
            try
            {
                var scheduling = await context.Schedulings.FirstOrDefaultAsync(x => x.Id == id);
                if (scheduling == null)
                    return NotFound(new ResultViewModel<SchedulingModel>("S002GBY400 - Informação não encontrada!"));
                return Ok(scheduling);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<SchedulingModel>("S002GBY500 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/scheduling/")]
        public async Task<IActionResult> PostAsync([FromBody] SchedulingModel model, [FromServices] ConnectHealthContext context) {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<SchedulingModel>(ModelState.GetErrors()));
                var scheduling = new SchedulingModel
                {
                    Date = model.Date,
                    TimeTable = model.TimeTable,
                    Duration = model.Duration,
                    Local = model.Local,
                    UserId = model.UserId,
                    ProfessionalId = model.ProfessionalId,
                };

                await context.Schedulings.AddAsync(scheduling);
                await context.SaveChangesAsync();
                return Created($"{scheduling.Id}", new ResultViewModel<SchedulingModel>(scheduling));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<SchedulingModel>("S003P500 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/scheduling/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] SchedulingModel scheduling, [FromServices] ConnectHealthContext context) {
            try
            {
                var model = await context.Schedulings.FirstOrDefaultAsync(x => x.Id == id);
                if (model == null)
                    return NotFound(new ResultViewModel<SchedulingModel>("S004P400 - Informação não encontrada!"));

                model.Date = scheduling.Date;
                model.TimeTable = scheduling.TimeTable;
                model.Duration = scheduling.Duration;
                model.Local = scheduling.Local;

                context.Schedulings.Update(model);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<SchedulingModel>(model));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<SchedulingModel>("A004U500 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/scheduling/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromServices] ConnectHealthContext context) {
            try
            {
                var scheduling = await context.Schedulings.FirstOrDefaultAsync(x => x.Id == id);
                if (scheduling == null)
                    return NotFound(new ResultViewModel<SchedulingModel>("S005D400 - Informação não encontrada"));
                context.Schedulings.Remove(scheduling);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<SchedulingModel>("Agendamento cancelado"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<SchedulingModel>("A005U500 - Falha interna no servidor"));
            }
            
        }
    }
}