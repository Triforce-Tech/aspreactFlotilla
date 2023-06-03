using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassDB.EntidadesDB;
using ClassDB.ConnectDB;
using SqlKata;
using ClassDB.SqlKataTools;
using SqlKata.Extensions;
using System.Drawing;

namespace Flotilla_netCORE.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CerrarSessionController : Controller
    {

        [HttpPost]
        [Route("salir")]
        public async Task<IActionResult> salir([FromBody] dummy request)
        {

            

            HttpContext.Session.Clear();


            return StatusCode(StatusCodes.Status200OK, "ok");
        }





    }
}
