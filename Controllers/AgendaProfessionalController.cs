using ConnectHealthApi.Data;
using ConnectHealthApi.Extensions;
using ConnectHealthApi.Models;
using ConnectHealthApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConnectHealthApi.Controllers
{
    public class AgendaProfessionalController : ControllerBase {
        [HttpGet("v1/agenda-professional/")]
        public async Task<IActionResult> GetAsync([FromServices] ConnectHealthContext context)
        {
            try
            {
                var  agenda = await context.AgendaProfessionals.ToListAsync();
                if (agenda == null)
                    return NotFound(new ResultViewModel<AgendaProfessionalModel>("Informação não encontrada"));
                return Ok(agenda);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<AgendaProfessionalModel>("A001G500 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/agenda-professional/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] ConnectHealthContext context)
        {
            try {
                var agenda = await context.AgendaProfessionals.FirstOrDefaultAsync(x => x.Id == id);
                if (agenda == null)
                    return NotFound(new ResultViewModel<AgendaProfessionalModel>("Informação não encontrada"));
                return Ok(agenda);
            }
            catch {
                return StatusCode(500, new ResultViewModel<AgendaProfessionalModel>("A002GBY500 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/agenda-professional")]
        public async Task<IActionResult> PostAsync([FromBody] AgendaProfessionalModel model, [FromServices] ConnectHealthContext context) 
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<AgendaProfessionalModel>(ModelState.GetErrors()));
            try
            {
                var agenda = new AgendaProfessionalModel
                {
                    Date = model.Date,
                    TimeTable = model.TimeTable,
                    Duration = model.Duration,
                    Local = model.Local,
                    ProfessionalId = model.ProfessionalId,
                };

                context.AgendaProfessionals.Add(agenda);
                await context.SaveChangesAsync();

                return Created($"{agenda.Id}", new ResultViewModel<AgendaProfessionalModel>(agenda));
            }catch
            {
                return StatusCode(500, new ResultViewModel<AgendaProfessionalModel>("A003P500 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/agenda-professional/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] AgendaProfessionalModel agenda, [FromServices] ConnectHealthContext context)
        {
            try {
                var model = await context.AgendaProfessionals.FirstOrDefaultAsync(x => x.Id == id);
                if (model == null)
                    return NotFound(new ResultViewModel<AgendaProfessionalModel>("Informação não encontrada!"));

                model.Date = agenda.Date;
                model.TimeTable = agenda.TimeTable;
                model.Duration = agenda.Duration;
                model.Local = agenda.Local;

                context.AgendaProfessionals.Update(model);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<AgendaProfessionalModel>(model));
            } catch {
                return StatusCode(500, new ResultViewModel<AgendaProfessionalModel>("A004U500 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/agenda-professional/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromServices] ConnectHealthContext context)
        {
            try
            {
                var agenda = await context.AgendaProfessionals.FirstOrDefaultAsync(x => x.Id == id);
                if (agenda == null) return NotFound(new ResultViewModel<AgendaProfessionalModel>("A005D400 - Informação não encontrada!"));

                context.AgendaProfessionals.Remove(agenda);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<AgendaProfessionalModel>("Consulta deletada!"));
            }catch
            {
                return StatusCode(500, new ResultViewModel<AgendaProfessionalModel>("A005D500 - Falha interna no servidor"));
            }
        }
    }
}