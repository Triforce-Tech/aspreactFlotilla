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
    public class licenciasoperadorController : ControllerBase
    {
        //obtener data
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<LicenciasPorOperador> licenceop = new List<LicenciasPorOperador>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID").Select("TIPO").Select("DESCRIPCION");
            query.From("LICENCIAS_POR_OPERADOR");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista
            execute.DataReader(sql.ToString(), reader =>
            {
                licenceop = DataReaderMapper<LicenciasPorOperador>.MapToList(reader);
            });

            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, licenceop);

        }

        //ejemplo
        [HttpPost]
        [Route("Guardalicencia")]
        public async Task<IActionResult> Guardalicencia([FromBody] LicenciasPorOperador request)
        {
        ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

        var query = new Query("LICENCIAS_POR_OPERADOR").AsInsert(new
            {
                UUID_OPERADOR = request.UUID_OPERADOR,
                TIPO = request.TIPO,
                DESCRIPCION = request.DESCRIPCION,
                FECHA_EMISION = request.FECHA_EMISION,
                FECHA_CADUCIDAD = request.FECHA_CADUCIDAD

            });

            var sql3 = execute.ExecuterCompiler(query);
             var resp = execute.ExecuteDecider(sql3);


        return StatusCode(StatusCodes.Status200OK, resp );
        }

        [HttpPut]
        [Route("Actualizalicencia")]
        public async Task<IActionResult> Actualizalicencia([FromBody] LicenciasPorOperador request)
        {
        ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();

        var query = new Query("LicenciasPorOperador").AsInsert(new
            {
                UUID_OPERADOR = request.UUID_OPERADOR,
                TIPO = request.TIPO,
                DESCRIPCION = request.DESCRIPCION,
                FECHA_EMISION = request.FECHA_EMISION,
                FECHA_CADUCIDAD = request.FECHA_CADUCIDAD

            });

            var sql3 = execute.ExecuterCompiler(query);
             var resp = execute.ExecuteDecider(sql3);


            return StatusCode(StatusCodes.Status200OK, resp);

        }
        
    }
}