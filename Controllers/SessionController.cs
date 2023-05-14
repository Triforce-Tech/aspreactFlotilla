using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassDB.EntidadesDB;
using ClassDB.ConnectDB;
using SqlKata;
using ClassDB.SqlKataTools;

namespace Flotilla_netCORE.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {



        [HttpPost]
        [Route("guardarsession")]
        public async Task<IActionResult> usersession([FromBody] UserSession request)
        {

            HttpContext.Session.SetString("userSession", request.UUID);
            return StatusCode(StatusCodes.Status200OK, "OK");

            //var valor = HttpContext.Session.GetString("UserSession");
            //acceder a la variable de la sesion dentro de c#

        }

        [HttpGet]
        [Route("consultasession")]
        public async Task<IActionResult> consultasession()
        {

            var valor = HttpContext.Session.GetString("UserSession");
            //acceder a la variable de la sesion dentro de c#

            //HttpContext.Session.SetString("userSession", request.UUID);
            return StatusCode(StatusCodes.Status200OK, valor);


        }

    }

}

