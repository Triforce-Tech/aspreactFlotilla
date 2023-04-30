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
    public class VehicleController : ControllerBase
    {

       
        //obtener data
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<Vehiculo> vehicle = new List<Vehiculo>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID").Select("DESCRIPCION").Select("UUID_ESTADO");
            query.From("VEHICULO");
            query.Where("UUID_ESTADO", "=", "51DC9BFF29084843AF4A1A580D2E1234");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                vehicle = DataReaderMapper<Vehiculo>.MapToList(reader);
            });

            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, vehicle);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Vehiculo request)
        {

            var query = new Query("Vehiculo").AsInsert(new
            {
                UUID = request.UUID,
                UUID_TIPO_VEHICULO = request.UUID_TIPO_VEHICULO,
                UUID_USUARIO = request.UUID_USUARIO,
                PLACA = request.PLACA,
                DESCRIPCION = request.DESCRIPCION,
                FECHA_CARGA = new DateTime(2009, 8, 4),
                FECHA_MODIFICACION = new DateTime(2009, 8, 4),
                UUID_ESTADO = request.UUID_ESTADO,
                KILOMETRAJE_ACTUAL = request.KILOMETRAJE_ACTUAL
            });
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var sql = execute.ExecuterCompiler(query);

            //var resp = execute.ExecuterOracle(sql);
        var resp = "";
            return StatusCode(StatusCodes.Status200OK, resp);

        }

    }
}
