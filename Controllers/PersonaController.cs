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
    public class PersonaController : Controller
    {

        [HttpPost]
        [Route("Guardarper")]
        public async Task<IActionResult> Guardarper([FromBody] Usuario request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var ex = execute.ExecuteDecider("commit");
            var query1 = new Query();

            Estado estado = new Estado();
            query1.Select("UUID").From("ESTADO").Where("DESCRIPCION", "=", "ACTIVO");
            var sql = execute.ExecuterCompiler(query1);

            var query2 = new Query();

            query2.Select("UUID").From("USERSESSION").Where("USUARIO", "=", request.USER_NAME).Limit(1);
            var sql2 = execute.ExecuterCompiler(query2);

            UserSession userSession = new UserSession();

            execute.DataReader(sql2, reader =>
            {
                userSession = DataReaderMapper<UserSession>.MapToObject(reader);
            });


            execute.DataReader(sql, reader =>
            {
                estado = DataReaderMapper<Estado>.MapToObject(reader);
            });
            var query = new Query("USUARIO").AsInsert(new
            {

                PRIMER_NOMBRE = request.PRIMER_NOMBRE,
                SEGUNDO_NOMBRE = request.SEGUNDO_NOMBRE,
                TERCER_NOMBRE = request.SEGUNDO_NOMBRE,
                PRIMER_APELLIDO = request.PRIMER_APELLIDO,
                SEGUNDO_APELLIDO = request.SEGUNDO_APELLIDO,
                DPI = request.DPI,
                DIRECCION = request.DIRECCION,
                TELEFONO = request.TELEFONO,
                CORREO = request.CORREO,
                EMPRESA = request.EMPRESA,
                FECHA_INGRESO = "",
                FECHA_MODIFICACION = "",
                UUID_ESTADO = estado.UUID,
                UUID_TIPO_USUARIO = request.UUID_TIPO_USUARIO,
                UUID_USER_SESSION = userSession.UUID
            });

            var sql3 = execute.ExecuterCompiler(query);
            //var commit = "commit";
            //var resp = execute.ExecuterOracle(sql);
            var resp = execute.ExecuteDecider(sql3);
            
            return StatusCode(StatusCodes.Status200OK, resp);
        }

    }

}
