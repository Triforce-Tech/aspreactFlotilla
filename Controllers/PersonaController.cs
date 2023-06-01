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

            // Consulta 1: Obtener el UUID del estado "ACTIVO"
            query1.Select("UUID").From("ESTADO").Where("DESCRIPCION", "=", "ACTIVO");
            var sql = execute.ExecuterCompiler(query1);

            var query2 = new Query();
            UserSession userSession = new UserSession();

            // Consulta 2: Obtener el UUID de la sesión de usuario basado en el nombre de usuario
            query2.Select("UUID").From("USERSESSION").Where("USUARIO", "=", request.USER_NAME).Limit(1);
            var sql2 = execute.ExecuterCompiler(query2);

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
            var resp = execute.ExecuteDecider(sql3);

            return StatusCode(StatusCodes.Status200OK, resp);
        }

        [HttpGet]
        [Route("consultaPersona")]
        public async Task<IActionResult> consultaPersona()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<Usuario> listauser = new List<Usuario>();

            //query
            Query query = new Query();
            query.Select(
            "PRIMER_NOMBRE",
            "SEGUNDO_NOMBRE",
            "TERCER_NOMOBRE",
            "PRIMER_APELLIDO",
            "SEGUNDO_APELLIDO",
            "DPI",
            "DIRECCION",
            "TELEFONO",
            "CORREO",
            "EMPRESA",
            "FECHA_INGRESO",
            "FECHA_MODIFICACION",
            "UUID_ESTADO",
            "UUID_TIPO_USUARIO",
            "UUID_USER_SESSION",
            "USER_NAME";
            )
            query.From("USUARIO");

            var sql = execute.ExecuterCompiler(query);
            execute.DataReader(sql.ToString(), reader =>
            {
                listauser = DataReaderMapper<Usuario>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listauser);
        }


        [HttpUpdate]
        [Route("actualizaPersona")]
        public async Task<IActionResult> actualizaPersona([FromBody] Usuario request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var ex = execute.ExecuteDecider("commit");

            var query1 = new Query();
            Estado estado = new Estado();

            query1.Select("UUID").From("ESTADO").Where("DESCRIPCION", "=", "ACTIVO");
            var sql = execute.ExecuterCompiler(query1);

            var query2 = new Query();
            UserSession userSession = new UserSession();

            query2.Select("UUID").From("USERSESSION").Where("USUARIO", "=", request.USER_NAME).Limit(1);
            var sql2 = execute.ExecuterCompiler(query2);

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
            var resp = execute.ExecuteDecider(sql3);

            return StatusCode(StatusCodes.Status200OK, resp);
        }




    }
}
