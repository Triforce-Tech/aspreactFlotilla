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
    public class SessionController : ControllerBase
    {



        [HttpPost]
        [Route("guardarsession")]
        public async Task<IActionResult> usersession([FromBody] UserSession request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            UserSession userSession = new UserSession();

            Query query = new Query();

            query = query.Select("UUID").From("USERSESSION").Where("USUARIO", request.USUARIO).Where("PASSWORD", request.PASSWORD).Limit(1);

            var sql = execute.ExecuterCompiler(query);
            execute.DataReader(sql, reader =>
            {
                userSession = DataReaderMapper<UserSession>.MapToObject(reader);
            });
            if (userSession != null)
            {
                HttpContext.Session.SetString("userSession", userSession.UUID);

            }
          
            return StatusCode(StatusCodes.Status200OK, "ok");
            
            //var valor = HttpContext.Session.GetString("UserSession");
            //acceder a la variable de la sesion dentro de c#

        }

      
        [HttpGet]
        [Route("consultasession")]
        public async Task<IActionResult> consultasession()
        {

            var variableValue = HttpContext.Session.GetString("userSession");


            List<string> variables = new List<string>();
            if (variableValue != null)
            {
                variables.Add(variableValue.ToString());
            }
            variables.Add("pass");
            //acceder a la variable de la sesion dentro de c#

            //HttpContext.Session.SetString("userSession", request.UUID);
            return StatusCode(StatusCodes.Status200OK, variables);


        }

    }

}

