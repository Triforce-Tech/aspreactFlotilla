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
    public class CatalogoPrecioController : ControllerBase
    {
        [HttpPost]
        [Route("guardaCatalogo_Precio")]
        public async Task<IActionResult> guardaCatalogo_Precio([FromBody] CatalogoPrecio request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("CATALOGO_PRECIO").AsInsert(new
            {

            UUID_TIPO_VEHICULO = request.UUID_TIPO_VEHICULO;
            PRECIO_POR_KM = request.PRECIO_POR_KM;
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
            List<CatalogoPrecio> listaCatalogoPrecio = new List<CatalogoPrecio>();

            Query query = new Query();
            query.Select(
            "UUID_TIPO_VEHICULO",
            "PRECIO_POR_KM";
            )
            query.From("CATALOGO_PRECIO");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaCatalogoPrecio = DataReaderMapper<CatalogoPrecio>.MapToList(reader);
            });
            return StatusCode(StatusCodes.Status200OK, listaCatalogoPrecio);
        }

        [HttpUpdate]
        [Route("actualiza_Catalogo_Preci0")]
        public async Task<IActionResult> actualiza_Catalogo_Preci0([FromBody] CatalogoPrecio request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("CATALOGO_PRECIO").AsInsert(new
            {

            UUID_TIPO_VEHICULO = request.UUID_TIPO_VEHICULO;
            PRECIO_POR_KM = request.PRECIO_POR_KM;
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp )

        }


    }
}