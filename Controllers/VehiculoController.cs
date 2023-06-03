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
    public class VehiculoController : ControllerBase
    {

        [HttpPost]
        [Route("guardaVehiculo")]
        public async Task<IActionResult> guardaVehiculo([FromBody] Vehiculo request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("VEHICULO").AsInsert(new
            {

                UUID_TIPO_VEHICULO = request.UUID_TIPO_VEHICULO,
                UUID_USUARIO = request.UUID_USUARIO,
                PLACA = request.PLACA,
                DESCRIPCION = request.DESCRIPCION,
                FECHA_CARGA = request.FECHA_CARGA,
                FECHA_MODIFICACION = request.FECHA_MODIFICACION,
                UUID_ESTADO = request.UUID_ESTADO,
                KILOMETRAJE_ACTUAL = request.KILOMETRAJE_ACTUAL,
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
            List<Vehiculo> listaVehiculo = new List<Vehiculo>();

            Query query = new Query();
            query.Select(
            "UUID_TIPO_VEHICULO",
            "UUID_TIPO_USUARIO",
            "PLACA",
            "DESCRIPCION",
            "FECHA_CARGA",
            "FECHA_MODIFICACION",
            "UUID_ESTADO",
            "KILOMETRAJE_ACTUAL"
            );
            query.From("TIPO_VEHICULO");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaVehiculo = DataReaderMapper<Vehiculo>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaVehiculo);
        }


        [HttpPut]
        [Route("actualizaVehiculo")]
        public async Task<IActionResult> actualizaVehiculo([FromBody] Vehiculo request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("VEHICULO").AsInsert(new
            {
                UUID_TIPO_VEHICULO = request.UUID_TIPO_VEHICULO,
                UUID_USUARIO = request.UUID_USUARIO,
                PLACA = request.PLACA,
                DESCRIPCION = request.DESCRIPCION,
                FECHA_CARGA = request.FECHA_CARGA,
                FECHA_MODIFICACION = request.FECHA_MODIFICACION,
                UUID_ESTADO = request.UUID_ESTADO,
                KILOMETRAJE_ACTUAL = request.KILOMETRAJE_ACTUAL,
            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp);

        }

    }
}
