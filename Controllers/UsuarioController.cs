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
    public class UsuarioController : ControllerBase
    {
        //obtener data
        [HttpGet]
        [Route("Tipousuario")]
        public async Task<IActionResult> Tipousuario()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var query1 = new Query();

            query1.Select("UUID").Select("DESCRIPCION").From("TIPO_USUARIO");

            var sql = execute.ExecuterCompiler(query1);
            List<TipoUsuario> estado = new List<TipoUsuario>();
            execute.DataReader(sql, reader =>
            {
                estado = DataReaderMapper<TipoUsuario>.MapToList(reader).ToList();
            });


            return StatusCode(StatusCodes.Status200OK, estado);

        }


        [HttpPost]
        [Route("Guardarusuario")]
        public async Task<IActionResult> Guardarusuario([FromBody] UserSession request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query1 = new Query();

            Estado estado = new Estado();
            query1.Select("UUID").From("ESTADO").Where("DESCRIPCION", "=", "ACTIVO");
            var sql = execute.ExecuterCompiler(query1);


            execute.DataReader(sql, reader =>
            {
                estado = DataReaderMapper<Estado>.MapToObject(reader);
            });


            UserSession userSession = new UserSession();

            var query2 = new Query("USERSESSION").AsInsert(new
            {
                USUARIO = request.USUARIO,
                PASSWORD = request.PASSWORD,
                UUID_ESTADO = estado.UUID

            });


            var sql2 = execute.ExecuterCompiler(query2);


            //var resp = execute.ExecuterOracle(sql);
            var resp = execute.ExecuteDecider(sql2);
            return StatusCode(StatusCodes.Status200OK, resp);



        }






    }

}

