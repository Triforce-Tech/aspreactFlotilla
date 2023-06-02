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
    public class AnalistaController : Controller
    {
       [HttpPost]
       [Route("guardaAnalista")]
       public async Task<IActionResult> guardaAnalista([FromBody] Analista request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("ANALISTA").AsInsert(new
            {

            UUID_USUARIO = request.UUID_USUARIO;
            ESTADO = request.ESTADO;
            FECHA_ALTA = request.FECHA_ALTA;
            FECHA_BAJA = request.FECHA_BAJA;
            TICKETS_RESUELTOS = request.TICKETS_RESUELTOS;
            TICKETS_EXITOSOS = request.TICKETS_EXITOSOS;
            TICKETS_FALLO = request.TICKETS_FALLO;
            TICKETS_CANCELA = request.TICKETS_CANCELA;
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
            List<Analista> listaAnalista = new List<Analista>();

            Query query = new Query();
            query.Select(
            "UUID_USUARIO",
            "ESTADO",
            "FECHA_ALTA",
            "FECHA_BAJA",
            "TICKETS_RESUELTOS",
            "TICKETS_EXITOSOS",
            "TICKETS_FALLO",
            "TICKETS_CANCELA";
            )
            query.From("ANALISTA");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaAnalista = DataReaderMapper<Analista>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaAnalista);
        }

        [HttpUpdate]
        [Route("actualizaAnalista")]
        public async Task<IActionResult> actualizaAnalista([FromBody] Analista request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("ANALISTA").AsInsert(new
            {

            UUID_USUARIO = request.UUID_USUARIO;
            ESTADO = request.ESTADO;
            FECHA_ALTA = request.FECHA_ALTA;
            FECHA_BAJA = request.FECHA_BAJA;
            TICKETS_RESUELTOS = request.TICKETS_RESUELTOS;
            TICKETS_EXITOSOS = request.TICKETS_EXITOSOS;
            TICKETS_FALLO = request.TICKETS_FALLO;
            TICKETS_CANCELA = request.TICKETS_CANCELA;
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp )
        }

    }
}