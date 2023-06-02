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
    public class OrdenOpController : Controller
    {

        [HttpPost]
        [Route("guardaOrdenOp")]
        public async Task<IActionResult> guardaOrdenOp([FromBody] OrdenOp request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("ORDEN_OP").AsInsert(new
            {

            UUID_OPERADOR = request.UUID_OPERADOR;
            UUID_ORDEN = request.UUID_ORDEN;
            UUID_ESTADO = request.UUID_ESTADO;
            FECHA_ASIGNA = request.FECHA_ASIGNA;
            FECHA_MODIFICA = request.FECHA_MODIFICA;
            FECHA_CANCELA = FECHA_CANCELA;
            DESCRIPCION = request.DESCRIPCION;
            NO_ORDEN = request.NO_ORDEN;
            ORDEN_ENTREA = request.ORDEN_ENTREA;
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
            List<OrdenOp> listaOrdenOp = new List<OrdenOp>();

            Query query = new Query();
            query.Select(
            "UUID_OPERADOR",
            "UUID_ORDEN",
            "UUID_ESTADO",
            "FECHA_ASIGNA",
            "FECHA_MODIFICA",
            "FECHA_CANCELA",
            "DESCRIPCION",
            "NO_ORDEN",
            "ORDEN_ENTREA";
            )
            query.From("ORDEN");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaOrdenOp = DataReaderMapper<OrdenOp>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaOrdenOp);
        }

        [HttpUpdate]
        [Route("ActualizaOrdenOp")]
        public async Task<IActionResult> ActualizaOrdenOp([FromBody] OrdenOp request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("ORDEN_OP").AsInsert(new
            {

            UUID_OPERADOR = request.UUID_OPERADOR;
            UUID_ORDEN = request.UUID_ORDEN;
            UUID_ESTADO = request.UUID_ESTADO;
            FECHA_ASIGNA = request.FECHA_ASIGNA;
            FECHA_MODIFICA = request.FECHA_MODIFICA;
            FECHA_CANCELA = FECHA_CANCELA;
            DESCRIPCION = request.DESCRIPCION;
            NO_ORDEN = request.NO_ORDEN;
            ORDEN_ENTREA = request.ORDEN_ENTREA;
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp )

        }

    }
}