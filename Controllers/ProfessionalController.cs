using ConnectHealthApi.Data;
using ConnectHealthApi.Models;
using ConnectHealthApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConnectHealthApi.Controllers
{
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        [HttpGet("v1/professional/")]
        public async Task<IActionResult> GetAsync([FromServices] ConnectHealthContext context)
        {
            try {
                var professional = await context.Professionals.ToListAsync();
                return Ok(new ResultViewModel<List<ProfessionalModel>>(professional));
            }
            catch  {
               return StatusCode(500, new ResultViewModel<ProfessionalModel>("P001G500 - U001G500 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/professional/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] ConnectHealthContext context)
        {
            try
            {
                var model = await context.Professionals.FirstOrDefaultAsync(x => x.Id == id);
                if (model == null)
                    return NotFound(new ResultViewModel<ProfessionalModel>("Informação não encontrada"));
                return Ok(model);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<ProfessionalModel>("P002GBY500 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/professional/")]
        public async Task<IActionResult> PostAsync([FromBody] EditorProfessionalViewModel model, [FromServices] ConnectHealthContext context)
        {
            try {
                var professional = new ProfessionalModel {
                    Name = model.Name,
                    Gender = model.Gender,
                    Email = model.Email,
                    Phone = model.Phone,
                    Especiality = model.Especiality,
                    Username = model.Username,
                    PasswordHash = model.PasswordHash,
                    CreatedAt = model.CreatedAt,
                    IsActive = model.IsActive,
                };
                await context.Professionals.AddAsync(professional);
                await context.SaveChangesAsync();

                return Created($"{professional.Id}", new ResultViewModel<ProfessionalModel>(professional));
            }
            catch {
                return StatusCode(500, new ResultViewModel<ProfessionalModel>("P003P500 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/professional/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorProfessionalViewModel professional, [FromServices] ConnectHealthContext context)
        {
            try
            {
                var model = await context.Professionals.FirstOrDefaultAsync(x => x.Id == id);
                if (model == null)
                    return NotFound(new ResultViewModel<ProfessionalModel>("P004P400 - Informação não encontrada"));

                model.Name = professional.Name;
                model.Gender = professional.Gender;
                model.Email = professional.Email;
                model.Phone = professional.Phone;
                model.Especiality = professional.Especiality;
                model.Username = professional.Username;
                model.PasswordHash = professional.PasswordHash;
                model.IsActive = professional.IsActive;

                context.Professionals.Update(model);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<ProfessionalModel>(model));
            }catch (Exception ex) {
                return StatusCode(500, new ResultViewModel<ProfessionalModel>("P004P500 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/professional/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromServices] ConnectHealthContext context)
        {
            try
            {
                var model = await context.Professionals.FirstOrDefaultAsync(x => x.Id == id);
                if (model == null)
                    return NotFound(new ResultViewModel<ProfessionalModel>("P005P400 - Informação não encontrada"));

                context.Professionals.Remove(model);
                await context.SaveChangesAsync();
                return Ok("Profissional removido");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<UserModel>($"P005D500 - Não foi possível deletar o usuário {ex}"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<UserModel>("P005D500 - Falha interna no servidor"));
            }
        }
    }
}