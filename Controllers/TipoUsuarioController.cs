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
    public class TipoUsuarioController : Controller
    {

        [HttpPost]
        [Route("guardaTipoUsuario")]
        public async Task<IActionResult> guardaTipoUsuario([FromBody] TipoUsuario request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("TIPO_USUARIO").AsInsert(new
            {

            UUID_NIVEL = request.UUID_NIVEL;
            TIPO = request.TIPO;
            DESCRIPCION = request.DESCRIPCION;
            UUID_ESTADO = request.UUID_ESTADO;
            FECHA_MODIFICACION = request.FECHA_MODIFICACION;
            FECHA_CREACION = request.FECHA_CREACION;
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp )

        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<TipoUsuario> listaTipoUsuario = new List<TipoUsuario>();

            Query query = new Query();
            query.Select(
            "UUID_NIVEL",
            "TIPO",
            "DESCRIPCION",
            "UUID_ESTADO",
            "FECHA_MODIFICACION",
            "FECHA_CREACION";
            )
            query.From("TIPO_USUARIO");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaTipoUsuario = DataReaderMapper<TipoUsuario>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaTipoUsuario);
        }
        [HttpUpdate]
        [Route("actualizaTipoUsuario")]
        public async Task<IActionResult> actualizaTipoUsuario([FromBody] TipoUsuario request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("TIPO_USUARIO").AsInsert(new
            {

            UUID_NIVEL = request.UUID_NIVEL;
            TIPO = request.TIPO;
            DESCRIPCION = request.DESCRIPCION;
            UUID_ESTADO = request.UUID_ESTADO;
            FECHA_MODIFICACION = request.FECHA_MODIFICACION;
            FECHA_CREACION = request.FECHA_CREACION;
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp )

        }

    }
}
