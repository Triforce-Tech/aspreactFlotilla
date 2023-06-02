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
    public class TipoVehiculoController : ControllerBase
    {

        [HttpPost]
        [Route("guardaTipoVehiculo")]
        public async Task<IActionResult> guardaTipoVehiculo([FromBody] TipoVehiculo request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("TIPO_VEHICULO").AsInsert(new
            {

            MARCA = request.MARCA;
            MODELO = request.MODELO;
            AÑO = request.AÑO;
            DESCRIPCION = request.DESCRIPCION;
            TIPO = request.TIPO;
            TIPO_GASOLINA = request.TIPO_GASOLINA;
            TIPO_DIESEL = request.TIPO_DIESEL;
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
            List<TipoVehiculo> listaTipoVehiculo = new List<TipoVehiculo>();

            Query query = new Query();
            query.Select(
            "MARCA",
            "MODELO",
            "AÑO",
            "DESCRIPCION",
            "TIPO",
            "TIPO_GASOLINA",
            "TIPO_DIESEL";
            )
            query.From("TIPO_VEHICULO");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaTipoVehiculo = DataReaderMapper<TipoVehiculo>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaTipoVehiculo);
        }


        [HttpUpdate]
        [Route("actualizaTipoVehiculo")]
        public async Task<IActionResult> actualizaTipoVehiculo([FromBody] TipoVehiculo request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("TIPO_VEHICULO").AsInsert(new
            {

            MARCA = request.MARCA;
            MODELO = request.MODELO;
            AÑO = request.AÑO;
            DESCRIPCION = request.DESCRIPCION;
            TIPO = request.TIPO;
            TIPO_GASOLINA = request.TIPO_GASOLINA;
            TIPO_DIESEL = request.TIPO_DIESEL;
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp )

        }

    }
}
