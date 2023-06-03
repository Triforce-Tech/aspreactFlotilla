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
    public class TipoVehiculo2Controller : ControllerBase
    {


        [HttpPost]
        [Route("marca")]
        public async Task<IActionResult> marca([FromBody] TipoVehiculo request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<TipoVehiculo> listaTipoVehiculo = new List<TipoVehiculo>();

            Query query = new Query();
            query.Select(
            "MARCA"            );
            query.From("TIPO_VEHICULO").Where("UUID","=", request.UUID).Limit(1);

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaTipoVehiculo = DataReaderMapper<TipoVehiculo>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaTipoVehiculo);
        }




    }
}
