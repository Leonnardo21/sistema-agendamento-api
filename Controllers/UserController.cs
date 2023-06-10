using ConnectHealthApi.Data;
using ConnectHealthApi.Extensions;
using ConnectHealthApi.Models;
using ConnectHealthApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConnectHealthApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("v1/users")]
        public async Task<IActionResult> GetAsync([FromServices] ConnectHealthContext context)
        {
            try
            {
                var user = await context.Users.ToListAsync();
                return Ok(new ResultViewModel<List<UserModel>>(user));
            }
            catch
            {
              return StatusCode(500, new ResultViewModel<List<UserModel>>("U001G500 - Falha interna no servidor"));
            }            
        }

        [HttpGet("v1/users/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] ConnectHealthContext context)
        {
            try
            {
                var model = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (model == null)
                    return NotFound(new ResultViewModel<UserModel>("U002GBY500 - Informação não encontrada"));

                return Ok(model);
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<List<UserModel>>("U002GBY500 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/users")]
        public async Task<IActionResult> PostAsync([FromBody] EditorUserViewModel model, [FromServices] ConnectHealthContext context)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<UserModel>(ModelState.GetErrors()));
            try
            {
                var user = new UserModel
                {
                    Name = model.Name,
                    Gender = model.Gender,
                    Email = model.Email,
                    Phone = model.Phone,
                    Username = model.Username,
                    PasswordHash = model.PasswordHash,
                    CreatedAt = model.CreatedAt,
                    IsActive = model.IsActive,
                };
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Created($"{user.Id}", new ResultViewModel<UserModel>(user));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<UserModel>($"U003P500 - Não foi possível incluir o usuário {ex}"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<UserModel>>("U003P500 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/users/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorUserViewModel user, [FromServices] ConnectHealthContext context)
        {
            try
            {
                var model = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (model == null)
                    return NotFound(new ResultViewModel<UserModel>("U004U400 - Informação não encontrada"));

                model.Name = user.Name;
                model.Gender = user.Gender;
                model.Email = user.Email.ToLower();
                model.Phone = user.Phone;
                model.Username = user.Username;
                model.PasswordHash = user.PasswordHash;
                model.IsActive = user.IsActive;

                context.Users.Update(model);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<UserModel>(model));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<UserModel>($"U004U500 - Não foi possível alterar os dados do usuário {ex}"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<UserModel>>("U004U500 - Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/users/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromServices] ConnectHealthContext context)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                    return NotFound(new ResultViewModel<UserModel>("U005D400 - Informação não encontrada"));

                context.Users.Remove(user);
                await context.SaveChangesAsync();

                return Ok("Usuário removido!");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<UserModel>($"U005D500 - Não foi possível deletar o usuário {ex}"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<UserModel>("U005D500 - Falha interna no servidor"));
            }
        }
    }
}