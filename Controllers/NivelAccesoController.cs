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
    public class NivelAccesoController : ControllerBase
    {
        [HttpPost]
        [Route("guardaNivelAcceso")]
        public async Task<IActionResult> guardaNivelAcceso([FromBody] NivelAccesso request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("NIVEL_ACCESO").AsInsert(new
            {

            TIPO = request.TIPO,
            DESCRIPCION = request.DESCRIPCION,
            UUID_CATALOGO_LIST = request.UUID_CATALOG_LIST
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp);

        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<NivelAccesso> listaNivelAcceso = new List<NivelAccesso>();

            Query query = new Query();
            query.Select(
            "TIPO",
            "DESCRIPCION",
            "UUID_CATALOGO_LIST"
            );
            query.From("NIVEL_ACCESO");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaNivelAcceso = DataReaderMapper<NivelAccesso>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaNivelAcceso);
        }

        [HttpPost]
        [Route("ActualizaNivelAcceso")]
        public async Task<IActionResult> ActualizaNivelAcceso([FromBody] NivelAccesso request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("NIVEL_ACCESO").AsInsert(new
            {

            TIPO = request.TIPO,
            DESCRIPCION = request.DESCRIPCION,
            UUID_CATALOGO_LIST = request.UUID_CATALOG_LIST
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp);

        }

 
    }
}