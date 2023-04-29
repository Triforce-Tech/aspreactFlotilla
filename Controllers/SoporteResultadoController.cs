using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassDB.EntidadesDB;
using ClassDB.ConnectDB;
using SqlKata;
using ClassDB.SqlKataTools;

namespace Flotilla_netCORE.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class SoporteResultadoController : ControllerBase
    {

        private readonly OraConnect _context;

        public SoporteResultadoController(OraConnect context)
        {
            _context = context;
        }

        //obtener data
        [HttpGet]
        [Route("supportresult")]
        public async Task<IActionResult> supportresult()
        {
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            List<SoporteResultado> supportresult = new List<SoporteResultado>();
            //query en sqlkata

            Query query = new Query();
            query.Select("UUID");
            query.From("SoporteResultado");
            //query compilacion
            var sql = execute.ExecuterCompiler(query);
            //llenado de objeto tipo lista 
            execute.DataReader(sql.ToString(), reader =>
            {
                supportresult = DataReaderMapper<SoporteResultado>.MapToList(reader);
            });

            // llenado de objeto tipo clase
            //UserSession users = new UserSession();
            //execute.DataReader(sql.ToString(), reader =>
            //{
            //    users = DataReaderMapper<UserSession>.MapToObject(reader);
            //});

            return StatusCode(StatusCodes.Status200OK, supportresult);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] SoporteResultado request)
        {

            var query = new Query("Vehiculo").AsInsert(new
            {
                UUID = request.UUID,
                UUID_SOPORTE = request.UUID_SOPORTE,
                ESTADO = request.ESTADO,
                FECHA_CARGA = new DateTime(2009, 8, 4),
                FECHA_MODIFICACION = new DateTime(2009, 8, 4)
            });
            ExecuteFromDBMSProvider execute = new ExecuteFromDBMSProvider();
            var sql = execute.ExecuterCompiler(query);

            //var resp = execute.ExecuterOracle(sql);
        var resp = "";
            return StatusCode(StatusCodes.Status200OK, resp);

        }

    }
}
