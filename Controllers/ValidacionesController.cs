using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassDB.EntidadesDB;
using ClassDB.ConnectDB;
using SqlKata;
using ClassDB.SqlKataTools;
using SqlKata.Extensions;
using System.Drawing;
using SqlKata.Compilers;

namespace Flotilla_netCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidacionesController : Controller
    {
        [HttpPost]
        [Route("validadispo")]
        public async Task<IActionResult> validadispo([FromBody] dummy request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            Query query = new Query();

            query.Select("USUARIO").From("USERSESSION").Where("USUARIO", "=", request.value);
            var sql = execute.ExecuterCompiler(query);
            List<UserSession> sessions = new List<UserSession>();

            execute.DataReader(sql.ToString(), reader =>
            {
                sessions = DataReaderMapper<UserSession>.MapToList(reader);
            });
            request.value = "";
            if (sessions.Count > 0)
            {
                request.value = "No";
            }else
            {
                request.value = "Ok";
            }

            return StatusCode(StatusCodes.Status200OK, request.value);
        }

        [HttpPost]
        [Route("validaregistro")]
        public async Task<IActionResult> validaregistro([FromBody] Usuario request)
        {
            Usuario usuario = new Usuario();
            var status = "Ok";
            var com = 0;
            if (request.CORREO.Contains("@")&& request.CORREO.Contains(".com"))
            {
                com = com + 1;
                if (request.PRIMER_APELLIDO.Length > 0) { com = com + 1; }
                if (request.TELEFONO.ToString().Length > 8 ) { com = com + 1; }
                if (request.DPI.ToString().Length > 8 ) { com = com + 1; }
                if (com == 4) { status = "Ok"; }else { status = "No"; };
            }






            return StatusCode(StatusCodes.Status200OK,status );
        }

    }
}
