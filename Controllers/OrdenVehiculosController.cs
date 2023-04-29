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
    public class OrdenVehiculosController : ControllerBase
    {

        private readonly OraConnect _context;

        public OrdenVehiculosController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("vehicleorder")]
        public async Task<IActionResult> vehicleorder()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<OrdenVehiculos> vehicleorder = new List<OrdenVehiculos>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID_ORDEN");
            query.From("OrdenVehiculos");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                vehicleorder = DataReaderMapper<OrdenVehiculos>.MapToList(reader);
            });

            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, vehicleorder);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] OrdenVehiculos request)
        {

            var query = new Query("Vehiculo").AsInsert(new
            {
                UUID_ORDEN = request.UUID_ORDEN,
                UUID_USUARIO = request.UUID_USUARIO,
                UUID_RUTA = request.UUID_RUTA,
                UUID_VEHICULO = request.UUID_VEHICULO,
                KM = request.KM,
                FECHA_INGRESO = new DateTime(2009, 8, 4),
                FECHA_ASIGNACION = new DateTime(2009, 8, 4),
                FECHA_MODIFICACION = new DateTime(2009, 8, 4),
                FECHA_CREACION = new DateTime(2009, 8, 4),
                UUID_ESTADO = request.UUID_ESTADO,
                DESCRIPCION = request.DESCRIPCION,
                EMPRESA = request.EMPRESA,
                FECHA_ENTREGA = new DateTime(2009, 8, 4),
                FECHA_RECOLECCION = new DateTime(2009, 8, 4),
                PRECIO = request.PRECIO,
                UUID_TIPO_PRECIO = request.UUID_TIPO_PRECIO
            });
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var sql = execute.ExecuterCompiler(query);

            //var resp = execute.ExecuterOracle(sql);
        var resp = "";
            return StatusCode(StatusCodes.Status200OK, resp);

        }

    }
}
