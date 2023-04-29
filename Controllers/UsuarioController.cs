using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassDB.EntidadesDB;
using ClassDB.ConnectDB;
using SqlKata;
using ClassDB.SqlKataTools;

namespace Flotilla_netCORE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly OraConnect _context;

        public UsuarioController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> user()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<Usuario> usuario = new List<Usuario>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID_USUARIO");
            query.From("Usuario");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                usuario = DataReaderMapper<Usuario>.MapToList(reader);
            });

            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, usuario);

        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Usuario request)
        {
            var query = new Query("UserSession").AsInsert(new
            {
                UUID_USUARIO = request.UUID_USUARIO,
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
                UUID_ESTADO = request.UUID_ESTADO,
                UUID_TIPO_USUARIO = request.UUID_TIPO_USUARIO,
                UUID_USER_SESSION = request.UUID_USER_SESSION
            });
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var sql = execute.ExecuterCompiler(query);

            //var resp = execute.ExecuterOracle(sql);
            var resp = execute.ExecuterOracle(sql);
            return StatusCode(StatusCodes.Status200OK, resp);
        }
        
    }

}

