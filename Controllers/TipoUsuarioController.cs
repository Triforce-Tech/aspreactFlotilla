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
    public class TipoUsuarioController : ControllerBase
    {

        private readonly OraConnect _context;

        public TipoUsuarioController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("usertype")]
        public async Task<IActionResult> usertype()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<TipoUsuario> usertype = new List<TipoUsuario>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID_TIPO_USUARIO");
            query.From("TipoUsuario");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                usertype = DataReaderMapper<TipoUsuario>.MapToList(reader);
            });

            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, usertype);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] TipoUsuario request)
        {

            var query = new Query("TipoUsuario").AsInsert(new
            {
                UUID_TIPO_USUARIO = request.UUID_TIPO_USUARIO,
                UUID_NIVEL = request.UUID_NIVEL,
                TIPO = request.TIPO,
                DESCRIPCION = request.DESCRIPCION,
                UUID_ESTADO = request.UUID_ESTADO,
                FECHA_MODIFICACION = new DateTime(2009, 8, 4),
                FECHA_CREACION = new DateTime(2009, 8, 4)
                });
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var sql = execute.ExecuterCompiler(query);

            //var resp = execute.ExecuterOracle(sql);
        var resp = "";
            return StatusCode(StatusCodes.Status200OK, resp);

        }

    }
}
