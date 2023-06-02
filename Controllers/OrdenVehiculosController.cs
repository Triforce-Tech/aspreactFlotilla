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

        [HttpPost]
        [Route("guardaOrdenVehiculos")]
        public async Task<IActionResult> guardaOrdenVehiculos([FromBody] OrdenVehiculos request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("ORDEN_VEHICULOS").AsInsert(new
            {

            UUID_USUARIO = request.UUID_USUARIO;
            UUID_RUTA = request.UUID_RUTA;
            UUID_VEHICULO = request.UUID_VEHICULO;
            KM = request.KM;
            FECHA_INGRESO = request.FECHA_INGRESO;
            FECHA_ASIGNACION = reques.FECHA_ASIGNACION;
            FECHA_MODIFICACION = request.FECHA_MODIFICACION;
            FECHA_CREACION = request.FECHA_CREACION;
            UUID_ESTADO = request.UUID_ESTADO;
            DESCRIPCION = request.DESCRIPCION;
            EMPRESA = request.EMPRESA;
            FECHA_ENTREGA = request.FECHA_ENTREGA;
            FECHA_RECOLECCION = request.FECHA_RECOLECCION;
            PRECIO = request.PRECIO;
            UUID_TIPO_PRECIO = request.UUID_TIPO_PRECIO;

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
            List<OrdenVehiculos> listaOrdenVehiculos = new List<OrdenVehiculos>();

            Query query = new Query();
            query.Select(
            "UUID_USUARIO",
            "UUID_RUTA",
            "UUID_VEHICULO",
            "KM",
            "FECHA_INGRESO",
            "FECHA_ASIGNACION",
            "FECHA_MODIFICACION",
            "FECHA_CREACION",
            "UUID_ESTADO",
            "DESCRIPCION",
            "EMPRESA",
            "FECHA_ENTREGA",
            "FECHA_RECOLECCION",
            "PRECIO",
            "UUID_TIPO_PRECIO",
            )
            query.From("ORDEN_VEHICULOS");

            var sql = execute.ExecuterCompiler(query);

            execute.DataReader(sql.ToString(), reader =>
            {
                listaOrdenVehiculos = DataReaderMapper<OrdenVehiculos>.MapToList(reader);
            });

            return StatusCode(StatusCodes.Status200OK, listaOrdenVehiculos);
        }

        [HttpUpdate]
        [Route("actualizaOrdenVehiculos")]
        public async Task<IActionResult> actualizaOrdenVehiculos([FromBody] OrdenVehiculos request)
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

            var query = new Query("ORDEN_VEHICULOS").AsInsert(new
            {

            UUID_USUARIO = request.UUID_USUARIO;
            UUID_RUTA = request.UUID_RUTA;
            UUID_VEHICULO = request.UUID_VEHICULO;
            KM = request.KM;
            FECHA_INGRESO = request.FECHA_INGRESO;
            FECHA_ASIGNACION = reques.FECHA_ASIGNACION;
            FECHA_MODIFICACION = request.FECHA_MODIFICACION;
            FECHA_CREACION = request.FECHA_CREACION;
            UUID_ESTADO = request.UUID_ESTADO;
            DESCRIPCION = request.DESCRIPCION;
            EMPRESA = request.EMPRESA;
            FECHA_ENTREGA = request.FECHA_ENTREGA;
            FECHA_RECOLECCION = request.FECHA_RECOLECCION;
            PRECIO = request.PRECIO;
            UUID_TIPO_PRECIO = request.UUID_TIPO_PRECIO;

            });

            var sql = execute.ExecuterCompiler(query);
            var resp = execute.ExecuteDecider(sql);

            return StatusCode(StatusCodes.Status200OK, resp )

        }

    }
}
