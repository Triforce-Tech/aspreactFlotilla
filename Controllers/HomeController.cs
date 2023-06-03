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
    public class HomeController : Controller
    {


        [HttpPost]
        [Route("Lista")]
        public async Task<IActionResult> Lista([FromBody] dummy request)
        {
            var variableValue = HttpContext.Session.GetString("userSession");
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            Query query = new Query();
            List<OrdenVehiculos> list_orden = new List<OrdenVehiculos>();
            query.Select("*").From("ORDEN_VEHICULOS").Where("UUID_USUARIO", "=", variableValue);

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                list_orden = DataReaderMapper<OrdenVehiculos>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, list_orden);
        }
        [HttpPost]
        [Route("Lista1")]
        public async Task<IActionResult> Lista1([FromBody] dummy request)
        {
            var variableValue = HttpContext.Session.GetString("userSession");
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            Query query = new Query();
            List<Vehiculo> list_orden = new List<Vehiculo>();
            query.Select("*").From("VEHICULO");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                list_orden = DataReaderMapper<Vehiculo>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, list_orden);
        }

    }
}
