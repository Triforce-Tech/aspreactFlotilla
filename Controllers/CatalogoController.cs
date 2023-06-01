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
    public class CatalogoController : ControllerBase
    {
        [HttpPost]
        [Route("guardaCatalogo")]
        public async Task<IActionResult> guardaCatalogo([FromBody] Catalogo request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("CATALOGO").AsInsert(new
            {

            CATALOGO = request.CATALOGO;
            DESCRIPCION = request.DESCRIPCION;
            UUID_ESTADO = request.UUID_ESTADO;
            FECHA_MODIFICACION_CATALOGO = request.FECHA_MODIFICACION_CATALOGO;
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
            List<Catalogo> listaCatalogo = new List<Catalogo>();

            Query query = new Query();
            query.Select(
            "CATALOGO",
            "DESCRIPCION",
            "UUID_ESTADO",
            "FECHA_MODIFICACION",
            "FECHA_CREACION";
            )
            query.From("CATALOGO");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaCatalogo = DataReaderMapper<Catalogo>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaCatalogo);
        }

        [HttpUpdate]
        [Route("actualizaCatalogo")]
        public async Task<IActionResult> actualizaCatalogo([FromBody] Catalogo request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("CATALOGO").AsInsert(new
            {

            CATALOGO = request.CATALOGO;
            DESCRIPCION = request.DESCRIPCION;
            UUID_ESTADO = request.UUID_ESTADO;
            FECHA_MODIFICACION_CATALOGO = request.FECHA_MODIFICACION_CATALOGO;
            FECHA_CREACION = request.FECHA_CREACION;
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp )

        }

    }

}
