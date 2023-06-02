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
    public class RutaController : ControllerBase
    {

        [HttpPost]
        [Route("guardaRuta")]
        public async Task<IActionResult> guardaRuta([FromBody] Ruta request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("RUTA").AsInsert(new
            {

            DESCRIPCION = request.DESCRIPCION;
            COORDENADA_PUNTO_A = request.COORDENADA_PUNTO_A;
            COORDENADA_PUNTO_B = request.COORDENADA_PUNTO_B;
            LINK_GOOGLE = request.LINK_GOOGLE;
            DISTANCIA_KM = request.DISTANCIA_KM;
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
            List<Ruta> listaRuta = new List<Ruta>();

            Query query = new Query();
            query.Select(
            "DESCRIPCION",
            "COORDENADA_PUNTO_A",
            "COORDENADA_PUNTO_B",
            "LINK_GOOGLE",
            "DISTANCIA_KM";
            )
            query.From("RUTA");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaRuta = DataReaderMapper<Ruta>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaRuta);
        }

        [HttpPost]
        [Route("actualizaRuta")]
        public async Task<IActionResult> actualizaRuta([FromBody] Ruta request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("RUTA").AsInsert(new
            {

            DESCRIPCION = request.DESCRIPCION;
            COORDENADA_PUNTO_A = request.COORDENADA_PUNTO_A;
            COORDENADA_PUNTO_B = request.COORDENADA_PUNTO_B;
            LINK_GOOGLE = request.LINK_GOOGLE;
            DISTANCIA_KM = request.DISTANCIA_KM;
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp )

        }

    }
}
