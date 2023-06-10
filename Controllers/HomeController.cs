using ConnectHealthApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace ConnectHealthApi.Controllers 
{
    [ApiController]
    public class HomeController:ControllerBase {

        [HttpGet("v1")]
        public  IActionResult Get([FromServices] ConnectHealthContext context) {
            return Ok("API online!");
        }
    }
}