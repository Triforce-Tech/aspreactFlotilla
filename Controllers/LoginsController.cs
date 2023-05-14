using ClassDB.ConnectDB;
using ClassDB.EntidadesDB;
using ClassDB.SqlKataTools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlKata;

namespace Flotilla_netCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] UserSession request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var usuario = request.USUARIO;
            var password = request.PASSWORD;
            UserSession users = new UserSession();

            //query en sqlkata

            Query query = new Query();
            query.Select("usuario");
            query.From("USERSESSION");
            query.Where("usuario", usuario);
            query.Where("password", password).Limit(1);
            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                users = DataReaderMapper<UserSession>.MapToObject(reader);
            });

            
            if (users != null)
            {
                HttpContext.Session.SetString("userSession", users.UUID);
                //return StatusCode(StatusCodes.Status200OK, users);
                return Redirect("/home");

            }
            else
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, users);
                return Redirect("/home");
            }


        }




    }
}
