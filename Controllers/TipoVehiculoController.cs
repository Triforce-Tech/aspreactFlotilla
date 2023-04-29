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

        private readonly OraConnect _context;

        public TipoVehiculoController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("vehicletype")]
        public async Task<IActionResult> vehicletype()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<TipoVehiculo> vehicletype = new List<TipoVehiculo>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID_TIPO_VEHICULO");
            query.From("TipoVehiculo");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                vehicletype = DataReaderMapper<TipoVehiculo>.MapToList(reader);
            });

            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, vehicletype);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] TipoVehiculo request)
        {

            var query = new Query("Vehiculo").AsInsert(new
            {
                UUID_TIPO_VEHICULO = request.UUID_TIPO_VEHICULO,
                MARCA = request.MARCA,
                MODELO = request.MODELO,
                AÑO = request.AÑO,
                DESCRIPCION = request.DESCRIPCION,
                TIPO = request.TIPO,
                TIPO_GASOLINA = request.TIPO_GASOLINA,
                TIPO_DISEL = request.TIPO_DISEL
            });
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var sql = execute.ExecuterCompiler(query);

            //var resp = execute.ExecuterOracle(sql);
            var resp = execute.ExecuterOracle(sql);
            return StatusCode(StatusCodes.Status200OK, resp);

        }

    }
}
