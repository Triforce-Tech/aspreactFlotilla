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
    public class EstadoController : Controller
    {

        [HttpPost]
        [Route("guardaEstado")]
        public async Task<IActionResult> guardaEstado([FromBody] Estado request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("ESTADO").AsInsert(new
            {
            DESCRIPCION = request.DESCRIPCION;
            FECHA_INGRESO = request.FECHA_INGRESO;
            FECHA_MODIFICA = request.FECHA_MODIFICA;
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
            List<Estado> listaeEstado = new List<Estado>();

            Query query = new Query();
            query.Select(
            "DESCRIPCION",
            "FECHA_INGRESO",
            "FECHA_MODIFICA";
            )
            query.From("ESTADO");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaEstado = DataReaderMapper<Estado>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaEstado);
        }

        [HttpUpdate]
        [Route("ActualizaEstado")]
        public async Task<IActionResult> ActualizaEstado([FromBody] Estado request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("ESTADO").AsInsert(new
            {
            DESCRIPCION = request.DESCRIPCION;
            FECHA_INGRESO = request.FECHA_INGRESO;
            FECHA_MODIFICA = request.FECHA_MODIFICA;
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp )

        }

    }
}