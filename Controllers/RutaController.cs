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

        private readonly OraConnect _context;

        public RutaController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("route")]
        public async Task<IActionResult> route()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<Ruta> route = new List<Ruta>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID");
            query.From("Ruta");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                route = DataReaderMapper<Ruta>.MapToList(reader);
            });

            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, route);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Ruta request)
        {

            var query = new Query("Vehiculo").AsInsert(new
            {
               
                DESCRIPCION = request.DESCRIPCION,
                COORDENADA_PUNTO_A = request.COORDENADA_PUNTO_A,
                COORDENADA_PUNTO_B = request.COORDENADA_PUNTO_B,
                LINK_GOOGLE = request.LINK_GOOGLE,
                DISTANCIA_KM = request.DISTANCIA_KM
            });
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var sql = execute.ExecuterCompiler(query);

            //var resp = execute.ExecuterOracle(sql);
            var resp = "";
            return StatusCode(StatusCodes.Status200OK, resp);

        }

    }
}
