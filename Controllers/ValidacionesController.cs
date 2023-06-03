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
    public class ValidacionesController
    {

        [HttpPost]
        [Route("validadispo")]
        public async Task<IActionResult> validadispo([FromBody] dummy request)
        {


            return StatusCodes(StatusCodes.Status200OK, "ok");
        }
    }
}
