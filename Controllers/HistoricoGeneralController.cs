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
    public class HistoricoGeneralController : Controller
    {

    [HttpPost]
       [Route("guardaHistoricoGeneral")]
       public async Task<IActionResult> guardaHistoricoGeneral([FromBody] HistoricoGeneral request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("HISTORICO_GENERAL").AsInsert(new
            {

                UUID_USUARIO = request.UUID_USUARIO,
                DESCRIPCION = request.DESCRIPCION,
                UUID_TRANSACTION = request.UUID_TRANSACTION,
                FECHA_CREACION = request.FECHA_CREACION,
                FECHA_MODIFICACION = request.FECHA_MODIFICACION,
                UUID_CATALOGO = request.UUID_CATALOG,
                IP = request.IP
            }) ;

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp);

        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<HistoricoGeneral> listaHistoricoGeneral = new List<HistoricoGeneral>();

            Query query = new Query();
            query.Select(
            "UUID_USUARIO",
            "DESCRIPCION",
            "UUID_TRANSACTION",
            "FECHA_CREACION",
            "FECHA_MODIFICACION",
            "UUID_CATALOGO"
            );
            query.From("HISTORICO_GENERAL");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaHistoricoGeneral = DataReaderMapper<HistoricoGeneral>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaHistoricoGeneral);
        }

        [HttpPut]
        [Route("ActualizaHistoricoGeneral")]
        public async Task<IActionResult> ActualizaHistoricoGeneral([FromBody] HistoricoGeneral request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("HISTORICO_GENERAL").AsInsert(new
            {

            UUID_USUARIO = request.UUID_USUARIO,
            DESCRIPCION = request.DESCRIPCION,
            UUID_TRANSACTION = request.UUID_TRANSACTION,
            FECHA_CREACION = request.FECHA_CREACION,
            FECHA_MODIFICACION = request.FECHA_MODIFICACION,
            UUID_CATALOGO = request.UUID_CATALOG,
            IP = request.IP,
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp);

        }
        


        
    }
}