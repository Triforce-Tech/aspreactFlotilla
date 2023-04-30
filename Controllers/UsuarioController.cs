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
        [Route("Guardarpersona")]
        public async Task<IActionResult> Guardarpersona([FromBody] Usuario request)
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
            var query = new Query("USUARIO").AsInsert(new
            {

                PRIMER_NOMBRE = request.PRIMER_NOMBRE,
                SEGUNDO_NOMBRE = request.SEGUNDO_NOMBRE,
                TERCER_NOMBER = request.SEGUNDO_NOMBRE,
                PRIMER_APELLIDO = request.PRIMER_APELLIDO,
                SEGUNDO_APELLIDO = request.SEGUNDO_APELLIDO,
                DPI = request.DPI,
                DIRECCION = request.DIRECCION,
                TELEFONO = request.TELEFONO,
                CORREO = request.CORREO,
                EMPRESA = request.EMPRESA,
                FECHA_INGRESO = new DateTime(2009, 8, 4),
                FECHA_MODIFICACION = new DateTime(2009, 8, 4),
                UUID_ESTADO = estado.UUID,
                UUID_TIPO_USUARIO = request.UUID_TIPO_USUARIO,
                UUID_USER_SESSION = request.UUID_USER_SESSION
            }) ;

            var sql2 = execute.ExecuterCompiler(query);

            //var resp = execute.ExecuterOracle(sql);
            var resp = "";
            return StatusCode(StatusCodes.Status200OK, resp);
        }

        [HttpPost]
        [Route("Guardarusuario")]
        public async Task<IActionResult> Guardarusuario([FromBody] UserSession request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query1 = new Query();

            Estado estado = new Estado();
            query1.Select("UUID").From("ESTADO").Where("DESCRIPCION","=","ACTIVO");
            var sql = execute.ExecuterCompiler(query1);


            execute.DataReader(sql, reader =>
            {
                estado = DataReaderMapper<Estado>.MapToObject(reader);
            });


            UserSession userSession = new UserSession();

            var query2 = new Query("USERSESSION").AsInsert(new
            {
                Usuario = request.USUARIO,
                Password = request.PASSWORD,
                UUID_ESTADO = estado.UUID

            });


            var sql2 = execute.ExecuterCompiler(query2);

            
            //var resp = execute.ExecuterOracle(sql);
            var resp = execute.ExecuteDecider(sql);
            return StatusCode(StatusCodes.Status200OK, resp);
        }

    }

}

